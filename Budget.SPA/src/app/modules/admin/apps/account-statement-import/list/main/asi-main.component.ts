import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'app/core/auth/auth.service';
import { AsiService } from 'app/services/account-statement/account-statement-import/asi.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'account-statement-import-main',
    templateUrl    : './asi-main.component.html'
    // encapsulation  : ViewEncapsulation.None
})
export class AsiMainComponent implements OnInit, OnDestroy
{
    idBankAgency: number = null;

    constructor(
        public _asiService: AsiService,
        private _authService: AuthService,
        private _userLoggedService: UserLoggedService,
        private _activatedRoute: ActivatedRoute

        // private _router: Router,
        // private _helperService: HelperService
    )
    {

        // this._userLoggedService.userLoggedState$.subscribe((x)=>{
        //     const toto = x.datas.userPreference.bannerUrl;
        // });

    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        this._asiService.state$.subscribe((x)=> {

        });

        this._activatedRoute.params.subscribe((routeParams) => {
            this.idBankAgency = routeParams['folderId'];

            if(!this.idBankAgency) {
                this._asiService.loadAsiFolderExplorer(this._authService.user.id);
             }
        });
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {
        // // Unsubscribe from all subscriptions
        // this._unsubscribeAll.next();
        // this._unsubscribeAll.complete();
    }


}
