/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { PlanForTable } from 'app/model/plan/plan.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { PlanApiService } from '../plan.api.service';
import { UpdatePaginationPlanTableFilterSelected } from './plan-table-filter-selected/plan-table-filter-selected.action';
import { ClearPlanTable, LoadPlanTable } from './plan-table.action';

export class PlanTableStateModel extends Datas<PlanForTable[]> {
    constructor() {
        super();
    }
}

const tableInfo = new PlanTableStateModel();
@State<PlanTableStateModel>({
    name: 'PlanTable',
    defaults : tableInfo
})

@Injectable()
export class PlanTableState extends LoaderState {
    constructor(
        private _planApiService: PlanApiService,
        private _store: Store) {
            super();
    }

    @Selector() static get(state: PlanTableStateModel): any { return state; }

    @Action(LoadPlanTable)
    loadPlanTable(context: StateContext<PlanTableStateModel>, action: LoadPlanTable): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._planApiService.getPlanTable(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: result.datas
                });

                this._store.dispatch(new UpdatePaginationPlanTableFilterSelected(result.pagination));
            });
    }

    @Action(ClearPlanTable)
    clearPlanTable(context: StateContext<PlanTableStateModel>): void {
        context.setState(new PlanTableStateModel());
    }
}
