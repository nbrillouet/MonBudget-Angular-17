import { Injectable } from '@angular/core';
import { DatasFilter } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { AsForTable } from 'app/model/account-statement/account-statement-table.model';
import { PlanFollowUpAmountRealFilter } from 'app/model/filters/plan-follow-up-amount-real.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { PlanApiService } from '../../plan.api.service';
import { ChangePlanFollowUpAmountRealFilter, LoadPlanFollowUpAmountReal } from './plan-follow-up-amount-real.action';

export class PlanFollowUpAmountRealStateModel extends DatasFilter<AsForTable[], PlanFollowUpAmountRealFilter> {
    constructor() {
        super();
        this.filter = null;
    }
}

const planFollowUpAmountRealStateModel = new PlanFollowUpAmountRealStateModel();
@State<PlanFollowUpAmountRealStateModel>({
    name: 'PlanFollowUpAmountReal',
    defaults : planFollowUpAmountRealStateModel
})

@Injectable()
export class PlanFollowUpAmountRealState extends LoaderState{
    constructor(
        private _planApiService: PlanApiService) {
            super();
    }

    @Selector()
    static get(state: PlanFollowUpAmountRealStateModel): any { return state; }

    @Selector()
    static getFilter(state: PlanFollowUpAmountRealStateModel): any {
        return state.filter;
    }

    @Action(ChangePlanFollowUpAmountRealFilter)
    changePlanFollowUpAmountRealFilter(context: StateContext<PlanFollowUpAmountRealStateModel>, action: ChangePlanFollowUpAmountRealFilter): void {

        context.patchState({
            filter: action.payload
        });

        context.dispatch(new LoadPlanFollowUpAmountReal(action.payload));
    }

    @Action(LoadPlanFollowUpAmountReal)
    loadPlanFollowUpAmountReal(context: StateContext<PlanFollowUpAmountRealStateModel>, action: LoadPlanFollowUpAmountReal): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        if(action.payload.idPlan && action.payload.idPlanPoste && action.payload.idPoste && action.payload.monthYear) {
            this._planApiService.getPlanFollowUpAmountReal(action.payload)
                .pipe(finalize(()=> {this.loaded(context,'datas');}))
                .subscribe((result)=> {
                    context.patchState({
                        datas: result
                    });

                    // this._store.dispatch(new UpdatePaginationPlanTableFilterSelected(result.pagination));
                });
        }



        // this.loading(context,'datas');

        // const state = context.getState();
        // state.filter = action.payload;
        // state.datas = null;
        // context.patchState(state);

        // this._planApiService.getPlanAmountTable(action.payload).subscribe((result)=> {
        //     const state = context.getState();
        //     state.datas = result;
        //     context.patchState(state);

        //     this.loaded(context,'datas');
        // });
    }

}
