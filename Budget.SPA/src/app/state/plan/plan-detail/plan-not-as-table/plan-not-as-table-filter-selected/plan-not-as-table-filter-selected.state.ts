import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterPlanNotAsTableSelected } from 'app/model/filters/plan-not-as.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { ChangePlanNotAsTable } from '../plan-not-as-table.action';
import { ChangePlanNotAsTableFilterSelected, ChangePlanNotAsTableFilterSelectedPagination } from './plan-not-as-table-filter-selected.action';


export class PlanNotAsTableFilterSelectedStateModel extends FilterSelected<FilterPlanNotAsTableSelected> {
    constructor() {
        super(FilterPlanNotAsTableSelected);
    }
}

const planNotAsTableFilterSelectedStateModel = new PlanNotAsTableFilterSelectedStateModel();

@State<PlanNotAsTableFilterSelectedStateModel>({
    name: 'PlanNotAsTableFilterSelected',
    defaults : planNotAsTableFilterSelectedStateModel
})

@Injectable()
export class PlanNotAsTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store
        ) {
            super();
    }

    @Selector()
    static get(state: PlanNotAsTableFilterSelectedStateModel): any { return state; }

    @Action(ChangePlanNotAsTableFilterSelected)
    changePlanNotAsTableFilterSelected(context: StateContext<PlanNotAsTableFilterSelectedStateModel>, action: ChangePlanNotAsTableFilterSelected): void {
        this.loading(context,'filter-selected');

        context.patchState({
            selected: action.payload.filterPlanNotAsTableSelected
        });

        this._store.dispatch(new ChangePlanNotAsTable(action.payload));

        this.loaded(context,'filter-selected');
    }

    @Action(ChangePlanNotAsTableFilterSelectedPagination)
    changePlanNotAsFilterSelectedPagination(context: StateContext<PlanNotAsTableFilterSelectedStateModel>, action: ChangePlanNotAsTableFilterSelectedPagination): void {

        this.loading(context,'filter-selected');

        context.patchState({
            selected: {
                ...context.getState().selected,
                pagination: action.payload
            }
        });

        this.loaded(context,'filter-selected');
    }

}
