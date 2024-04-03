import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnDestroy, OnInit, Renderer2, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { LambdaExpression } from '@corporate/data';
import { FuseConfig, FuseConfigService, Scheme, Theme } from '@fuse/services/config';
import { AuthService } from 'app/core/auth/auth.service';
import { UserForDetail, UserPreference } from 'app/model/referential/user/user.model';
import { HelperService } from 'app/services/helper.service';
import { ProfileService } from 'app/services/referential/user/profile/profile.service';
import { combineLatest, Subject, takeUntil } from 'rxjs';

@Component({
    selector     : 'profile-preference',
    templateUrl  : './profile-preference.component.html',
    encapsulation: ViewEncapsulation.None
})
export class ProfilePreferenceComponent implements OnInit, OnDestroy
{
    idUserLogged: number;
    property: UserForDetail = this._profileService.form.model as UserForDetail;
    userDetailState: any;
    config: FuseConfig;
    layout: string;
    scheme: Scheme; // 'dark' | 'light';
    theme: string;
    themes: [string, any][] = [];
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    /**
     * Constructor
     */
    constructor(
        private _activatedRoute: ActivatedRoute,
        @Inject(DOCUMENT) private _document: any,
        private _renderer2: Renderer2,
        private _router: Router,
        private _fuseConfigService: FuseConfigService,
        // private _fuseMediaWatcherService: FuseMediaWatcherService,
        // private _fuseTailwindConfigService: FuseTailwindService,
        public _profileService: ProfileService,
        private _authService: AuthService,
        private _helperService: HelperService
    )
    {
        // this.property = this._profileService.form.model as UserForDetail;
        this.idUserLogged = this._authService.user.id;
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        // Get the themes
        // Subscribe to config changes
        this._fuseConfigService.config$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((config: FuseConfig) =>
            {
                // Store the config
                this.config = config;
            });
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next(void 0);
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Set the layout on the config
     *
     * @param layout
     */
    setLayout(layout: string): void
    {
        // Clear the 'layout' query param to allow layout changes
        this._router.navigate([], {
            queryParams        : {
                layout: null
            },
            queryParamsHandling: 'merge'
        }).then(() => {
            this.changeUserPreference(x=>x.layout, layout);
            if(this.checkUserConnected()){
                this._fuseConfigService.config = {layout};
            }
            // Set the config
            // this._fuseConfigService.config = {layout};
        });
    }

    /**
     * Set the scheme on the config
     *
     * @param scheme
     */
    setScheme(scheme: Scheme): void
    {
        this.changeUserPreference(x=>x.scheme, scheme);
        if(this.checkUserConnected()){
            this._fuseConfigService.config = {scheme};
        }
    }

    /**
     * Set the theme on the config
     *
     * @param theme
     */
    setTheme(theme: Theme): void
    {
        this.changeUserPreference(x=>x.theme, theme);
        if(this.checkUserConnected()){
            this._fuseConfigService.config = {theme};
        }
    }

    public getValue(property: string): any {
        return this._profileService.form.getValue(property);
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Private methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Update the selected layout
     */
    private _updateLayout(): void
    {
        // Get the current activated route
        let route = this._activatedRoute;
        while ( route.firstChild )
        {
            route = route.firstChild;
        }

        // 1. Set the layout from the config
        // this.layout = this.config.layout;

        // 2. Get the query parameter from the current route and
        // set the layout and save the layout to the config
        const layoutFromQueryParam = (route.snapshot.queryParamMap.get('layout') as string);
        if ( layoutFromQueryParam )
        {
            this.layout = layoutFromQueryParam;
            if ( this.config )
            {
                this.config.layout = layoutFromQueryParam;
            }
        }

        // 3. Iterate through the paths and change the layout as we find
        // a config for it.
        //
        // The reason we do this is that there might be empty grouping
        // paths or componentless routes along the path. Because of that,
        // we cannot just assume that the layout configuration will be
        // in the last path's config or in the first path's config.
        //
        // So, we get all the paths that matched starting from root all
        // the way to the current activated route, walk through them one
        // by one and change the layout as we find the layout config. This
        // way, layout configuration can live anywhere within the path and
        // we won't miss it.
        //
        // Also, this will allow overriding the layout in any time so we
        // can have different layouts for different routes.
        const paths = route.pathFromRoot;
        paths.forEach((path) => {

            // Check if there is a 'layout' data
            if ( path.routeConfig && path.routeConfig.data && path.routeConfig.data.layout )
            {
                // Set the layout
                this.layout = path.routeConfig.data.layout;
            }
        });
    }

    /**
     * Update the selected scheme
     *
     * @private
     */
    private _updateScheme(): void
    {
        // Remove class names for all schemes
        this._document.body.classList.remove('light', 'dark');

        // Add class name for the currently selected scheme
        this._document.body.classList.add(this.scheme);
    }

    /**
     * Update the selected theme
     *
     * @private
     */
    private _updateTheme(): void
    {
        // Find the class name for the previously selected theme and remove it
        this._document.body.classList.forEach((className: string) => {
            if ( className.startsWith('theme-') )
            {
                this._document.body.classList.remove(className, className.split('-')[1]);
            }
        });

        // Add class name for the currently selected theme
        this._document.body.classList.add(`theme-${this.theme}`);
    }



    private checkUserConnected(): boolean {
        if(this._authService.user.id===Number(this._profileService.form.getValue(x=>x.id))) {
            return true;
        }
        return false;
    }

    private changeUserPreference(nameFunction: ((obj: UserPreference) => any), value: any): void {
        const userPreference = this._profileService.form.getValue(x=>x.userPreference) as UserPreference;
        const params = LambdaExpression.getParameters<UserPreference>(nameFunction.toString(), userPreference, value);

        this._profileService.changeUserPreference(Number(this._profileService.form.getValue(x=>x.id)), params);
    }

}
