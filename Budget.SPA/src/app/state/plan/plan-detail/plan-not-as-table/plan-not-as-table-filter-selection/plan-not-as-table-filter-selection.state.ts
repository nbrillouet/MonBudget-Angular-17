/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { FilterSelection } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterPlanNotAsTableSelection } from 'app/model/filters/plan-not-as.filter';
import { PlanApiService } from 'app/state/plan/plan.api.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { ChangePlanNotAsTableFilterSelection } from './plan-not-as-table-filter-selection.action';

export class PlanNotAsTableFilterSelectionStateModel extends FilterSelection<FilterPlanNotAsTableSelection> {
    constructor() {
        super(FilterPlanNotAsTableSelection);
    }
}

const planNotAsTableFilterSelectionStateModel = new PlanNotAsTableFilterSelectionStateModel();

@State<PlanNotAsTableFilterSelectionStateModel>({
    name: 'PlanNotAsTableFilterSelection',
    defaults : planNotAsTableFilterSelectionStateModel
})

@Injectable()
export class PlanNotAsTableFilterSelectionState extends LoaderState {

    constructor(
        // private _asApiService: AsApiService,
        private _planApiService: PlanApiService,
        private _store: Store
        ) {
            super();
    }

    @Selector() static get(state: PlanNotAsTableFilterSelectionStateModel): any { return state; }

    @Action(ChangePlanNotAsTableFilterSelection)
    changePlanNotAsTableFilterSelection(context: StateContext<PlanNotAsTableFilterSelectionStateModel>, action: ChangePlanNotAsTableFilterSelection): void {
        this.loading(context,'filter-selection');

        context.patchState({
            selection: null
        });

        if(action.payload.user) {
            this._planApiService.getPlanNotAsTableFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'filter-selection');}))
            .subscribe((result) => {
                    context.patchState({
                        selection: result
                    });
                    // //initialisation du selected apres remplissage selection
                    // if(!action.payload.monthYear.year) {
                    //     action.payload.monthYear = {month: res.month[0], year: res.year[0]};

                    // }
                }
            );
        }

    }

}
