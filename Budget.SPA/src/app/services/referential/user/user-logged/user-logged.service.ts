import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { FuseConfigService } from '@fuse/services/config';
import { DataInfo } from '@corporate/model';
import { TranslocoService } from '@ngneat/transloco';
import { Select, Store } from '@ngxs/store';
import { NavigationService } from 'app/core/navigation/navigation.service';
import { EnumUserStatus } from 'app/model/enum/enum-user-status.enum';
import { UserForInfo, UserForLogged, UserPreference } from 'app/model/referential/user/user.model';
import { Observable } from 'rxjs';
import { UserLoggedState } from 'app/state/user/user-logged/user-logged.state';
import { LoadUserLogged, UpdateStatusUserLogged, UpdateUserPreference } from 'app/state/user/user-logged/user-logged.action';

@Injectable({ providedIn: 'root' })
export class UserLoggedService
{
    @Select(UserLoggedState.get) public userLoggedState$: Observable<DataInfo<UserForLogged>>;
    isFirstLoad: boolean = true;
    fuseConfig: any;
    userForLogged: UserForLogged;
    userForInfo: UserForInfo;
    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _navigationService: NavigationService,
        private _fuseConfigService: FuseConfigService,
        private _router: Router,
        private _translocoService: TranslocoService
    )
    {
        this.userLoggedState$.subscribe((x)=> {
            if(x?.loader['datas']?.loaded && this.isFirstLoad) {
                this._navigationService.get(x.datas);
                this.fuseConfig = this.getFuseConfig(x.datas.userPreference);
                this._fuseConfigService.config = this.fuseConfig;
                this._translocoService.setActiveLang(x.datas.userPreference.language);
                this.userForLogged = x.datas;
                this.userForInfo = x.datas;
                // this.setLayout(layout);
                // this.isFirstLoad=false;
            }
        });

        this._fuseConfigService.config$.subscribe((settings) => {
            this.fuseConfig = settings;
        });
    }



    // // -----------------------------------------------------------------------------------------------------
    // // @ Public methods
    // // -----------------------------------------------------------------------------------------------------
    load(param: { idUser: number }): void {
        this._store.dispatch(new LoadUserLogged(param));
    }

    updateUserPreference(idUser: number, userPreference: UserPreference): void {
        this._store.dispatch(new UpdateUserPreference({idUser: idUser, userPreference: userPreference}));
    }


    setLayout(layout: string): void
    {
        // Clear the 'layout' query param to allow layout changes
        this._router.navigate([], {
            queryParams        : {
                layout: null
            },
            queryParamsHandling: 'merge'
        }).then(() => {

            // Set the config
            this._fuseConfigService.config = {layout};
        });
    }

    private getFuseConfig(userPreference: UserPreference): any {
        return { 'layout': userPreference.layout, 'scheme': userPreference.scheme, 'theme': userPreference.theme };
        // this.fuseConfig.layout = userPreference.layout;
        // this.fuseConfig.scheme = userPreference.scheme;
        // this.fuseConfig.theme = userPreference.theme;
    }

}
