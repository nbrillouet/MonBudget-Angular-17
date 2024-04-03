import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterOTableSelected } from 'app/model/filters/operation.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { ChangeOTable } from '../operation-table.action';
import { ChangeOTableFilterSelected, ChangeOTableFilterSelectedPagination } from './operation-table-filter-selected.action';

export class OTableFilterSelectedStateModel extends FilterSelected<FilterOTableSelected> {
    constructor() {
        super(FilterOTableSelected);
    }
}

const oTableFilterSelectedStateModel = new OTableFilterSelectedStateModel();

@State<OTableFilterSelectedStateModel>({
    name: 'OTableFilterSelected',
    defaults : oTableFilterSelectedStateModel
})

@Injectable()
export class OTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store
        ) {
            super();
    }

    @Selector()
    static get(state: OTableFilterSelectedStateModel): any { return state; }


    @Action(ChangeOTableFilterSelected)
    changeOTableFilterSelected(context: StateContext<OTableFilterSelectedStateModel>, action: ChangeOTableFilterSelected): void {
        this.loading(context,'filter-selected');

        context.patchState({
            selected: action.payload
        });

        this._store.dispatch(new ChangeOTable(action.payload));

        this.loaded(context,'filter-selected');
    }

    @Action(ChangeOTableFilterSelectedPagination)
    changeOTableFilterSelectedPagination(context: StateContext<OTableFilterSelectedStateModel>, action: ChangeOTableFilterSelectedPagination): void {
        this.loading(context,'filter-selected-pagination');

        context.patchState({
            selected: {
                ...context.getState().selected,
                pagination: action.payload
            }
        });

        this.loaded(context,'filter-selected-pagination');
    }
}
