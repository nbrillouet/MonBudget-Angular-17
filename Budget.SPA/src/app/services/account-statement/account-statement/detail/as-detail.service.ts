import { Injectable } from '@angular/core';
import { CorpDataForm, LambdaExpression } from '@corporate/data';
import { Select as SelectModel, DataInfo, DetailFormInfo, FilterForDetail, SelectCode } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
import { FilterAsDetail } from 'app/model/filters/account-statement.filter';
import { OperationDetail } from 'app/model/referential/operation-detail.model';
import { OperationTransverse } from 'app/model/referential/operation-transverse.model';
import { O } from 'app/model/referential/operation.model';
import { AsDetailFilterAddOperation, AsDetailFilterAddOperationTransverse, AsDetailFilterChangeOperation, AsDetailFilterChangeOt, AsDetailFilterChangeOtf } from 'app/state/account-statement/account-statement-detail/as-detail-filter/as-detail-filter.action';
import { AsDetailFilterState } from 'app/state/account-statement/account-statement-detail/as-detail-filter/as-detail-filter.state';
import { AsDetailChangeOperationDetail, AsDetailChangeOperationDetailOperationPlace, AsDetailChangeOtf, LoadAsDetail, SaveAsDetail } from 'app/state/account-statement/account-statement-detail/as-detail.action';
import { AsDetailState } from 'app/state/account-statement/account-statement-detail/as-detail.state';
import { Observable } from 'rxjs';
import { AsForDetailFormBuilderOptions } from './as-detail.form-builder-option';
import { ChangeOperationListParameter } from './form-parameter/as-parameter';

@Injectable({ providedIn: 'root' })
export class AsDetailService extends CorpDataForm<AsForDetail, AsForDetailFormBuilderOptions>
{
    @Select(AsDetailState.get) stateDetail$: Observable<DetailFormInfo<AsForDetail, FilterForDetail>>;
    @Select(AsDetailFilterState.get) stateFilter$: Observable<DataInfo<FilterAsDetail>>;

    currentId: number = null;
    isNewOperationTemplate: boolean = false;
    isNewOperationTransverseTemplate: boolean = false;
    asSaveInProgress: boolean = false;
    formIsLoaded: boolean = false;

    /**
     * Constructor
     */
    constructor(
        private _store: Store
    )
    {
        super(AsForDetail, AsForDetailFormBuilderOptions);

        this.stateDetail$
            // .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((x)=>{
                if(x.loader['datas']?.loaded) {
                    this.formIsLoaded = true;
                    if(x.model.hasOwnProperty('id')) {
                        if (this.currentId !== x.model.id) {
                            this.currentId = x.model.id;
                            this.initTrigger();
                            console.log('x.model', x.model);
                        }
                    }
                }

                // if(x.loader['operation-change']?.loaded) {
                //     this.isNewOperationTemplate = false;
                // }
                if(x.loader['operation-transverse-change']?.loaded) {
                    this.isNewOperationTransverseTemplate = false;
                }
                if(x.loader['datas-save']?.loading) {
                    this.asSaveInProgress=true;
                    this.form.disableForm(true);
                }
                if(x.loader['datas-save']?.loaded) {
                    this.asSaveInProgress = false;
                    this.form.disableForm(false);
                }
        });

        this.stateFilter$
            // .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((x)=>{

        });
    }

    destroyForm(): void {
        this.formIsLoaded = false;
        this.initForm(AsForDetail, AsForDetailFormBuilderOptions);

    }

    saveAsDetail(): void {
        this._store.dispatch(new SaveAsDetail({ asDetail: this.form.formGroup.getRawValue() }));
    }

    loadAsDetail(filterForDetail: FilterForDetail): void {
        this._store.dispatch(new LoadAsDetail(filterForDetail));
    }

    changeAsOperationDetail(operationDetail: OperationDetail): void {
        this._store.dispatch(new AsDetailChangeOperationDetail(operationDetail));
    }

    addOperation(operationLabel: string): void {
        const operation = {
            id: 0,
            idOperationMethod: this.form.getValue(x=>x.operationMethod)?.id,
            idOperationType: this.form.getValue(x=>x.operationType)?.id,
            label: operationLabel,
            reference: null,
            idUserGroup: this.form.getValue(x=>x.asi)?.user?.idUserGroup
        } as O;

        this._store.dispatch(new AsDetailFilterAddOperation({operation: operation} ));
    }

    addOperationTransverse(operationTransverseLabel: string): void {
        const operationTransverse = {
            id: 0,
            label: operationTransverseLabel,
            idUser: this.form.getValue(x=>x.asi)?.user?.id
        } as OperationTransverse;

        this._store.dispatch(new AsDetailFilterAddOperationTransverse({operationTransverse: operationTransverse} ));
    }

    private initTrigger(): void {
        this.initFormTriggerOperationMethod();
        this.initFormTriggerOperationTypeFamily();
        this.initFormTriggerOperationType();
        this.initFormTriggerOperation();
    }

    private initFormTriggerOperationMethod(): void {
        this.form.getControl(x=>x.operationMethod).valueChanges.subscribe((value) => {
            if(this.form.formGroup.dirty) {
                this.updateOperationMethod(value);
            }
        });
    }

    private initFormTriggerOperationTypeFamily(): void {
        this.form.getControl(x=>x.operationTypeFamily).valueChanges.subscribe((value) => {
            if(this.form.formGroup.dirty) {
                this.updateOperationTypeFamily(value);
            }
        });
    }

    private initFormTriggerOperationType(): void {
        this.form.getControl(x=>x.operationType).valueChanges.subscribe((value) => {
            if(this.form.formGroup.dirty) {
                this.updateOperationType(value);
            }
        });
    }

    private initFormTriggerOperation(): void {
        this.form.getControl(x=>x.operation).valueChanges.subscribe((value) => {
            if(this.form.formGroup.dirty) {
                this.updateOperation(value);
            }
        });
    }

    //===========================================================
    //===   OPERATION METHOD
    //===========================================================
    private updateOperationMethod(operationMethod: SelectModel): void {
        this.triggerOperationMethod(operationMethod);
    }

    private triggerOperationMethod(operationMethod: SelectModel): void {
        //modification methode operation implique:
        //-->change operationDetail.operationPlace
        //-->change liste operationTypeFamily
        //-->change liste operation
        this.changeOperationDetailOperationPlace(operationMethod);
        this.changeOperationTypeFamilyList(operationMethod);
        this.changeOperationList(x=>x.operationMethod, operationMethod);
    }

    //===========================================================
    //===   OPERATION TYPE FAMILY
    //===========================================================
    private updateOperationTypeFamily(operationTypeFamily: SelectCode): void {
        this.triggerOperationTypeFamily(operationTypeFamily);
    }

    private triggerOperationTypeFamily(operationTypeFamily: SelectCode): void {
        //modification du type operation famille implique:
        //-->change liste operationType
        this.changeOperationTypeList(operationTypeFamily);
    }

    // trigger: tr-operationMethod
    private changeOperationTypeFamilyList(operationMethod: SelectModel): void {
        this._store.dispatch(new AsDetailFilterChangeOtf( { otf: this.form.getValue(x=>x.operationTypeFamily), operationMethod:  operationMethod } ));
    }

    private changeOperationTypeFamily(operationTypeFamily: SelectCode): void {
        this._store.dispatch(new AsDetailChangeOtf( { otf: operationTypeFamily } ));
    }

    //===========================================================
    //===   OPERATION TYPE
    //===========================================================
    private updateOperationType(operationType: SelectModel): void {
        this.triggerOperationType(operationType);
    }

    private triggerOperationType(operationType: SelectModel): void {
        //modification du type operation implique:
        //-->change liste operation
        this.changeOperationList(x=>x.operationType, operationType);
    }

    // trigger: tr-operationTypeFamily
    private changeOperationTypeList(operationTypeFamily: SelectCode): void {
        this._store.dispatch(new AsDetailFilterChangeOt({ idAccount:this.form.getValue(x=>x.account)?.id, idMovement: this.form.getValue(x=>x.idMovement), ot: this.form.getValue(x=>x.operationType), otf: operationTypeFamily }));
    }

    //===========================================================
    //===   OPERATION
    //===========================================================
    private updateOperation(operation: SelectModel): void {
        this.triggerOperation(operation);
    }

    private triggerOperation(operation: SelectModel): void {
        //modification operation implique:
        //-->change operationDetail / operation


    }

    // trigger: tr-operationType tr-operationMethod
    private changeOperationList(nameFunction: ((obj: ChangeOperationListParameter) => any) | (new(...params: any[]) => ChangeOperationListParameter), value: string | Date | boolean | number | SelectCode | SelectModel): void {

        const param = LambdaExpression.getParameters<ChangeOperationListParameter>(nameFunction.toString(), new ChangeOperationListParameter(this.form.formGroup), value);
        this._store.dispatch(new AsDetailFilterChangeOperation(param));
    }

    // private changeOperationList(operationType: SelectModel): void {
    //     this._store.dispatch(new AsDetailFilterChangeOperation({operation: this.asForm.getValue(x=>x.operation), operationMethod: this.asForm.getValue(x=>x.operationMethod), ot: operationType }));
    // }

    //===========================================================
    //===   OPERATION DETAIL
    //===========================================================
    //===   OPERATION PLACE
    // trigger: tr-operationMethod
    private changeOperationDetailOperationPlace(operationMethod: SelectModel): void {
        this._store.dispatch(new AsDetailChangeOperationDetailOperationPlace({operationPlace: this.form.getValue(x=>x.operationDetail.operationPlace) ,operationMethod: operationMethod }));
    }
}
