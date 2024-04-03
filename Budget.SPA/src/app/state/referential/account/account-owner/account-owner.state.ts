import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { NotificationsService, NotificationType } from 'angular2-notifications';
import { AccountOwner } from 'app/model/referential/account.model';
import { AccountOwnerService } from 'app/services/account-owner.service';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AskAccountOwner, ResponseAccountOwner } from './account-owner.action';

export class AccountOwnerStateModel extends Datas<AccountOwner> {
    constructor() {
        super();
    }
}

const detailInfo = new AccountOwnerStateModel();
@State<AccountOwnerStateModel>({
    name: 'accountOwner',
    defaults : detailInfo
})

@Injectable()
export class AccountOwnerState extends LoaderState {
    constructor(
        private _accountOwnerService: AccountOwnerService,
        private _store: Store,
        private _helperService: HelperService,
        private _notificationsService: NotificationsService
    )
    {
        super();
    }

    // eslint-disable-next-line @typescript-eslint/member-ordering
    @Selector() static get(state: AccountOwnerStateModel): any { return state;  }

    @Action(AskAccountOwner)
    askAccountOwner(context: StateContext<AccountOwnerStateModel>, action: AskAccountOwner): void {
        this.loading(context, 'ask-account-owner');

        action.payload.user = action.payload.user == null ? this._helperService.getUserForGroupFromStorage() : action.payload.user;

        this._accountOwnerService.askAccountOwner(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'ask-account-owner');}))
            .subscribe(()=> {
                // this._store.dispatch(new UpdateFormValue({
                //     path:'accountDetail',
                //     value: {
                //         hasSameUser : false
                //     }
                // }));
                this._notificationsService.create('demande envoyée', 'la demande est envoyée!', NotificationType.Success, this._notificationsService.globalOptions)
                this.loaded(context,'ask-account-owner');
            });
    }

    @Action(ResponseAccountOwner)
    responseAccountOwner(context: StateContext<AccountOwnerStateModel>, action: ResponseAccountOwner): void {
        this.loading(context, 'response-account-owner');

        this._accountOwnerService.responseAccountOwner(action.payload).subscribe((resp)=> {
            context.patchState({
                datas: resp
            });

            // this._notificationsService.create(`demande envoyée`, `la demande est envoyée!`, NotificationType.Success, this._notificationsService.globalOptions)
            this.loaded(context,'response-account-owner');
        });
    }
}




