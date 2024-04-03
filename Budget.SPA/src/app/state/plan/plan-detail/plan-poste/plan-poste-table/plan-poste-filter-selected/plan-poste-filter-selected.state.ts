import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterPlanPosteTableSelected } from 'app/model/filters/plan-poste.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadPlanPosteTable } from '../plan-poste-table.action';
import { ChangePlanPosteTableFilterSelected, UpdatePaginationPlanPosteTableFilterSelected } from './plan-poste-filter-selected.action';

export class PlanPosteTableFilterSelectedStateModel extends FilterSelected<FilterPlanPosteTableSelected> {
    constructor() {
        super(FilterPlanPosteTableSelected);
    }
}

const planPosteTableFilterSelectedStateModel = new PlanPosteTableFilterSelectedStateModel();

@State<PlanPosteTableFilterSelectedStateModel>({
    name: 'PlanPosteTableFilterSelected',
    defaults : planPosteTableFilterSelectedStateModel
})

@Injectable()
export class PlanPosteTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store
        ) {
            super();
    }

    @Selector() static get(state: PlanPosteTableFilterSelectedStateModel): any { return state; }


    @Action(UpdatePaginationPlanPosteTableFilterSelected)
    updatePaginationPlanPosteTableFilterSelected(context: StateContext<PlanPosteTableFilterSelectedStateModel>, action: UpdatePaginationPlanPosteTableFilterSelected): void {
        this.loading(context,'filter-selected');

        context.patchState({
            selected: {
                ...context.getState().selected,
                pagination: action.payload
            }
        });

        this.loaded(context,'filter-selected');
    }

    @Action(ChangePlanPosteTableFilterSelected)
    changePlanPosteTableFilterSelected(context: StateContext<PlanPosteTableFilterSelectedStateModel>, action: ChangePlanPosteTableFilterSelected): void {
        this.loading(context,'filter-selected');

        context.patchState({
            selected: action.payload
        });
        this.loaded(context,'filter-selected');

        this._store.dispatch(new LoadPlanPosteTable(action.payload));
    }

    // @Action(SynchronizePlanPosteTableFilterSelected)
    // synchronizePlanPosteTableFilterSelected(context: StateContext<PlanPosteTableFilterSelectedStateModel>, action: SynchronizePlanPosteTableFilterSelected): void {
    //     this.loading(context,'filter-selected');
    //     const state = context.getState();
    //     state.selected = action.payload;
    //     context.patchState(state);
    //     this.loaded(context,'filter-selected');

    //     this._store.dispatch(new LoadPlanPosteTable(action.payload));
    // }

}
