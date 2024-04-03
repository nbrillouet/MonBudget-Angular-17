/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { PlanNotAsTable } from 'app/model/plan/plan-not-as/plan-not-as.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { PlanApiService } from '../../plan.api.service';
import { ChangePlanNotAsTableFilterSelectedPagination } from './plan-not-as-table-filter-selected/plan-not-as-table-filter-selected.action';
import { ChangePlanNotAsTable, ClearPlanNotAsTable } from './plan-not-as-table.action';

export class PlanNotAsTableStateModel extends Datas<PlanNotAsTable[]> {
    constructor() {
        super();
    }
}

const tableInfo = new PlanNotAsTableStateModel();
@State<PlanNotAsTableStateModel>({
    name: 'PlanNotAsTable',
    defaults : tableInfo
})

@Injectable()
export class PlanNotAsTableState extends LoaderState {
    constructor(
        private _planApiService: PlanApiService,
        private _store: Store) {
            super();
    }

    @Selector() static get(state: PlanNotAsTableStateModel): any { return state; }

    @Action(ChangePlanNotAsTable)
    changePlanNotAsTable(context: StateContext<PlanNotAsTableStateModel>, action: ChangePlanNotAsTable): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._planApiService.getPlanNotAsTable(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: result.datas
                });
                this._store.dispatch(new ChangePlanNotAsTableFilterSelectedPagination(result.pagination));
            });


        // const state = context.getState();
        // state.datas = null;
        // context.patchState(state);

        // this._planService.getPlanNotAsTable(action.payload)
        //     .subscribe((result)=> {
        //         const state = context.getState();
        //         state.datas = result.datas;
        //         context.patchState(state);

        //         this._store.dispatch(new UpdatePaginationPlanNotAsTableFilterSelected(result.pagination));

        //         this.loaded(context,'datas');
        //     });
    }

    @Action(ClearPlanNotAsTable)
    clearPlanNotAsTable(context: StateContext<PlanNotAsTableStateModel>): void {
        context.setState(new PlanNotAsTableStateModel());
    }
}

