import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountDetailService } from 'app/services/referential/account/detail/account-detail.service';
import { AccountListService } from 'app/services/referential/account/list/account-list.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'account-list-content',
    templateUrl    : './account-list-content.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AccountListContentComponent extends GenericFormComponent implements OnInit, OnDestroy
{

    /**
     * Constructor
     */
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _router: Router,
        public _userLoggedService: UserLoggedService,
        public _accountListService: AccountListService,
        public _accountDetailService: AccountDetailService

    )
    {
        super();

    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        // this._accountService.value.bankSubFamily[0].bankAgency[0].accountList[0].number
        // this._accountService.loadAccountList(this._authService.user.id);
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
    onAccountClick(idAccount: number): void {
        this._accountDetailService.loadAccountDetail({ id: idAccount});

        const url = this._activatedRoute['_routerState'].snapshot.url;
        this._router.navigate([`${url}/${idAccount}/detail`]);
    }

    onAccountCreateClick(idBankFamily: number,idBankSubFamily: number, idBankAgency: number): void {
        this._accountDetailService.loadAccountDetail({ id: null});
        this._router.navigate(['apps/referential/accounts/create/detail']);
    }
}
