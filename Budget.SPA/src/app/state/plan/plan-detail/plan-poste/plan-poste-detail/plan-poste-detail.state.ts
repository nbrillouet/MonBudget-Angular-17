/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { DatasFilter, DetailFormInfo } from '@corporate/model';
import { UpdateFormValue } from '@ngxs/form-plugin';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { PlanPosteDetailFilter } from 'app/model/filters/plan-poste.filter';
import { PlanPosteForDetail } from 'app/model/plan/plan-poste/plan-poste.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs/operators';
import { PlanPosteApiService } from '../plan-poste.api.service';
import { LoadPlanPosteDetailFilter } from './plan-poste-detail-filter/plan-poste-detail-filter.action';
import { ChangePlanPostePlanPosteReference, ClearPlanPosteDetail, LoadPlanPosteDetail, SavePlanPosteDetail } from './plan-poste-detail.action';

export class PlanPosteDetailStateModel extends DetailFormInfo<PlanPosteForDetail, PlanPosteDetailFilter> {

    constructor() {
        super();
        this.filter = new PlanPosteDetailFilter();
    }
}

const detailInfo = new PlanPosteDetailStateModel();
@State<PlanPosteDetailStateModel>({
    name: 'planPosteDetail',
    defaults : detailInfo
})

@Injectable()
export class PlanPosteDetailState extends LoaderState {
    constructor(
        private _planPosteApiService: PlanPosteApiService,
        private _store: Store) {
            super();
    }

    @Selector() static get(state: PlanPosteDetailStateModel): any { return state; }

    @Selector() static getFilter(state: PlanPosteDetailStateModel): any { return state.filter; }

    @Action(LoadPlanPosteDetail)
    loadPlanPosteDetail(context: StateContext<PlanPosteDetailStateModel>, action: LoadPlanPosteDetail): void {

        this.loading(context,'datas');

        context.patchState({
            filter: action.payload,
            model: null
        });

        this._planPosteApiService.getPlanPosteForDetail(action.payload.id, action.payload.idPlan, action.payload.idPoste)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                  context.patchState({
                    filter: action.payload,
                    model: result
                });

                //chargement des filtres associés
                context.dispatch(new LoadPlanPosteDetailFilter({idUserGroup: action.payload.idUserGroup, planPosteForDetail:  result }));
            });
    }

    @Action(SavePlanPosteDetail)
    savePlanPosteDetail(context: StateContext<PlanPosteDetailStateModel>, action: SavePlanPosteDetail): void {
        this.loading(context, 'datas-save');

        this._planPosteApiService.savePlanPosteDetail(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas-save');}))
            .subscribe((result: PlanPosteForDetail) => {
                this._store.dispatch(new UpdateFormValue({
                    path:'planPosteDetail',
                    value: result
                }));
            });

    }

    @Action(ClearPlanPosteDetail)
    clearPlanPosteDetail(context: StateContext<PlanPosteDetailStateModel>): any {
        return context.setState(new PlanPosteDetailStateModel());
    }

    //====================================
    //          PlanPosteReference
    //====================================
    @Action(ChangePlanPostePlanPosteReference)
    changePlanPostePlanPosteReference(context: StateContext<PlanPosteDetailStateModel>, action: ChangePlanPostePlanPosteReference): void {

        this.loading(context,'plan-poste-plan-poste-reference-change');

        this._store.dispatch(
            new UpdateFormValue({
                path:'planPosteDetail',
                value: {
                    planPosteReference: action.payload
                }
            })
        );

        this.loaded(context,'plan-poste-plan-poste-reference-change');
    }

}
