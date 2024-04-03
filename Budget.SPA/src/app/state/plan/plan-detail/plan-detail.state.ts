/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { DetailFormInfo, FilterForDetail } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { PlanForDetail } from 'app/model/plan/plan.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { PlanApiService } from '../plan.api.service';
import { ChangePlanDetailFilter, ClearPlanDetail, LoadPlanDetail, SavePlanDetail } from './plan-detail.action';
import { UpdateFormValue } from '@ngxs/form-plugin';

export class PlanDetailStateModel extends DetailFormInfo<PlanForDetail, FilterForDetail> {

    constructor() {
        super();
        this.filter = new FilterForDetail();
    }
}

const detailInfo = new PlanDetailStateModel();
@State<PlanDetailStateModel>({
    name: 'planDetail',
    defaults : detailInfo
})

@Injectable()
export class PlanDetailState extends LoaderState {

    constructor(
        private _authService: AuthService,
        private _store: Store,
        private _planApiService: PlanApiService) {
        super();
    }

    @Selector() static get(state: PlanDetailStateModel): any { return state; }

    @Selector() static getFilter(state: PlanDetailStateModel): any { return state.filter; }

    @Action(LoadPlanDetail)
    loadPlanDetail(context: StateContext<PlanDetailStateModel>, action: LoadPlanDetail): void {
        this.loading(context,'datas');

        context.patchState({
            filter: action.payload,
            model: null
        });

        this._planApiService.getForDetailById(this._authService.user.id, action.payload.id)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                context.patchState({
                    model: result
                });
            });
    }

    @Action(SavePlanDetail)
    savePlanDetail(context: StateContext<PlanDetailStateModel>, action: SavePlanDetail): void {
        this.loading(context, 'datas-save');

        this._planApiService.savePlanDetail(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas-save');}))
            .subscribe((result) => {
                this._store.dispatch(new UpdateFormValue({
                    path:'planDetail',
                    value: result
                }));
            });

    }

    @Action(ChangePlanDetailFilter)
    changePlanDetailFilter(context: StateContext<PlanDetailStateModel>, action: ChangePlanDetailFilter): void {
        const state = context.getState();
        state.filter=action.payload;

        context.patchState(state);
        context.dispatch(new LoadPlanDetail(action.payload));
    }

    @Action(ClearPlanDetail)
    clearPlanDetail(context: StateContext<PlanDetailStateModel>): void {
        context.setState(new PlanDetailStateModel());
    }
}
