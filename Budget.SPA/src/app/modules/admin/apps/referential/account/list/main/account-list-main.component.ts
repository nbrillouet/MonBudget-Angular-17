import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AuthService } from 'app/core/auth/auth.service';
import { AccountListService } from 'app/services/referential/account/list/account-list.service';

@Component({
    selector       : 'account-list-main',
    templateUrl    : './account-list-main.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AccountListMainComponent implements OnInit, OnDestroy
{

    /**
     * Constructor
     */
    constructor(
        private _authService: AuthService,
        public _accountListService: AccountListService

    )
    {
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        this._accountListService.loadAccountList(this._authService.user.id);
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
