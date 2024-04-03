import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { AsChartEvolution } from 'app/model/account-statement/as-chart/as-chart-evolution.model';
import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { combineLatest, finalize, forkJoin } from 'rxjs';
import { AsApiService } from '../../as-api.service';
import { ChangeAsChartEvolutionCustomOtfFilter, LoadAsChartEvolution, LoadAsChartEvolutionBrut, LoadAsChartEvolutionCustomOtf, LoadAsChartEvolutionNoIntTransfer, UpdateAsChartEvolutionCustomOtfFilter } from './as-chart-evolution.action';

export class AsChartEvolutionStateModel extends Datas<AsChartEvolution> {
    constructor() {
        super();
        this.datas = new AsChartEvolution();
    }
}

const asChartEvolutionStateModel = new AsChartEvolutionStateModel();

@State<AsChartEvolutionStateModel>({
    name: 'AsChartEvolution',
    defaults : asChartEvolutionStateModel
})

@Injectable()
export class AsChartEvolutionState extends LoaderState {
    constructor(
        private _asApiService: AsApiService
        ) {
            super();
    }

    @Selector()
    static get(state: AsChartEvolutionStateModel): any {  return state; }

    @Action(LoadAsChartEvolution)
    loadAsChartEvolution(context: StateContext<AsChartEvolutionStateModel>, action: LoadAsChartEvolution): void {
        this.loading(context,'asChartEvolution');

        const state = context.getState();
        context.patchState(state);

        const a$ = context.dispatch(new LoadAsChartEvolutionBrut(action.payload));
        const b$ = context.dispatch(new LoadAsChartEvolutionNoIntTransfer(action.payload));
        const d$ = context.dispatch(new LoadAsChartEvolutionCustomOtf(action.payload));
        const c$ = context.dispatch(new ChangeAsChartEvolutionCustomOtfFilter(action.payload));

        forkJoin([a$,b$,d$]).subscribe(() => {
            context.patchState(context.getState());
        });
    }


    @Action(LoadAsChartEvolutionBrut)
    loadAsChartEvolutionBrut(context: StateContext<AsChartEvolutionStateModel>, action: LoadAsChartEvolutionBrut): void {
        this.loading(context,'asChartEvolutionBrut');

        context.patchState({
            datas: {
                ...context.getState().datas,
                brut: null
            }
        });

        this._asApiService
            .getAsChartEvolutionBrut(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'asChartEvolutionBrut');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: {
                        ...context.getState().datas,
                        brut: result
                    }
                });
            });
    }

    @Action(LoadAsChartEvolutionNoIntTransfer)
    loadAsChartEvolutionNoIntTransfer(context: StateContext<AsChartEvolutionStateModel>, action: LoadAsChartEvolutionNoIntTransfer): any {
        this.loading(context,'asChartEvolutionNoIntTransfer');

        context.patchState({
            datas: {
                ...context.getState().datas,
                noIntTransfer: null
            }
        });

        this._asApiService
            .getAsChartEvolutionNoIntTransfer(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'asChartEvolutionNoIntTransfer');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: {
                        ...context.getState().datas,
                        noIntTransfer: result
                    }
                });
            });
    }


    @Action(LoadAsChartEvolutionCustomOtf)
    loadAsChartEvolutionCustomOtf(context: StateContext<AsChartEvolutionStateModel>, action: LoadAsChartEvolutionCustomOtf): any {
        this.loading(context,'asChartEvolutionCustomOtf');

        context.patchState({
            datas: {
                ...context.getState().datas,
                customOtfs: {
                    ...context.getState().datas.customOtfs,
                    widgetCardChartBars : null
                }
            }
        });

        this._asApiService
            .getAsChartEvolutionCustomOtf(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'asChartEvolutionCustomOtf');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: {
                        ...context.getState().datas,
                        customOtfs: {
                            ...context.getState().datas.customOtfs,
                            widgetCardChartBars : result
                        }
                    }
                });
            });
    }


    @Action(ChangeAsChartEvolutionCustomOtfFilter)
    changeAsChartEvolutionCustomOtfFilter(context: StateContext<AsChartEvolutionStateModel>, action: ChangeAsChartEvolutionCustomOtfFilter): any {
        this.loading(context,'asChartEvolutionCustomOtfFilter');

        context.patchState({
            datas: {
                ...context.getState().datas,
                customOtfs: {
                    ...context.getState().datas.customOtfs,
                    filter : null
                }
            }
        });

        this._asApiService
            .getAsChartEvolutionCustomOtfFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'asChartEvolutionCustomOtfFilter');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: {
                        ...context.getState().datas,
                        customOtfs: {
                            ...context.getState().datas.customOtfs,
                            filter : result
                        }
                    }
                });
            });
    }


    @Action(UpdateAsChartEvolutionCustomOtfFilter)
    updateAsChartEvolutionCustomOtfFilter(context: StateContext<AsChartEvolutionStateModel>, action: UpdateAsChartEvolutionCustomOtfFilter): any {

        this._asApiService
            .updateAsChartEvolutionCustomOtfFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'as-chart-evolution-custom-otf-filter-update');}))
            .subscribe(()=> {

                const filterAsTableSelected = {
                    idAccount : action.payload.idAccount,
                    user: action.payload.user,
                    monthYear: action.payload.monthYear
                } as FilterAsTableSelected;

                context.dispatch(new ChangeAsChartEvolutionCustomOtfFilter(filterAsTableSelected));
                context.dispatch(new LoadAsChartEvolutionCustomOtf(filterAsTableSelected));
            });
    }
}
