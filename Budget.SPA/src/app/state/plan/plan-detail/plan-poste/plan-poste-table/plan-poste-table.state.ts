/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { PlanPosteForTable } from 'app/model/plan/plan-poste/plan-poste.model';

import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs/operators';
import { PlanPosteApiService } from '../plan-poste.api.service';
import { ChangePlanPosteTableFilterSelected, UpdatePaginationPlanPosteTableFilterSelected } from './plan-poste-filter-selected/plan-poste-filter-selected.action';
import { ClearPlanPosteTable, DeletePlanPosteTable, LoadPlanPosteTable } from './plan-poste-table.action';

export class PlanPosteTableStateModel extends Datas<PlanPosteForTable[]> {
    constructor() {
        super();
    }
}

const tableInfo = new PlanPosteTableStateModel();
@State<PlanPosteTableStateModel>({
    name: 'PlanPosteTable',
    defaults : tableInfo
})

@Injectable()
export class PlanPosteTableState extends LoaderState {
    constructor(
        private _planPosteApiService: PlanPosteApiService,
        private _store: Store) {
            super();
    }

    @Selector() static get(state: PlanPosteTableStateModel): any { return state; }

    @Action(LoadPlanPosteTable)
    loadPlanPosteTable(context: StateContext<PlanPosteTableStateModel>, action: LoadPlanPosteTable): any {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._planPosteApiService.getPlanPosteTable(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: result.datas
                });

                this._store.dispatch(new UpdatePaginationPlanPosteTableFilterSelected(result.pagination));
            });
    }

    @Action(DeletePlanPosteTable)
    deletePlanPosteTable(context: StateContext<PlanPosteTableStateModel>, action: DeletePlanPosteTable): any {
        this.loading(context,'datas-delete');

        this._planPosteApiService.deletePlanPosteTable(action.payload.idPlanPosteList)
            .pipe(finalize(()=> {this.loaded(context,'datas-delete');}))
            .subscribe((result)=> {
                this._store.dispatch(new ChangePlanPosteTableFilterSelected(action.payload.filterSelected));
            });
    }

    @Action(ClearPlanPosteTable)
    clearPlanPosteTable(context: StateContext<PlanPosteTableStateModel>): void {
        context.setState(new PlanPosteTableStateModel());
    }
}
