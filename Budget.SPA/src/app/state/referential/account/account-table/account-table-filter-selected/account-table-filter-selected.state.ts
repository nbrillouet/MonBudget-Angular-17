import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterAccountTableSelected } from 'app/model/filters/account.filter';
import { FilterSelected } from 'app/model/generics/filter.info.model';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadAccountTable } from '../account-table.action';
import { UpdateAccountTableFilterSelected, UpdateAccountTableFilterSelectedByProperties } from './account-table-filter-selected.action';

export class AccountTableFilterSelectedStateModel extends FilterSelected<FilterAccountTableSelected> {
    constructor() {
        super(FilterAccountTableSelected);
    }
}

const accountTableFilterSelectedStateModel = new AccountTableFilterSelectedStateModel();

@State<AccountTableFilterSelectedStateModel>({
    name: 'AccountTableFilterSelected',
    defaults : accountTableFilterSelectedStateModel
})

@Injectable()
export class AccountTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store,
        private _helperService: HelperService
        ) {
            super();
    }

    @Selector() static get(state: AccountTableFilterSelectedStateModel): any { return state; }

    @Action(UpdateAccountTableFilterSelectedByProperties)
    updateAccountTableFilterSelectedByProperties(context: StateContext<AccountTableFilterSelectedStateModel>, action: UpdateAccountTableFilterSelectedByProperties): void {
        this.loading(context,'filter-selected');

        let selected: FilterAccountTableSelected;

        selected = this._helperService.getDeepClone(context.getState().selected);
        selected.isPaginationUpdate = false;

        action.payload.properties.forEach( (property) => {
            selected = this._helperService.setDeepProperty(selected,property.name,property.value);
            if(property.name==='pagination') {
                selected.isPaginationUpdate=true;
            }
        });

        //user
        selected.user = selected.user == null ? this._helperService.getUserForGroupFromStorage() : selected.user;
        // //monthYear
        // selected.monthYear = selected.monthYear == null ? this._helperService.getMonthYear() : selected.monthYear;

        context.patchState({ selected: selected });

        this.loaded(context,'filter-selected');

        //Pagination est donnée par la table
        if(!selected.isPaginationUpdate) {
            this._store.dispatch(new LoadAccountTable(context.getState().selected));
        }

    }

    @Action(UpdateAccountTableFilterSelected)
    updateAccountTableFilterSelected(context: StateContext<AccountTableFilterSelectedStateModel>, action: UpdateAccountTableFilterSelected): void {
        this.loading(context,'filter-selected');

        const selected: FilterAccountTableSelected = action.payload;
        context.patchState({ selected: selected });

        this.loaded(context,'filter-selected');

        this._store.dispatch(new LoadAccountTable(context.getState().selected));
    }


}
