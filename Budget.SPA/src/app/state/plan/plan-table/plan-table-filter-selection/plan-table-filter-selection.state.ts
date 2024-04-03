/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { FilterSelection } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterPlanTableSelection } from 'app/model/filters/plan.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { PlanApiService } from '../../plan.api.service';
import { LoadPlanTableFilterSelection } from './plan-table-filter-selection.action';


export class PlanTableFilterSelectionStateModel extends FilterSelection<FilterPlanTableSelection> {
    constructor() {
        super(FilterPlanTableSelection);
    }
}

const planTableFilterSelectionStateModel = new PlanTableFilterSelectionStateModel();

@State<PlanTableFilterSelectionStateModel>({
    name: 'PlanTableFilterSelection',
    defaults : planTableFilterSelectionStateModel
})

@Injectable()
export class PlanTableFilterSelectionState extends LoaderState {

    constructor(
        private _planApiService: PlanApiService
        ) {
            super();
    }

    @Selector() static get(state: PlanTableFilterSelectionStateModel): any { return state; }

    @Action(LoadPlanTableFilterSelection)
    loadPlanTableFilterSelection(context: StateContext<PlanTableFilterSelectionStateModel>, action: LoadPlanTableFilterSelection): any {
        this.loading(context,'filter-selection');

        context.patchState({
            selection: null
        });

        this._planApiService.getPlanTableFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'filter-selection');}))
            .subscribe((result)=> {
                context.patchState({
                    selection: result
                });
            });
    }
}
