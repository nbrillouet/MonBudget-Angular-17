import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { EnumActivationCode } from 'app/model/enum/enum-activation-code.enum';
import { Datas } from 'app/model/generics/detail-info.model';
import { ISelect } from 'app/model/generics/select.model';
import { AccountForTable } from 'app/model/referential/account.model';
import { ReferentialService } from 'app/services/referential/referential.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { TypeButtonIcon } from '@corporate/mat-table-filter';
import { UpdateAccountTableFilterSelectedByProperties } from './account-table-filter-selected/account-table-filter-selected.action';
import { ClearAccountTable, LoadAccountTable } from './account-table.action';

export class AccountTableStateModel extends Datas<AccountForTable[]> {
    constructor() {
        super();
    }
}

const accountTableStateModel = new AccountTableStateModel();
@State<AccountTableStateModel>({
    name: 'AccountForTable',
    defaults : accountTableStateModel
})

@Injectable()
export class AccountTableState extends LoaderState {
    constructor(
        private _referentialService: ReferentialService,
        private _store: Store
    ) {
        super();
    }

    @Selector() static get(state: AccountTableStateModel): any { return state; }

    @Action(LoadAccountTable)
    loadAccountTable(context: StateContext<AccountTableStateModel>, action: LoadAccountTable): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._referentialService.accountService.getForTable(action.payload).subscribe((result)=> {
            //ajouter icon sur activationCode
            result.datas = this.getTableIcons(result.datas);

            context.patchState({
                datas: result.datas
            });

            this.loaded(context,'datas');

            this._store.dispatch(new UpdateAccountTableFilterSelectedByProperties({properties: [ { name:'pagination', value: result.pagination} ] }));
        });
    }

    @Action(ClearAccountTable)
    clearAccountTable(context: StateContext<AccountTableStateModel>): void {
        context.setState(new AccountTableStateModel());
    }

    getTableIcons(accountForTables: AccountForTable[]): AccountForTable[] {
        accountForTables.forEach( (data: AccountForTable) => {
            data.activationCodeIcon = this.getTypeButtonIconForActivationCode(data.enumActivationCode);
            data.linkedUsersIcon = this.getTypeButtonIconForLinkedUsers(data.linkedUsers);
        });

        return accountForTables;
    }

    getTypeButtonIconForActivationCode(enumActivationCode: EnumActivationCode): TypeButtonIcon {
        switch(enumActivationCode) {
            case 1:
                return {icon:'check',tooltip:'activé',color:'primary'} as TypeButtonIcon;
            case 2:
                return {icon:'hourglass_empty',tooltip:'attente validation',color:'warn'} as TypeButtonIcon;
            case 3:
                return {icon:'close',tooltip:'refusé',color:'warn'} as TypeButtonIcon;
            default:
                return null;
        }
    }

    getTypeButtonIconForLinkedUsers(linkedUsers: ISelect[]): TypeButtonIcon {

        if(linkedUsers!=null && linkedUsers.length>0) {
            return {icon:'link',tooltip:'compte lié',color:'warn'} as TypeButtonIcon;
        }

        return {icon:'link_off',tooltip:'compte non lié',color:'primary'} as TypeButtonIcon;
    }

}
