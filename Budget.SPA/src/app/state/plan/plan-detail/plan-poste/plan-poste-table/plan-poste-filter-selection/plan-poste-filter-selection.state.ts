/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { FilterSelection } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterPlanPosteTableSelection } from 'app/model/filters/plan-poste.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs/operators';
import { PlanPosteApiService } from '../../plan-poste.api.service';
import { LoadPlanPosteTableFilterSelection } from './plan-poste-filter-selection.action';

export class PlanPosteTableFilterSelectionStateModel extends FilterSelection<FilterPlanPosteTableSelection> {
    constructor() {
        super(FilterPlanPosteTableSelection);
    }
}

const planPosteTableFilterSelectionStateModel = new PlanPosteTableFilterSelectionStateModel();

@State<PlanPosteTableFilterSelectionStateModel>({
    name: 'PlanPosteTableFilterSelection',
    defaults : planPosteTableFilterSelectionStateModel
})

@Injectable()
export class PlanPosteTableFilterSelectionState extends LoaderState {

    constructor(
        private _planPosteApiService: PlanPosteApiService
        ) {
            super();
    }

    @Selector() static get(state: PlanPosteTableFilterSelectionStateModel): any { return state; }

    @Action(LoadPlanPosteTableFilterSelection)
    loadPlanPosteTableFilterSelection(context: StateContext<PlanPosteTableFilterSelectionStateModel>, action: LoadPlanPosteTableFilterSelection): void {
        this.loading(context,'filter-selection');

        context.patchState({
            selection: null
        });

        this._planPosteApiService.getPlanPosteTableFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'filter-selection');}))
            .subscribe((result)=> {
                context.patchState({
                    selection: result
                });
            });
    }

}
