import { Injectable } from '@angular/core';
import { DetailFormInfo, FilterForDetail, Select } from '@corporate/model';
import { UpdateFormValue } from '@ngxs/form-plugin';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
import { EnumOperationMethod } from 'app/model/enum/enum-operation-model.model';
import { EnumOperationPlace } from 'app/model/enum/enum-operation-place.enum';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AsApiService } from '../as-api.service';
import { LoadAsDetailFilter } from './as-detail-filter/as-detail-filter.action';
import { AsDetailChangeOperation, AsDetailChangeOperationDetail, AsDetailChangeOperationDetailOperationPlace, AsDetailChangeOperationTransverse, AsDetailChangeOt, AsDetailChangeOtf, LoadAsDetail, SaveAsDetail } from './as-detail.action';
import { ToastrService } from 'ngx-toastr';

export class AsDetailStateModel extends DetailFormInfo<AsForDetail, FilterForDetail> {
    constructor() {
        super();
        this.filter = new FilterForDetail();
    }
}

const detailInfo = new AsDetailStateModel();
@State<AsDetailStateModel>({
    name: 'asDetail',
    defaults : detailInfo
})

@Injectable()
export class AsDetailState extends LoaderState {
    constructor(
        private _toastrService: ToastrService,
        private _asApiService: AsApiService,
        private _store: Store,
        private _helperService: HelperService
    )
    {
        super();

    }

    @Selector() static get(state: AsDetailStateModel): any { return state;  }
    @Selector() static getFilter(state: AsDetailStateModel): any { return state.filter; }

    @Action(LoadAsDetail)
    loadAsDetail(context: StateContext<AsDetailStateModel>, action: LoadAsDetail): void {

        this.loading(context,'datas');

        context.patchState({
            filter: action.payload,
            model: null
        });

        this._asApiService.getForDetail(action.payload).subscribe((result)=> {
            context.patchState({
                model: result
            });
            this.loaded(context,'datas');

            //chargement des filtres associés
            context.dispatch(new LoadAsDetailFilter(result));
        });
    }

    @Action(SaveAsDetail)
    saveAsDetail(context: StateContext<AsDetailStateModel>, action: SaveAsDetail): void {

        this.loading(context,'datas-save');

        this._asApiService.saveAsDetail(action.payload.asDetail)
            .pipe(finalize(()=> {this.loaded(context,'datas-save');}))
            .subscribe((result)=> {
                this._store.dispatch(
                    new UpdateFormValue({
                        path:'asDetail',
                        value: result
                    })
                );
                this._toastrService.success('Relevé enregistré avec succès!', 'Ajout relevé bancaire');
            });
    }

    @Action(AsDetailChangeOperationDetail)
    asDetailChangeOperationDetail(context: StateContext<AsDetailStateModel>, action: AsDetailChangeOperationDetail): void {

        this.loading(context,'datas');

        this._store.dispatch(
            new UpdateFormValue({
                path:'asDetail',
                value: {
                    operationDetail: action.payload
                }
            })
        );

        this.loaded(context,'datas');
    }

    @Action(AsDetailChangeOperation)
    asDetailChangeOperation(context: StateContext<AsDetailStateModel>, action: AsDetailChangeOperation): void {

        this.loading(context,'operation-change');

        this._store.dispatch(
            new UpdateFormValue({
                path:'asDetail',
                value: {
                    operation:action.payload.operation
                }
            })
        );

        this.loaded(context,'operation-change');
    }

    @Action(AsDetailChangeOtf)
    asDetailChangeOtf(context: StateContext<AsDetailStateModel>, action: AsDetailChangeOtf): void {

        this.loading(context,'otf-change');

        this._store.dispatch(
            new UpdateFormValue({
                path:'asDetail',
                value: {
                    operationTypeFamily: action.payload.otf
                }
            })
        );

        this.loaded(context,'otf-change');
    }

    @Action(AsDetailChangeOt)
    asDetailChangeOt(context: StateContext<AsDetailStateModel>, action: AsDetailChangeOt): void {

        this.loading(context,'ot-change');

        this._store.dispatch(
            new UpdateFormValue({
                path:'asDetail',
                value: {
                    operationType: action.payload.ot
                }
            })
        );

        this.loaded(context,'ot-change');
    }

    @Action(AsDetailChangeOperationTransverse)
    asDetailChangeOperationTransverse(context: StateContext<AsDetailStateModel>, action: AsDetailChangeOperationTransverse): void {

        this.loading(context,'operation-transverse-change');

        const select = {id: action.payload.id, label: action.payload.label} as Select;
        const selected = this._helperService.getDeepClone(context.getState().model.operationTransverse) as Select[];
        selected.push(select);

        this._store.dispatch(
            new UpdateFormValue({
                path:'asDetail',
                value: {
                    operationTransverse: selected
                }
            })
        );

        this.loaded(context,'operation-transverse-change');
    }

    @Action(AsDetailChangeOperationDetailOperationPlace)
    asDetailChangeOperationDetailOperationPlace(context: StateContext<AsDetailStateModel>, action: AsDetailChangeOperationDetailOperationPlace): void {

        this.loading(context,'operation-detail-operation-place-change');

        if(action.payload.operationPlace && action.payload.operationMethod) {

            if(action.payload.operationMethod.id === EnumOperationMethod.paiementCarte || action.payload.operationMethod.id === EnumOperationMethod.retraitCarte) {
                //select doit etre geo ou internet
                if(action.payload.operationPlace?.id === EnumOperationPlace.na){
                    action.payload.operationPlace = null;
                }
            }
            else {
                action.payload.operationPlace = { id: EnumOperationPlace.na, code: 'NA',label: EnumOperationPlace.na.toString() };
            }
            this._store.dispatch(
                new UpdateFormValue({
                    path:'asDetail',
                    value:
                    {
                        operationDetail: {
                            operationPlace: action.payload.operationPlace
                        }
                    }
                })
            );
        }

        this.loaded(context,'operation-detail-operation-place-change');
    }
}

// /* eslint-disable @typescript-eslint/no-shadow */
// import { Injectable } from '@angular/core';
// import { Action, Selector, State, StateContext } from '@ngxs/store';
// import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
// import { FilterForDetail } from 'app/model/filters/shared/filterDetail.filter';
// import { DetailInfo } from 'app/model/generics/detail-info.model';
// import { LoaderState } from 'app/state/_base/loader-state';
// import { LoadAsDetailFilter } from './as-detail-filter/as-detail-filter.action';
// import { ClearAsDetail, LoadAsDetail, SynchronizeAsDetail } from './as-detail.action';

// export class AsDetailStateModel extends DetailInfo<AsForDetail, FilterForDetail> {
//     constructor () {
//         super();
//         this.filter = new FilterForDetail();
//     }
// }

// const detailInfo = new AsDetailStateModel();
// @State<AsDetailStateModel>({
//     name: 'AsDetail',
//     defaults : detailInfo
// })
// @Injectable()
// export class AsDetailState extends LoaderState {
//     constructor(
//         private _asService: AsService
//     )
//     {
//         super();

//     }

//     //fonction delay (test asynchro)
//     // async delay(ms: number) {
//     //     await new Promise(resolve => setTimeout(()=>resolve(), ms)).then(()=>console.log("fired"));
//     // }

//     @Selector() static get(state: AsDetailStateModel): any { return state;  }
//     @Selector() static getFilter(state: AsDetailStateModel): any { return state.filter; }

//     @Action(LoadAsDetail)
//     loadAsDetail(context: StateContext<AsDetailStateModel>, action: LoadAsDetail): void {

//         this.loading(context,'datas');
//         const state = context.getState();

//         state.filter = action.payload;
//         state.datas = null;

//         context.patchState(state);

//         this._asService.getForDetail(action.payload)
//             .subscribe((result)=> {
//                 const state = context.getState();
//                 state.datas = result;
//                 context.patchState(state);

//                 this.loaded(context,'datas');

//                 //chargement des filtres associés
//                 context.dispatch(new LoadAsDetailFilter(state.datas));
//             });
//     }

//     @Action(SynchronizeAsDetail)
//     synchronizeAsDetail(context: StateContext<AsDetailStateModel>, action: SynchronizeAsDetail): void {
//         const state = context.getState();
//         context.patchState(state);
//     }

//     @Action(ClearAsDetail)
//     clearAsDetail(context: StateContext<AsDetailStateModel>): void {
//         context.setState(new AsDetailStateModel());
//     }
// }
