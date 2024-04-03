import { Injectable } from '@angular/core';
import { UpdateFormValue } from '@ngxs/form-plugin';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { AccountForDetail } from 'app/model/referential/account.model';
import { HelperService } from 'app/services/helper.service';
import { catchError, finalize, throwError } from 'rxjs';
import { AccountApiService } from '../account.api.service';
import { LoadAccountDetailFilter } from './account-detail-filter/account-detail-filter.action';
import { AccountDetailChangeBankAgency, AccountDetailChangeBankSubFamily, ClearAccountDetail, LoadAccountDetail, SaveAccountDetail } from './account-detail.action';
import { LoaderState } from 'app/state/_base/loader-state';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { DetailFormInfo, FilterForDetail } from '@corporate/model';
import { UserForGroup } from 'app/model/referential/user/user.model';

export class AccountDetailStateModel extends DetailFormInfo<AccountForDetail, FilterForDetail> {
    constructor() {
        super();
        this.filter = new FilterForDetail();
    }
}

const detailInfo = new AccountDetailStateModel();
@State<AccountDetailStateModel>({
    name: 'accountDetail',
    defaults : detailInfo
})

@Injectable()
export class AccountDetailState extends LoaderState {
    constructor(
        private _accountApiService: AccountApiService,
        private _store: Store,
        private _helperService: HelperService,
        private _userLoggedService: UserLoggedService,
        // private _notificationsService: NotificationsService
    )
    {
        super();

    }

    @Selector() static get(state: AccountDetailStateModel): any { return state;  }
    @Selector() static getFilter(state: AccountDetailStateModel): any { return state.filter; }

    @Action(LoadAccountDetail)
    loadAccountDetail(context: StateContext<AccountDetailStateModel>, action: LoadAccountDetail): void {

        this.loading(context,'datas');

        context.patchState({
            filter: action.payload,
            model: null
        });

        this._accountApiService.getForDetail(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                context.patchState({
                    filter: action.payload,
                    model: {
                        ...result,
                        user: { id: this._userLoggedService.userForInfo.id, idUserGroup: this._userLoggedService.userForInfo.idUserGroup } as UserForGroup
                        // bankFamily: result.bankAgency?.bankSubFamily?.bankFamily,
                        // bankSubFamily: result.bankAgency?.bankSubFamily
                    }
                });

                //chargement des filtres associés
                context.dispatch(new LoadAccountDetailFilter(result));
            });
    }

    @Action(SaveAccountDetail)
    saveAccountDetail(context: StateContext<AccountDetailStateModel>, action: SaveAccountDetail): void {
        this.loading(context, 'datas-save');

        this._accountApiService.save(action.payload.accountDetail)
            .pipe(
                catchError((error) => {
                    console.log('Handling error locally and rethrowing it...', error);
                    return throwError(()=>error);
                }),
                finalize(()=> {this.loaded(context,'datas-save');}))
            .subscribe((result: AccountForDetail)=> {
                this._store.dispatch(new UpdateFormValue({
                    path:'accountDetail',
                    value: {
                        id : result.id
                    }
                }));

                //TODO replace par tostr
                // this._notificationsService.create('Enregistrement effectué', `compte: ${result.number} enregistré avec succès!`, NotificationType.Success, this._notificationsService.globalOptions);

            });
    }

    @Action(ClearAccountDetail)
    clearAccountDetail(context: StateContext<AccountDetailStateModel>): void {
        context.setState(new AccountDetailStateModel());
    }

    @Action(AccountDetailChangeBankSubFamily)
    accountDetailChangeBankSubFamily(context: StateContext<AccountDetailStateModel>, action: AccountDetailChangeBankSubFamily): void {

        this.loading(context,'bank-sub-family-change');

        this._store.dispatch(
            new UpdateFormValue({
                path:'accountDetail',
                value: {
                    bankSubFamily:action.payload.bankSubFamily
                }
            })
        );

        this.loaded(context,'bank-sub-family-change');
    }

    @Action(AccountDetailChangeBankAgency)
    accountDetailChangeBankAgency(context: StateContext<AccountDetailStateModel>, action: AccountDetailChangeBankAgency): void {

        this.loading(context,'bank-agency-change');

        this._store.dispatch(
            new UpdateFormValue({
                path:'accountDetail',
                value: {
                    bankAgency:action.payload.bankAgency
                }
            })
        );

        this.loaded(context,'bank-agency-change');
    }
}
