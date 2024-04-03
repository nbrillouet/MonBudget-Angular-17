/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { DataInfo } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { EnumSelectType } from 'app/model/enum/enum-select-type.enum';
import { FilterAsifDetail } from 'app/model/filters/account-statement-import-file.filter';
import { ReferentialService } from 'app/services/referential/referential.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AsifApiService } from '../../asif.api.service';
import { AsifDetailChangeOperation, AsifDetailChangeOperationTransverse, AsifDetailChangeOt, AsifDetailChangeOtf } from '../asif-detail.action';
import { AsifDetailFilterAddOperation, AsifDetailFilterAddOperationTransverse, AsifDetailFilterChangeOperation, AsifDetailFilterChangeOt, AsifDetailFilterChangeOtf, ClearAsifDetailFilter, LoadAsifDetailFilter } from './asif-detail-filter.action';
import { ToastrService } from 'ngx-toastr';

export class AsifDetailFilterStateModel extends DataInfo<FilterAsifDetail> {
    constructor() {
        super();
    }
}

const asifDetailFilterStateModel = new AsifDetailFilterStateModel();
@State<AsifDetailFilterStateModel>({
    name: 'AsifDetailFilter',
    defaults: asifDetailFilterStateModel
})
@Injectable()
export class AsifDetailFilterState extends LoaderState {
    constructor(
        private _asifApiService: AsifApiService,
        private _referentialService: ReferentialService,
        private _store: Store,
        private _toastrService: ToastrService
    ) {
        super();
    }

    @Selector()
    static get(state: AsifDetailFilterStateModel): any { return state; }

    @Action(LoadAsifDetailFilter)
    loadAsifDetailFilter(context: StateContext<AsifDetailFilterStateModel>, action: LoadAsifDetailFilter): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._asifApiService.getDetailFilter(action.payload).subscribe((result) => {
            context.patchState({
                datas: result
            });

            this.loaded(context,'datas');
        });
    }

    @Action(ClearAsifDetailFilter)
    clearAsifDetailFilter(context: StateContext<AsifDetailFilterStateModel>): void {
        context.setState(new AsifDetailFilterStateModel());
    }

    //====================================
    //          Operation type Family
    //====================================
    @Action(AsifDetailFilterChangeOtf)
    asifDetailFilterChangeOtf(context: StateContext<AsifDetailFilterStateModel>, action: AsifDetailFilterChangeOtf): void {
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
                    this._store.dispatch(new AsifDetailChangeOtf( {otf: null }));
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
    @Action(AsifDetailFilterChangeOt)
    asifDetailFilterChangeOt(context: StateContext<AsifDetailFilterStateModel>, action: AsifDetailFilterChangeOt): void {
        this.loading(context,'ot-list');

        context.patchState({
            datas: {
                ...context.getState().datas,
                operationType: []
            }
        });

        this._referentialService.operationTypeService.getSelectList(action.payload.idAccount, action.payload.idMovement, action.payload.otf?.id, EnumSelectType.empty).subscribe((result)=> {
            context.patchState({
                datas: {
                    ...context.getState().datas,
                    operationType: result
                }
            });

            const isOtInList = result.map(x=>x.id).includes(action.payload?.ot?.id);
            if(!isOtInList) {
                this._store.dispatch(new AsifDetailChangeOt( {ot: null }));
            }

            this.loaded(context,'ot-list');
        });

    }

    //====================================
    //          Operation
    //====================================
    // Le changement d'operation type implique le changement de la liste operation
    @Action(AsifDetailFilterChangeOperation)
    asifDetailFilterChangeOperation(context: StateContext<AsifDetailFilterStateModel>, action: AsifDetailFilterChangeOperation): void {
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
                    this._store.dispatch(new AsifDetailChangeOperation( { operation: null }));
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
    @Action(AsifDetailFilterAddOperation)
    asifDetailFilterAddOperation(context: StateContext<AsifDetailFilterStateModel>, action: AsifDetailFilterAddOperation): void {

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
                        this._store.dispatch(new AsifDetailChangeOperation( { operation: {id: result.id, label: result.label} }));

                        this._toastrService.success(`${result.label} enregistré avec succès!`, 'Ajout opération');
                });
            });
    }

    //====================================
    //          Add Operation transverse
    //====================================
    @Action(AsifDetailFilterAddOperationTransverse)
    asifDetailFilterAddOperationTransverse(context: StateContext<AsifDetailFilterStateModel>, action: AsifDetailFilterAddOperationTransverse): void {

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
                        this._store.dispatch(new AsifDetailChangeOperationTransverse(result));

                        this._toastrService.success(`${result.label} enregistré avec succès!`, 'Ajout opération transverse');
                    });
            });
    }
}
