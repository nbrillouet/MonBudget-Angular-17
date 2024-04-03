import { Injectable } from '@angular/core';
import { Datas, DatasFilter } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { PlanForFollowUp } from 'app/model/plan/plan-follow-up/plan-follow-up.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { PlanApiService } from '../plan.api.service';
import { LoadPlanFollowUp } from './plan-follow-up.action';

export class PlanFollowUpStateModel extends Datas<PlanForFollowUp> {

    constructor() {
        super();
        // this.filter = new FilterPlanFollowUp();
    }

}

const detailInfo = new PlanFollowUpStateModel();
@State<PlanFollowUpStateModel>({
    name: 'PlanFollowUp',
    defaults : detailInfo
})

@Injectable()
export class PlanFollowUpState extends LoaderState {
    constructor(
        private _planApiService: PlanApiService) {
            super();
    }

    @Selector() static get(state: PlanFollowUpStateModel): any { return state; }

    @Action(LoadPlanFollowUp)
    loadPlanFollowUp(context: StateContext<PlanFollowUpStateModel>, action: LoadPlanFollowUp): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        if(action.payload.monthYear && action.payload.plan && action.payload.user) {
            this._planApiService.getPlanFollowUp(action.payload)
                .pipe(finalize(()=> {this.loaded(context,'datas');}))
                .subscribe((result)=> {
                    context.patchState({
                        datas: result
                    });

                    // this._store.dispatch(new UpdatePaginationPlanTableFilterSelected(result.pagination));
                });
        }
    }

}
