// import { Injectable } from '@angular/core';
// import { Action, Selector, State, StateContext } from '@ngxs/store';
// import { AsChart } from 'app/model/account-statement/as-chart/as-chart.model';
// import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';
// import { Datas } from 'app/model/generics/detail-info.model';
// import { LoaderState } from 'app/state/_base/loader-state';
// import { combineLatest, zip } from 'rxjs';
// import { LoadAsChartCategorisation, LoadAsChartCategorisationDebit, LoadAsChartEvolution, LoadAsChartEvolutionBrut, LoadAsChartEvolutionCustomOtf, LoadAsChartEvolutionCustomOtfFilter, LoadAsChartEvolutionNoIntTransfer, UpdateAsChartEvolutionCustomOtfFilter } from './account-statement-chart.action';


// export class AsChartStateModel extends Datas<AsChart> {
//     constructor() {
//         super();
//         this.datas = new AsChart();
//     }
// }

// const asChartStateModel = new AsChartStateModel();

// @State<AsChartStateModel>({
//     name: 'AsChart',
//     defaults : asChartStateModel
// })

// @Injectable()
// export class AsChartState extends LoaderState {
//     constructor(
//         private _asService: AsService
//         ) {
//             super();
//     }

//     @Selector()
//     static get(state: AsChartStateModel): any {  return state; }

//     @Action(LoadAsChartEvolution)
//     loadAsChartEvolution(context: StateContext<AsChartStateModel>, action: LoadAsChartEvolution): void {
//         this.loading(context,'asChartEvolution');

//         const state = context.getState();
//         context.patchState(state);

//         const a$ = context.dispatch(new LoadAsChartEvolutionBrut(action.payload));
//         const b$ = context.dispatch(new LoadAsChartEvolutionNoIntTransfer(action.payload));
//         const c$ = context.dispatch(new LoadAsChartEvolutionCustomOtfFilter(action.payload));
//         const d$ = context.dispatch(new LoadAsChartEvolutionCustomOtf(action.payload));

//         combineLatest([a$,b$,c$,d$]).subscribe(() => {
//             context.patchState(context.getState());
//         });
//     }


//     @Action(LoadAsChartEvolutionBrut)
//     loadAsChartEvolutionBrut(context: StateContext<AsChartStateModel>, action: LoadAsChartEvolutionBrut): void {
//         this.loading(context,'asChartEvolutionBrut');

//         context.patchState({
//             datas: { ...context.getState().datas, asChartEvolution : { ...context.getState().datas.asChartEvolution, brut: null } }
//         });

//         // const state = context.getState();
//         // state.datas.asChartEvolution.brut.balance= null;
//         // state.datas.asChartEvolution.brut.credit= null;
//         // state.datas.asChartEvolution.brut.debit= null;
//         // context.patchState(state);

//         this._asService.getAsChartEvolutionBrut(action.payload).subscribe((result)=> {
//             context.patchState({
//                 datas: { ...context.getState().datas, asChartEvolution : { ...context.getState().datas.asChartEvolution, brut: result } }
//             });
//                 // let state = context.getState();
//                 // state.datas.asChartEvolution.brut = result;
//                 // context.patchState(state);

//                 this.loaded(context,'asChartEvolutionBrut');
//         });
//     }

//     // @Action(LoadAsChartEvolutionBrutSuccess)
//     // LoadAsChartEvolutionBrutSuccess(context: StateContext<AsChartStateModel>, action: LoadAsChartEvolutionBrutSuccess) {
//     //     let state = context.getState();

//     //     state.datas.asChartEvolution.brut = action.payload;

//     //     context.patchState(state);



//     // }

//     @Action(LoadAsChartEvolutionNoIntTransfer)
//     loadAsChartEvolutionNoIntTransfer(context: StateContext<AsChartStateModel>, action: LoadAsChartEvolutionNoIntTransfer): any {
//         this.loading(context,'asChartEvolutionNoIntTransfer');

//         context.patchState({
//             datas: { ...context.getState().datas, asChartEvolution : { ...context.getState().datas.asChartEvolution, noIntTransfer: null } }
//         });
//         // const state = context.getState();
//         // state.datas.asChartEvolution.noIntTransfer.balance= null;
//         // state.datas.asChartEvolution.noIntTransfer.credit= null;
//         // state.datas.asChartEvolution.noIntTransfer.debit= null;

//         // context.patchState(state);
//         this._asService.getAsChartEvolutionNoIntTransfer(action.payload).subscribe(result=> {
//                 context.patchState({
//                     datas: { ...context.getState().datas, asChartEvolution : { ...context.getState().datas.asChartEvolution, noIntTransfer: result } }
//                 });
//                 // let state = context.getState();
//                 // state.datas.asChartEvolution.noIntTransfer = result;
//                 // context.patchState(state);

//                 this.loaded(context,'asChartEvolutionNoIntTransfer');
//         });
//     }


//     @Action(LoadAsChartEvolutionCustomOtf)
//     loadAsChartEvolutionCustomOtf(context: StateContext<AsChartStateModel>, action: LoadAsChartEvolutionCustomOtf): any {
//         this.loading(context,'asChartEvolutionCustomOtf');

//         context.patchState({
//             datas: { ...context.getState().datas,
//                 asChartEvolution : { ...context.getState().datas.asChartEvolution,
//                     customOtfs : { ...context.getState().datas.asChartEvolution.customOtfs, widgetCardChartBars : null } } }
//         });
//         // const state = context.getState();
//         // state.datas.asChartEvolution.customOtfs.widgetCardChartBars = null;
//         // context.patchState(state);

//         this._asService.getAsChartEvolutionCustomOtf(action.payload)
//             .subscribe((result)=> {
//                 context.patchState({
//                     datas: { ...context.getState().datas,
//                         asChartEvolution : { ...context.getState().datas.asChartEvolution,
//                             customOtfs : { ...context.getState().datas.asChartEvolution.customOtfs, widgetCardChartBars : result } } }
//                 });
//                 // let state = context.getState();
//                 // state.datas.asChartEvolution.customOtfs.widgetCardChartBars = result;
//                 // context.patchState(state);

//                 // this.loaded(context,'asChartEvolutionCustomOtf');

//                 this.loaded(context,'asChartEvolutionCustomOtf');
//             });
//     }


//     @Action(LoadAsChartEvolutionCustomOtfFilter)
//     loadAsChartEvolutionCustomOtfFilter(context: StateContext<AsChartStateModel>, action: LoadAsChartEvolutionCustomOtfFilter): any {
//         this.loading(context,'asChartEvolutionCustomOtfFilter');

//         context.patchState({
//             datas: { ...context.getState().datas,
//                 asChartEvolution : { ...context.getState().datas.asChartEvolution,
//                     customOtfs : { ...context.getState().datas.asChartEvolution.customOtfs, filter : null } } }
//         });
//         // const state = context.getState();
//         // state.datas.asChartEvolution.customOtfs.filter=null;
//         // // state.datas.asChartEvolution.customOtfs.filter.operationTypeFamilies = null;
//         // context.patchState(state);

//         this._asService.getAsChartEvolutionCustomOtfFilter(action.payload)
//             .subscribe((result)=> {

//                 context.patchState({
//                     datas: { ...context.getState().datas,
//                         asChartEvolution : { ...context.getState().datas.asChartEvolution,
//                             customOtfs : { ...context.getState().datas.asChartEvolution.customOtfs, filter : result } } }
//                 });

//                 this.loaded(context,'asChartEvolutionCustomOtfFilter');
//             });
//     }


//     @Action(UpdateAsChartEvolutionCustomOtfFilter)
//     updateAsChartEvolutionCustomOtfFilter(context: StateContext<AsChartStateModel>, action: UpdateAsChartEvolutionCustomOtfFilter): any {

//         this._asService.updateAsChartEvolutionCustomOtfFilter(action.payload)
//             .subscribe(()=> {

//                 const filterAsTableSelected = {
//                     idAccount : action.payload.idAccount,
//                     user: action.payload.user,
//                     monthYear: action.payload.monthYear
//                 } as FilterAsTableSelected;

//                 context.dispatch(new LoadAsChartEvolutionCustomOtfFilter(filterAsTableSelected));
//                 context.dispatch(new LoadAsChartEvolutionCustomOtf(filterAsTableSelected));
//             });
//     }




//     @Action(LoadAsChartCategorisation)
//     loadAsChartCategorisation(context: StateContext<AsChartStateModel>, action: LoadAsChartCategorisation): void {
//         this.loading(context,'asChartCategorisation');

//         const state = context.getState();
//         context.patchState(state);

//         zip(
//             context.dispatch(new LoadAsChartCategorisationDebit(action.payload))
//         ).subscribe(()=>{
//             context.patchState(context.getState());

//             this.loaded(context,'asChartCategorisation');
//         });

//     }


//     @Action(LoadAsChartCategorisationDebit)
//     loadAsChartCategorisationDebit(context: StateContext<AsChartStateModel>, action: LoadAsChartCategorisationDebit): any {
//         this.loading(context,'asChartCategorisationDebit');

//         const state = context.getState();
//         state.datas.asChartCategorisation.debit = null;

//         context.patchState(state);
//         this._asService.GetAsChartCategorisationDebit(action.payload)
//             .subscribe((result)=> {
//                 context.getState().datas.asChartCategorisation.debit = result;
//                 context.patchState(state);

//                 this.loaded(context,'asChartCategorisationDebit');
//             });

//     }


// }
