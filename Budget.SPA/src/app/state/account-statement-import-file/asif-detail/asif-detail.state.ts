/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { DetailFormInfo, FilterForDetail, Select } from '@corporate/model';
import { UpdateFormValue } from '@ngxs/form-plugin';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { AsifForDetail } from 'app/model/account-statement-import/account-statement-import-file.model';
import { EnumOperationMethod } from 'app/model/enum/enum-operation-model.model';
import { EnumOperationPlace } from 'app/model/enum/enum-operation-place.enum';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AsifApiService } from '../asif.api.service';
import { LoadAsifDetailFilter } from './asif-detail-filter/asif-detail-filter.action';
import { AsifDetailChangeOperation, AsifDetailChangeOperationDetail, AsifDetailChangeOperationDetailOperationPlace, AsifDetailChangeOperationTransverse, AsifDetailChangeOt, AsifDetailChangeOtf, LoadAsifDetail, SaveAsifDetail } from './asif-detail.action';
import { ToastrService } from 'ngx-toastr';


export class AsifDetailStateModel extends DetailFormInfo<AsifForDetail, FilterForDetail> {
    constructor() {
        super();
        this.filter = new FilterForDetail();
    }
}

const detailInfo = new AsifDetailStateModel();
@State<AsifDetailStateModel>({
    name: 'asifDetail',
    defaults : detailInfo
})

@Injectable()
export class AsifDetailState extends LoaderState {
    constructor(
        private _toastrService: ToastrService,
        private _asifApiService: AsifApiService,
        private _store: Store,
        private _helperService: HelperService
    )
    {
        super();

    }

    @Selector() static get(state: AsifDetailStateModel): any { return state;  }
    @Selector() static getFilter(state: AsifDetailStateModel): any { return state.filter; }

    @Action(LoadAsifDetail)
    loadAsifDetail(context: StateContext<AsifDetailStateModel>, action: LoadAsifDetail): void {

        this.loading(context,'datas');

        context.patchState({
            filter: action.payload,
            model: null
        });

        this._asifApiService.getForDetail(action.payload).subscribe((result)=> {
            context.patchState({
                model: result
            });
            this.loaded(context,'datas');

            //chargement des filtres associés
            context.dispatch(new LoadAsifDetailFilter(result));
        });
    }

    @Action(SaveAsifDetail)
    saveAsifDetail(context: StateContext<AsifDetailStateModel>, action: SaveAsifDetail): void {

        this.loading(context,'datas-save');

        this._asifApiService.saveAsifDetail(action.payload.asDetail)
            .pipe(finalize(()=> {this.loaded(context,'datas-save');}))
            .subscribe((result)=> {
                this._store.dispatch(
                    new UpdateFormValue({
                        path:'asifDetail',
                        value: result
                    })
                );
                this._toastrService.success('Relevé enregistré avec succès!', 'Ajout relevé bancaire');
            });
    }

    @Action(AsifDetailChangeOperationDetail)
    asifDetailChangeOperationDetail(context: StateContext<AsifDetailStateModel>, action: AsifDetailChangeOperationDetail): void {

        this.loading(context,'datas');

        this._store.dispatch(
            new UpdateFormValue({
                path:'asifDetail',
                value: {
                    operationDetail: action.payload
                }
            })
        );

        this.loaded(context,'datas');
    }

    @Action(AsifDetailChangeOperation)
    asifDetailChangeOperation(context: StateContext<AsifDetailStateModel>, action: AsifDetailChangeOperation): void {

        this.loading(context,'operation-change');

        // this._store.dispatch(
        //     new UpdateFormValue({
        //         path:'asifDetail',
        //         value: {
        //             operation: null
        //         }
        //     })
        // );
        // if(action.payload.operation) {
            this._store.dispatch(
                new UpdateFormValue({
                    path:'asifDetail',
                    value: {
                        operation:action.payload.operation
                    }
                })
            );
        // }

        this.loaded(context,'operation-change');
    }

    @Action(AsifDetailChangeOtf)
    asifDetailChangeOtf(context: StateContext<AsifDetailStateModel>, action: AsifDetailChangeOtf): void {

        this.loading(context,'otf-change');

        this._store.dispatch(
            new UpdateFormValue({
                path:'asifDetail',
                value: {
                    operationTypeFamily: action.payload.otf
                }
            })
        );

        this.loaded(context,'otf-change');
    }

    @Action(AsifDetailChangeOt)
    asifDetailChangeOt(context: StateContext<AsifDetailStateModel>, action: AsifDetailChangeOt): void {

        this.loading(context,'ot-change');

        this._store.dispatch(
            new UpdateFormValue({
                path:'asifDetail',
                value: {
                    operationType: action.payload.ot
                }
            })
        );

        this.loaded(context,'ot-change');
    }

    @Action(AsifDetailChangeOperationTransverse)
    asifDetailChangeOperationTransverse(context: StateContext<AsifDetailStateModel>, action: AsifDetailChangeOperationTransverse): void {

        this.loading(context,'operation-transverse-change');

        const select = {id: action.payload.id, label: action.payload.label} as Select;
        const selected = this._helperService.getDeepClone(context.getState().model.operationTransverse) as Select[];
        selected.push(select);

        this._store.dispatch(
            new UpdateFormValue({
                path:'asifDetail',
                value: {
                    operationTransverse: selected
                }
            })
        );

        this.loaded(context,'operation-transverse-change');
    }

    @Action(AsifDetailChangeOperationDetailOperationPlace)
    asifDetailChangeOperationDetailOperationPlace(context: StateContext<AsifDetailStateModel>, action: AsifDetailChangeOperationDetailOperationPlace): void {

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

            // context.patchState({
            //     model:  {
            //         ...context.getState().model,
            //         operationDetail: null
            //     }
            //     // operationDetail:
            //     // model:  {
            //     //     ...context.getState().model,
            //     //     operationDetail: {
            //     //         ...context.getState().model.operationDetail,
            //             // operationPlace: action.payload.operationPlace
            //     //     }
            //     // }
            // });



            // const toto = this._store.selectSnapshot(AsifDetailState.get);
            this._store.dispatch(
                new UpdateFormValue({
                    path:'asifDetail',
                    value:
                    {
                        operationDetail: {
                            // ...context.getState().model.operationDetail,
                            operationPlace: action.payload.operationPlace
                        }
                    }
                    // ,
                    // propertyPath:'operationDetail'
                })
            );
        }

        this.loaded(context,'operation-detail-operation-place-change');
    }

//     @Action(AsifDetailCheckInListOtf)
//     asifDetailCheckInListOtf(context: StateContext<AsifDetailStateModel>, action: AsifDetailCheckInListOtf): void {

//         this.loading(context,'otf-check-in-list');

//         if(action.payload) {
//             // let select: Select;
//             let operationTypeFamily = this._helperService.getDeepClone(context.getState().model.operationTypeFamily);

//             if(operationTypeFamily) {
//                 if(!action.payload.map(x=>x.id).includes(operationTypeFamily.map(x=>x.id))) {
//                     operationTypeFamily=null;
//                 }

//                 this._store.dispatch(
//                     new UpdateFormValue({
//                         path:'asifDetail',
//                         value: {
//                             operationTypeFamily: operationTypeFamily
//                         }
//                     })
//                 );
//             }

//         }

//         this.loaded(context,'otf-check-in-list');
//     }



}
