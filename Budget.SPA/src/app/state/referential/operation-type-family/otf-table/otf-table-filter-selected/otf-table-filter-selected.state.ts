import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { ChangeOtfTable } from '../otf-table.action';
import { ChangeOtfTableFilterSelected, ChangeOtfTableFilterSelectedPagination } from './otf-table-filter-selected.action';

export class OtfTableFilterSelectedStateModel extends FilterSelected<FilterOtfTableSelected> {
    constructor() {
        super(FilterOtfTableSelected);
    }
}

const otfTableFilterSelectedStateModel = new OtfTableFilterSelectedStateModel();

@State<OtfTableFilterSelectedStateModel>({
    name: 'OtfTableFilterSelected',
    defaults : otfTableFilterSelectedStateModel
})

@Injectable()
export class OtfTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store
        ) {
            super();
    }

    @Selector()
    static get(state: OtfTableFilterSelectedStateModel): any { return state; }


    @Action(ChangeOtfTableFilterSelected)
    changeOtfTableFilterSelected(context: StateContext<OtfTableFilterSelectedStateModel>, action: ChangeOtfTableFilterSelected): void {
        this.loading(context,'filter-selected');

        context.patchState({
            selected: action.payload
        });

        this._store.dispatch(new ChangeOtfTable(action.payload));

        this.loaded(context,'filter-selected');
    }

    @Action(ChangeOtfTableFilterSelectedPagination)
    changeOtfTableFilterSelectedPagination(context: StateContext<OtfTableFilterSelectedStateModel>, action: ChangeOtfTableFilterSelectedPagination): void {
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

