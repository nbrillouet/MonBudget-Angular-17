import { Injectable } from '@angular/core';
import { DataInfo } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { EnumSelectType } from 'app/model/enum/enum-select-type.enum';
import { FilterAsDetail } from 'app/model/filters/account-statement.filter';
import { ReferentialService } from 'app/services/referential/referential.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AsApiService } from '../../as-api.service';
import { AsDetailChangeOperation, AsDetailChangeOperationTransverse, AsDetailChangeOt, AsDetailChangeOtf } from '../as-detail.action';
import { AsDetailFilterAddOperation, AsDetailFilterAddOperationTransverse, AsDetailFilterChangeOperation, AsDetailFilterChangeOt, AsDetailFilterChangeOtf, ClearAsDetailFilter, LoadAsDetailFilter } from './as-detail-filter.action';
import { ToastrService } from 'ngx-toastr';

export class AsDetailFilterStateModel extends DataInfo<FilterAsDetail> {
    constructor() {
        super();
    }
}

const asDetailFilterStateModel = new AsDetailFilterStateModel();
@State<AsDetailFilterStateModel>({
    name: 'AsDetailFilter',
    defaults: asDetailFilterStateModel
})
@Injectable()
export class AsDetailFilterState extends LoaderState {
    constructor(
        private _asApiService: AsApiService,
        private _referentialService: ReferentialService,
        private _store: Store,
        private _toastrService: ToastrService,
    ) {
        super();
    }

    @Selector()
    static get(state: AsDetailFilterStateModel): any { return state; }

    @Action(LoadAsDetailFilter)
    loadAsDetailFilter(context: StateContext<AsDetailFilterStateModel>, action: LoadAsDetailFilter): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._asApiService.getDetailFilter(action.payload).subscribe((result) => {
            context.patchState({
                datas: result
            });

            this.loaded(context,'datas');
        });
    }

    @Action(ClearAsDetailFilter)
    clearAsDetailFilter(context: StateContext<AsDetailFilterStateModel>): void {
        context.setState(new AsDetailFilterStateModel());
    }

    //====================================
    //          Operation type Family
    //====================================
    @Action(AsDetailFilterChangeOtf)
    asDetailFilterChangeOtf(context: StateContext<AsDetailFilterStateModel>, action: AsDetailFilterChangeOtf): void {
        this.loading(context,'otf-list');

        context.patchState({
            datas: {
                ...context.getState().datas,
                operationTypeFamily: []
            }
        });

        if (action.payload.operationMethod) {
            this._referentialService.operationTypeFamilyService.getSelectCodeList(action.payload.operationMethod.id, EnumSelectType.empty).subscribe((result)=> {
                context.patchState({
                    datas: {
                        ...context.getState().datas,
                        operationTypeFamily: result
                    }
                });

                const isOtfInList = result.map(x=>x.id).includes(action.payload?.otf?.id);
                if(!isOtfInList) {
                    this._store.dispatch(new AsDetailChangeOtf( {otf: null }));
                }

                this.loaded(context,'otf-list');
            });
        }
        else {
            this.loaded(context,'otf-list');
        }
    }

    //====================================
    //          Operation type
    //====================================
    // Le changement d'operation type family implique le changement de la liste operation Type
    @Action(AsDetailFilterChangeOt)
    asDetailFilterChangeOt(context: StateContext<AsDetailFilterStateModel>, action: AsDetailFilterChangeOt): void {
        this.loading(context,'ot-list');

        context.patchState({
            datas: {
                ...context.getState().datas,
                operationType: []
            }
        });

        this._referentialService.operationTypeService.getSelectList(action.payload.idAccount,action.payload.idMovement, action.payload.otf?.id, EnumSelectType.empty).subscribe((result)=> {
            context.patchState({
                datas: {
                    ...context.getState().datas,
                    operationType: result
                }
            });

            const isOtInList = result.map(x=>x.id).includes(action.payload?.ot?.id);
            if(!isOtInList) {
                this._store.dispatch(new AsDetailChangeOt( {ot: null }));
            }

            this.loaded(context,'ot-list');
        });

    }

    //====================================
    //          Operation
    //====================================
    // Le changement d'operation type implique le changement de la liste operation
    @Action(AsDetailFilterChangeOperation)
    asDetailFilterChangeOperation(context: StateContext<AsDetailFilterStateModel>, action: AsDetailFilterChangeOperation): void {
        this.loading(context,'operation-list');

        context.patchState({
            datas: {
                ...context.getState().datas,
                operation: []
            }
        });


        // if (action.payload.operationMethod && action.payload.operationType) {

            this._referentialService.operationService.getSelectList(action.payload.operationMethod?.id,action.payload.operationType?.id,action.payload.idUserGroup, EnumSelectType.empty).subscribe((result)=> {
                context.patchState({
                    datas: {
                        ...context.getState().datas,
                        operation: result
                    }
                });

                const isOperationInList = result.map(x=>x.id).includes(action.payload?.operation?.id);
                if(!isOperationInList) {
                    this._store.dispatch(new AsDetailChangeOperation( { operation: null }));
                }

                this.loaded(context,'operation-list');
            });
        // }
        // else {
        //     this.loaded(context,'operation-list');
        // }
    }

    //====================================
    //          Add Operation
    //====================================
    @Action(AsDetailFilterAddOperation)
    asDetailFilterAddOperation(context: StateContext<AsDetailFilterStateModel>, action: AsDetailFilterAddOperation): void {

        this.loading(context,'operation');

        context.patchState({
            datas: {
                ...context.getState().datas,
                operation: []
            }
        });

        this._referentialService.operationService.create(action.payload.operation)
            .pipe(finalize(()=> {this.loaded(context,'operation');}))
            .subscribe((result)=> {

                this._referentialService.operationService
                    .getSelectList(action.payload.operation.idOperationMethod, action.payload.operation.idOperationType,action.payload.operation.idUserGroup, EnumSelectType.empty)
                    .subscribe((operations) =>{

                        context.patchState({
                            datas: {
                                ...context.getState().datas,
                                operation: operations
                            }
                    });

                    this._store.dispatch(new AsDetailChangeOperation( { operation: {id: result.id, label: result.label} }));

                    this._toastrService.success(`${result.label} enregistré avec succès!`, 'Ajout opération');
                });
            });
    }

    //====================================
    //          Add Operation transverse
    //====================================
    @Action(AsDetailFilterAddOperationTransverse)
    asDetailFilterAddOperationTransverse(context: StateContext<AsDetailFilterStateModel>, action: AsDetailFilterAddOperationTransverse): void {

        this.loading(context,'operation-transverse');

        context.patchState({
            datas: {
                ...context.getState().datas,
                operationTransverse: []
            }
        });

        this._referentialService.operationTransverseService.create(action.payload.operationTransverse)
            .pipe(finalize(()=> {this.loaded(context,'operation-transverse');}))
            .subscribe((result)=> {
                this._referentialService.operationTransverseService.getSelectList(action.payload.operationTransverse.idUser, EnumSelectType.empty)
                    .pipe(finalize(()=> {this.loaded(context,'operation-transverse');}))
                    .subscribe((operationTransverse) =>{
                        context.patchState({
                            datas: {
                                ...context.getState().datas,
                                operationTransverse: operationTransverse
                            }
                        });
                        this._store.dispatch(new AsDetailChangeOperationTransverse(result));

                        this._toastrService.success(`${result.label} enregistré avec succès!`, 'Ajout opération transverse');
                    });
            });
    }
}

// import { Injectable } from '@angular/core';
// import { Action, Selector, State, StateContext } from '@ngxs/store';
// import { FilterAsDetail } from 'app/model/filters/account-statement.filter';
// import { DataInfo } from 'app/model/generics/detail-info.model';
// import { EnumSelectType } from 'app/model/generics/select.model';
// import { ReferentialService } from 'app/services/referential/referential.service';
// import { LoaderState } from 'app/state/_base/loader-state';
// import { AsDetailFilterChangeOt, AsDetailFilterChangeOtf, ClearAsDetailFilter, LoadAsDetailFilter } from './as-detail-filter.action';


// export class AsDetailFilterStateModel extends DataInfo<FilterAsDetail> {
//     constructor() {
//         super();
//     }
// }

// const asDetailFilterStateModel = new AsDetailFilterStateModel();
// @State<AsDetailFilterStateModel>({
//     name: 'AsDetailFilter',
//     defaults: asDetailFilterStateModel
// })
// @Injectable()
// export class AsDetailFilterState extends LoaderState {
//     constructor(
//         private _asService: AsService,
//         private _referentialService: ReferentialService
//     ) {
//         super();
//     }

//     @Selector()
//     static get(state: AsDetailFilterStateModel): any { return state; }

//     @Action(LoadAsDetailFilter)
//     loadAsDetailFilter(context: StateContext<AsDetailFilterStateModel>, action: LoadAsDetailFilter): void {
//         this.loading(context,'datas');

//         // const state = context.getState();
//         context.getState().datas = null;
//         context.patchState(context.getState());

//         this._asService.getDetailFilter(action.payload)
//             .subscribe((result) => {
//                 const state = context.getState();
//                 state.datas = result;
//                 context.patchState(state);

//                 this.loaded(context,'datas');
//             });
//     }

//     @Action(ClearAsDetailFilter)
//     clearAsDetailFilter(context: StateContext<AsDetailFilterStateModel>): void {
//         context.setState(new AsDetailFilterStateModel());
//     }


//     //====================================
//     //          Operation type family
//     //====================================
//     // Le changement d'operation type family implique le changement de la liste operation Type
//     @Action(AsDetailFilterChangeOtf)
//     asDetailFilterChangeOtf(context: StateContext<AsDetailFilterStateModel>, action: AsDetailFilterChangeOtf): void {
//         this.loading(context,'otf');
//         // const state = context.getState();
//         context.getState().datas.operationType = [];
//         context.patchState(context.getState());

//         this._referentialService.operationTypeService.getSelectList(action.payload.id,EnumSelectType.inconnu)
//             .subscribe((result)=> {
//                 const state = context.getState();
//                 state.datas.operationType = result;
//                 context.patchState(state);

//                 this.loaded(context,'otf');
//             });
//     }

//     //====================================
//     //          Operation type
//     //====================================
//     // Le changement d'operation type implique le changement de la liste operation
//     @Action(AsDetailFilterChangeOt)
//     asDetailFilterChangeOt(context: StateContext<AsDetailFilterStateModel>, action: AsDetailFilterChangeOt): void {
//         this.loading(context,'ot');
//         const state = context.getState();
//         state.datas.operation = [];

//         context.patchState(state);
//         this._referentialService.operationService.getSelectList(action.payload.operationMethod.id,action.payload.operationType.id,EnumSelectType.inconnu)
//             .subscribe((result)=> {
//                 // eslint-disable-next-line @typescript-eslint/no-shadow
//                 const state = context.getState();
//                 state.datas.operation = result;
//                 context.patchState(state);

//                 this.loaded(context,'ot');
//             });
//     }
// }
