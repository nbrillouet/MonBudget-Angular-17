import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterAccountTableSelection } from 'app/model/filters/account.filter';
import { FilterSelection } from 'app/model/generics/filter.info.model';
import { ReferentialService } from 'app/services/referential/referential.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadAccountTableFilterSelection } from './account-table-filter-selection.action';

export class AccountTableFilterSelectionStateModel extends FilterSelection<FilterAccountTableSelection> {
    constructor() {
        super(FilterAccountTableSelection);
    }
}

const accountTableFilterSelectionStateModel = new AccountTableFilterSelectionStateModel();

@State<AccountTableFilterSelectionStateModel>({
    name: 'AccountTableFilterSelection',
    defaults : accountTableFilterSelectionStateModel
})

@Injectable()
export class AccountTableFilterSelectionState extends LoaderState {

    constructor(
        private _referentialService: ReferentialService
        // private _store: Store
        ) {
            super();
    }

    @Selector() static get(state: AccountTableFilterSelectionStateModel): any { return state; }

    @Action(LoadAccountTableFilterSelection)
    loadAccountTableFilterSelection(context: StateContext<AccountTableFilterSelectionStateModel>, action: LoadAccountTableFilterSelection): void {
        this.loading(context,'filter-selection');

        context.patchState({
            selection: null
        });

        this._referentialService.accountService.getForTableFilter(action.payload)
            .subscribe((result)=> {
                context.patchState({
                    selection: result
                });

                this.loaded(context,'filter-selection');
            });

    }
}
