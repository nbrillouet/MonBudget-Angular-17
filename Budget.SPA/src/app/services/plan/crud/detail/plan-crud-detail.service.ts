import { Injectable } from '@angular/core';
import { CorpDataForm } from '@corporate/data';
import { DetailFormInfo, FilterForDetail } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { BaseChart } from 'app/model/chart/base-chart.model';
import { Frequency } from 'app/model/plan/plan-poste/plan-poste.model';
import { PlanForDetail } from 'app/model/plan/plan.model';
import { LoadPlanDetail, SavePlanDetail } from 'app/state/plan/plan-detail/plan-detail.action';
import { PlanDetailState } from 'app/state/plan/plan-detail/plan-detail.state';
import { BaseChartDirective } from 'ng2-charts';
import { Observable } from 'rxjs';
import { PlanCrudForDetailFormBuilderOptions } from './plan-crud-detail.form-builder-option';

@Injectable({ providedIn: 'root' })
export class PlanCrudDetailService extends CorpDataForm<PlanForDetail, PlanCrudForDetailFormBuilderOptions>
{
    @Select(PlanDetailState.get) stateDetail$: Observable<DetailFormInfo<PlanForDetail, FilterForDetail>>;
    // @Select(PlanDetailFilterState.get) stateFilter$: Observable<DataInfo<FilterPlanDetail>>;

    // _unsubscribeAll: Subject<any> = new Subject<any>();
    currentId: number = null;
    // form: CorpForm<PlanForDetail, PlanCrudForDetailFormBuilderOptions> = new CorpForm<PlanForDetail, PlanCrudForDetailFormBuilderOptions>(PlanForDetail, PlanCrudForDetailFormBuilderOptions);
    // isNewOperationTemplate: boolean = false;
    // isNewOperationTransverseTemplate: boolean = false;
    saveInProgress: boolean = false;
    formIsLoaded: boolean = false;
    pageType: string=null;
    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _authervice: AuthService
    )
    {
        super(PlanForDetail, PlanCrudForDetailFormBuilderOptions);

        this.stateDetail$
            // .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((x)=>{
                if(x.loader['datas']?.loaded) {
                    if(x.model.hasOwnProperty('plan')) {
                        if (this.currentId !== x.model.plan.id) {
                            this.currentId = x.model.plan.id;
                            this.pageType=x.model.plan.id===0 ? 'new' : 'edit';

                            this.formIsLoaded = true;
                        }
                    }
                }

                // if(x.loader['operation-change']?.loaded) {
                //     this.isNewOperationTemplate = false;
                // }
                // if(x.loader['operation-transverse-change']?.loaded) {
                //     this.isNewOperationTransverseTemplate = false;
                // }
                // if(x.loader['datas-save']?.loading) {
                //     this.asifSaveInProgress=true;
                //     this.asifForm.disableForm(true);
                // }
                // if(x.loader['datas-save']?.loaded) {
                //     this.asifSaveInProgress = false;
                //     this.asifForm.disableForm(false);
                // }
        });

        // this.stateFilter$
        //     // .pipe(takeUntil(this._unsubscribeAll))
        //     .subscribe((x)=>{

        // });
    }

    destroyForm(): void {
        this.formIsLoaded = false;
        this.currentId= null;
        this.pageType=null;
        this.initForm(PlanForDetail, PlanCrudForDetailFormBuilderOptions);
        // this.form = new CorpForm<PlanForDetail,PlanCrudForDetailFormBuilderOptions>(PlanForDetail, PlanCrudForDetailFormBuilderOptions);
    }

    saveDetail(): void {

        this._store.dispatch(new SavePlanDetail(this.form.formGroup.getRawValue()));
    }

    loadDetail(filterForDetail: FilterForDetail): void {
        this._store.dispatch(new LoadPlanDetail(filterForDetail));
    }

    // setBaseChart(label: string, data: number[], frequencies: Frequency[]): BaseChart {
    //     const labels=[]; // as Select[];

    //     for(const item of frequencies)
    //     {
    //         labels.push( {id: item.id, label: item.labelShort});
    //     }

    //     const baseChart = new BaseChart();
    //     baseChart.dataSets=[ { label: label, data : data } ];
    //     baseChart.labels=labels;


    //     return  baseChart;
    // }

    // changeAsifOperationDetail(operationDetail: OperationDetail): void {
    //     this._store.dispatch(new AsifDetailChangeOperationDetail(operationDetail));
    // }

    // addOperation(operationLabel: string): void {
    //     const operation = {
    //         id: 0,
    //         idOperationMethod: this.asifForm.getValue(x=>x.operationMethod)?.id,
    //         idOperationType: this.asifForm.getValue(x=>x.operationType)?.id,
    //         label: operationLabel,
    //         reference: null,
    //         idUserGroup: this.asifForm.getValue(x=>x.asi)?.user?.idUserGroup
    //     } as Operation;

    //     this._store.dispatch(new AsifDetailFilterAddOperation({operation: operation} ));
    // }

    // addOperationTransverse(operationTransverseLabel: string): void {
    //     const operationTransverse = {
    //         id: 0,
    //         label: operationTransverseLabel,
    //         idUser: this.asifForm.getValue(x=>x.asi.user).id
    //     } as OperationTransverse;

    //     this._store.dispatch(new AsifDetailFilterAddOperationTransverse({operationTransverse: operationTransverse} ));
    // }

    // initTrigger(): void {
    //     this.initFormTriggerOperationMethod();
    //     this.initFormTriggerOperationTypeFamily();
    //     this.initFormTriggerOperationType();
    //     this.initFormTriggerOperation();
    // }

    // private initFormTriggerOperationMethod(): void {
    //     this.asifForm.getControl(x=>x.operationMethod).valueChanges.subscribe((value) => {
    //         if(this.asifForm.formGroup.dirty) {
     //             this.updateOperationMethod(value);
    //         }
    //     });
    // }

    // private initFormTriggerOperationTypeFamily(): void {
    //     this.asifForm.getControl(x=>x.operationTypeFamily).valueChanges.subscribe((value) => {
    //         if(this.asifForm.formGroup.dirty) {
    //             this.updateOperationTypeFamily(value);
    //         }
    //     });
    // }

    // private initFormTriggerOperationType(): void {
    //     this.asifForm.getControl(x=>x.operationType).valueChanges.subscribe((value) => {
    //         if(this.asifForm.formGroup.dirty) {
    //             this.updateOperationType(value);
    //         }
    //     });
    // }

    // private initFormTriggerOperation(): void {
    //     this.asifForm.getControl(x=>x.operation).valueChanges.subscribe((value) => {
    //         if(this.asifForm.formGroup.dirty) {
    //             this.updateOperation(value);
    //         }
    //     });
    // }

    // //===========================================================
    // //===   OPERATION METHOD
    // //===========================================================
    // private updateOperationMethod(operationMethod: SelectModel): void {
    //     this.triggerOperationMethod(operationMethod);
    // }

    // private triggerOperationMethod(operationMethod: SelectModel): void {
    //     //modification methode operation implique:
    //     //-->change operationDetail.operationPlace
    //     //-->change liste operationTypeFamily
    //     //-->change liste operation
    //     this.changeOperationDetailOperationPlace(operationMethod);
    //     this.changeOperationTypeFamilyList(operationMethod);
    //     this.changeOperationList(x=>x.operationMethod, operationMethod);
    // }

    // //===========================================================
    // //===   OPERATION TYPE FAMILY
    // //===========================================================
    // private updateOperationTypeFamily(operationTypeFamily: SelectCode): void {
    //     this.triggerOperationTypeFamily(operationTypeFamily);
    // }

    // private triggerOperationTypeFamily(operationTypeFamily: SelectCode): void {
    //     //modification du type operation famille implique:
    //     //-->change liste operationType
    //     this.changeOperationTypeList(operationTypeFamily);
    // }

    // // trigger: tr-operationMethod
    // private changeOperationTypeFamilyList(operationMethod: SelectModel): void {
    //     this._store.dispatch(new AsifDetailFilterChangeOtf( { otf: this.asifForm.getValue(x=>x.operationTypeFamily), operationMethod:  operationMethod } ));
    // }

    // private changeOperationTypeFamily(operationTypeFamily: SelectCode): void {
    //     this._store.dispatch(new AsifDetailChangeOtf( { otf: operationTypeFamily } ));
    // }

    // //===========================================================
    // //===   OPERATION TYPE
    // //===========================================================
    // private updateOperationType(operationType: SelectModel): void {
    //     this.triggerOperationType(operationType);
    // }

    // private triggerOperationType(operationType: SelectModel): void {
    //     //modification du type operation implique:
    //     //-->change liste operation
    //     this.changeOperationList(x=>x.operationType, operationType);
    // }

    // // trigger: tr-operationTypeFamily
    // private changeOperationTypeList(operationTypeFamily: SelectCode): void {
    //     this._store.dispatch(new AsifDetailFilterChangeOt({ ot: this.asifForm.getValue(x=>x.operationType), otf: operationTypeFamily }));
    // }

    // //===========================================================
    // //===   OPERATION
    // //===========================================================
    // private updateOperation(operation: SelectModel): void {
    //     this.triggerOperation(operation);
    // }

    // private triggerOperation(operation: SelectModel): void {
    //     //modification operation implique:
    //     //-->change operationDetail / operation
    //     // this.asifForm.setValue(x=>x.operationDetail.operation, operation);

    // }

    // // trigger: tr-operationType tr-operationMethod
    // private changeOperationList(nameFunction: ((obj: ChangeOperationListParameter) => any) | (new(...params: any[]) => ChangeOperationListParameter), value: string | Date | boolean | number | SelectCode | SelectModel): void {
    //     const param = LambdaExpression.getParameters<ChangeOperationListParameter>(nameFunction.toString(), new ChangeOperationListParameter(this.asifForm), value);
    //     this._store.dispatch(new AsifDetailFilterChangeOperation(param));
    // }

    // // private changeOperationList(operationType: SelectModel): void {
    // //     this._store.dispatch(new AsifDetailFilterChangeOperation({operation: this.asifForm.getValue(x=>x.operation), operationMethod: this.asifForm.getValue(x=>x.operationMethod), ot: operationType }));
    // // }

    // //===========================================================
    // //===   OPERATION DETAIL
    // //===========================================================
    // //===   OPERATION PLACE
    // // trigger: tr-operationMethod
    // private changeOperationDetailOperationPlace(operationMethod: SelectModel): void {
    //     this._store.dispatch(new AsifDetailChangeOperationDetailOperationPlace({operationPlace: this.asifForm.getValue(x=>x.operationDetail.operationPlace) ,operationMethod: operationMethod }));
    // }
}
