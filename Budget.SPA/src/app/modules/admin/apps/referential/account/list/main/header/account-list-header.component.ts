import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'account-list-header',
    templateUrl    : './account-list-header.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AccountListHeaderComponent implements OnInit, OnDestroy
{
    idBankAgency: number = null;

    constructor(
        // public _asiService: AsiService,
        public _userLoggedService: UserLoggedService
        // private _authService: AuthService,
        // private _activatedRoute: ActivatedRoute

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
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {

    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------
}
