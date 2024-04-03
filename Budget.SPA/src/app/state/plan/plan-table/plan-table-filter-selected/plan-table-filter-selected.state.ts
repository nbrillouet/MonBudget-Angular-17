import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterPlanTableSelected } from 'app/model/filters/plan.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadPlanTable } from '../plan-table.action';
import { ChangePlanTableFilterSelected, UpdatePaginationPlanTableFilterSelected } from './plan-table-filter-selected.action';

export class PlanTableFilterSelectedStateModel extends FilterSelected<FilterPlanTableSelected> {
    constructor() {
        super(FilterPlanTableSelected);
    }
}

const planTableFilterSelectedStateModel = new PlanTableFilterSelectedStateModel();

@State<PlanTableFilterSelectedStateModel>({
    name: 'PlanTableFilterSelected',
    defaults : planTableFilterSelectedStateModel
})

@Injectable()
export class PlanTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store
        ) {
            super();
    }

    @Selector() static get(state: PlanTableFilterSelectedStateModel): any { return state; }


    @Action(UpdatePaginationPlanTableFilterSelected)
    updatePaginationPlanTableFilterSelected(context: StateContext<PlanTableFilterSelectedStateModel>, action: UpdatePaginationPlanTableFilterSelected): void {
        this.loading(context,'filter-selected');

        context.patchState({
            selected: {
                ...context.getState().selected,
                pagination: action.payload
            }
        });

        this.loaded(context,'filter-selected');
    }

    @Action(ChangePlanTableFilterSelected)
    changePlanTableFilterSelected(context: StateContext<PlanTableFilterSelectedStateModel>, action: ChangePlanTableFilterSelected): void {
        this.loading(context,'filter-selected');

        // //chargement des données complémentaire provenant de asi (si idImport est modifié)
        // if(action.payload..idImport!==context.getState().selected.idImport) {
        //     this._asiApiService.getById(action.payload.idImport).subscribe((result)=> {
        //         context.patchState({
        //             selected: {
        //                 ...action.payload,
        //                 asiBankAgencyLabel: result.bankAgency.label,
        //                 asiDateImport: result.dateImport
        //             }
        //         });

        //         this.loaded(context,'filter-selected');
        //     });
        // }
        // else {
        context.patchState({
            selected: action.payload
        });
        this.loaded(context,'filter-selected');
        // }

        this._store.dispatch(new LoadPlanTable(action.payload));
        // this.loading(context,'filter-selected');
        // const state = context.getState();
        // state.selected = action.payload;
        // context.patchState(state);
        // this.loaded(context,'filter-selected');

        // this._store.dispatch(new LoadPlanTable(action.payload));
    }

}
