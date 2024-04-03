import { Injectable } from '@angular/core';
import { FilterSelection } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterPlanFollowUpSelection } from 'app/model/filters/plan-follow-up.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { PlanApiService } from '../../plan.api.service';
import { LoadPlanFollowUpFilterSelection } from './plan-follow-up-filter-selection.action';

export class PlanFollowUpFilterSelectionStateModel extends FilterSelection<FilterPlanFollowUpSelection> {
    constructor() {
        super(FilterPlanFollowUpSelection);
    }
}

const planFollowUpFilterSelectionStateModel = new PlanFollowUpFilterSelectionStateModel();

@State<PlanFollowUpFilterSelectionStateModel>({
    name: 'PlanFollowUpFilterSelection',
    defaults : planFollowUpFilterSelectionStateModel
})

@Injectable()
export class PlanFollowUpFilterSelectionState extends LoaderState {

    constructor(
        private _planApiService: PlanApiService
        ) {
            super();
    }

    @Selector() static get(state: PlanFollowUpFilterSelectionStateModel): any { return state; }

    @Action(LoadPlanFollowUpFilterSelection)
    loadPlanFollowUpFilterSelection(context: StateContext<PlanFollowUpFilterSelectionStateModel>, action: LoadPlanFollowUpFilterSelection): any {
        this.loading(context,'filter-selection');

        context.patchState({
            selection: null
        });

        this._planApiService.getPlanFollowUpFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'filter-selection');}))
            .subscribe((result)=> {
                context.patchState({
                    selection: result
                });
            });
    }
}
