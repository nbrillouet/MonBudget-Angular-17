import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterPlanFollowUpSelected } from 'app/model/filters/plan-follow-up.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadPlanFollowUp } from '../plan-follow-up.action';
import { ChangePlanFollowUpFilterSelected } from './plan-follow-up-filter-selected.action';

export class PlanFollowUpFilterSelectedStateModel extends FilterSelected<FilterPlanFollowUpSelected> {
    constructor() {
        super(FilterPlanFollowUpSelected);
    }
}

const planFollowUpFilterSelectedStateModel = new PlanFollowUpFilterSelectedStateModel();

@State<PlanFollowUpFilterSelectedStateModel>({
    name: 'PlanFollowUpFilterSelected',
    defaults : planFollowUpFilterSelectedStateModel
})

@Injectable()
export class PlanFollowUpFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store
        ) {
            super();
    }

    @Selector() static get(state: PlanFollowUpFilterSelectedStateModel): any { return state; }

    @Action(ChangePlanFollowUpFilterSelected)
    changePlanFollowUpFilterSelected(context: StateContext<PlanFollowUpFilterSelectedStateModel>, action: ChangePlanFollowUpFilterSelected): void {
        this.loading(context,'filter-selected');

        context.patchState({
            selected: action.payload
        });

        this.loaded(context,'filter-selected');

        if(action.payload.plan && action.payload.user && action.payload.monthYear) {
            this._store.dispatch(new LoadPlanFollowUp(action.payload));
        }

    }

}
