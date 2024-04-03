import { Injectable } from '@angular/core';
import { DataInfo } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterAccountDetail } from 'app/model/filters/account.filter';
import { ReferentialService } from 'app/services/referential/referential.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AccountApiService } from '../../account.api.service';
import { AccountDetailChangeBankAgency, AccountDetailChangeBankSubFamily } from '../account-detail.action';
import { AccountDetailFilterChangeBankAgency, AccountDetailFilterChangeBankSubFamily, ClearAccountDetailFilter, LoadAccountDetailFilter } from './account-detail-filter.action';

export class AccountDetailFilterStateModel extends DataInfo<FilterAccountDetail> {
    constructor() {
        super();
    }
}

const accountDetailFilterStateModel = new AccountDetailFilterStateModel();
@State<AccountDetailFilterStateModel>({
    name: 'AccountDetailFilter',
    defaults: accountDetailFilterStateModel
})

@Injectable()
export class AccountDetailFilterState extends LoaderState {
    constructor(
        private _accountApiService: AccountApiService,
        private _referentialService: ReferentialService,
        private _store: Store
    ) {
        super();
    }

    @Selector() static get(state: AccountDetailFilterStateModel): any { return state; }

    @Action(LoadAccountDetailFilter)
    loadAccountDetailFilter(context: StateContext<AccountDetailFilterStateModel>, action: LoadAccountDetailFilter): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._accountApiService.getForDetailFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result) => {
                context.patchState({
                    datas: result
                });
            });
    }

    @Action(ClearAccountDetailFilter)
    clearAccountDetailFilter(context: StateContext<AccountDetailFilterStateModel>): void {
        context.setState(new AccountDetailFilterStateModel());
    }

    //====================================
    //          Bank sub family
    //====================================
    // changement bank sub family list
    @Action(AccountDetailFilterChangeBankSubFamily)
    accountDetailFilterChangeBankSubFamily(context: StateContext<AccountDetailFilterStateModel>, action: AccountDetailFilterChangeBankSubFamily): void {
        this.loading(context,'bank-sub-family-list');
        context.patchState({
            datas: {
                ...context.getState().datas,
                bankSubFamily: []
            }
        });

        this._referentialService.bankSubFamilyService.getSelectList(action.payload.bankFamily.id)
            .pipe(finalize(()=> {this.loaded(context,'bank-sub-family-list');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: {
                        ...context.getState().datas,
                        bankSubFamily: result
                    }
                });
                this._store.dispatch(new AccountDetailChangeBankSubFamily( { bankSubFamily: null }));
            });
    }

    //====================================
    //          Bank agency
    //====================================
    // changement bank agency list
    @Action(AccountDetailFilterChangeBankAgency)
    accountDetailFilterChangeBankAgency(context: StateContext<AccountDetailFilterStateModel>, action: AccountDetailFilterChangeBankAgency): void {
        this.loading(context,'bank-agency-list');

        context.patchState({
            datas: {
                ...context.getState().datas,
                bankAgency: []
            }
        });
        this._store.dispatch(new AccountDetailChangeBankAgency( { bankAgency: null }));

        if(action.payload.bankSubFamily?.id) {
            this._referentialService.bankAgencyService.getSelectList(action.payload.bankSubFamily?.id)
            .pipe(finalize(()=> { this.loaded(context,'bank-agency-list'); }))
            .subscribe((result)=> {
                context.patchState({
                    datas: {
                        ...context.getState().datas,
                        bankAgency: result
                    }
                });
            });
        }

    }
}
