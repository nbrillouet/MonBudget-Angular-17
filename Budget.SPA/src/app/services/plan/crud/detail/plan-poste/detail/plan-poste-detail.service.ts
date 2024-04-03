import { Injectable } from '@angular/core';
import { CorpDataForm } from '@corporate/data';
import { DataInfo, DetailFormInfo, FilterForDetail } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { Select as SelectModel } from '@corporate/model';
import { AuthService } from 'app/core/auth/auth.service';
import { BaseChart, BaseChartBar, ChartInfo, DataSet } from 'app/model/chart/base-chart.model';
import { FilterPlanPosteDetail, PlanPosteDetailFilter, PlanPosteReferenceFilter } from 'app/model/filters/plan-poste.filter';
import { Frequency, PlanPosteForDetail, PlanPosteFrequencyForDetail, PlanPosteUserForDetail } from 'app/model/plan/plan-poste/plan-poste.model';
import { LoadPlanDetail } from 'app/state/plan/plan-detail/plan-detail.action';
import { PlanPosteDetailFilterState } from 'app/state/plan/plan-detail/plan-poste/plan-poste-detail/plan-poste-detail-filter/plan-poste-detail-filter.state';
import { LoadPlanPosteDetail, SavePlanPosteDetail } from 'app/state/plan/plan-detail/plan-poste/plan-poste-detail/plan-poste-detail.action';
import { PlanPosteDetailState } from 'app/state/plan/plan-detail/plan-poste/plan-poste-detail/plan-poste-detail.state';
import { Observable } from 'rxjs';
import { PlanPosteForDetailFormBuilderOptions } from './plan-poste-detail.form-builder-option';
import { ChartData, ChartDataset } from 'chart.js';
import { HelperService } from 'app/services/helper.service';
import { PlanPosteDetailFilterChangePlanPosteReference } from 'app/state/plan/plan-detail/plan-poste/plan-poste-detail/plan-poste-detail-filter/plan-poste-detail-filter.action';

@Injectable({ providedIn: 'root' })
export class PlanPosteForDetailService extends CorpDataForm<PlanPosteForDetail, PlanPosteForDetailFormBuilderOptions>
{
    @Select(PlanPosteDetailState.get) stateDetail$: Observable<DetailFormInfo<PlanPosteForDetail, FilterForDetail>>;
    @Select(PlanPosteDetailFilterState.get) stateFilter$: Observable<DataInfo<FilterPlanPosteDetail>>;

    currentId: number = null;
    saveInProgress: boolean = false;
    formIsLoaded: boolean = false;
    pageType: string;

    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService,
        private _authervice: AuthService
    )
    {
        super(PlanPosteForDetail, PlanPosteForDetailFormBuilderOptions);

        this.stateDetail$
            // .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((x)=>{
                if(x.loader['datas']?.loaded) {
                    this.formIsLoaded = true;
                    if(x.model.hasOwnProperty('id')) {
                        this.pageType=x.model.id===0 ? 'new' : 'edit';
                        if (this.currentId !== x.model.id) {
                            this.currentId = x.model.id;
                            this.initTrigger();
                        }
                    }
                }

                // if(x.loader['operation-change']?.loaded) {
                //     this.isNewOperationTemplate = false;
                // }
                // if(x.loader['operation-transverse-change']?.loaded) {
                //     this.isNewOperationTransverseTemplate = false;
                // }
                if(x.loader['datas-save']?.loading) {
                    this.saveInProgress=true;
                    this.form.disableForm(true);
                }
                if(x.loader['datas-save']?.loaded) {
                    this.saveInProgress = false;
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
        this.initForm(PlanPosteForDetail, PlanPosteForDetailFormBuilderOptions);
    }

    save(): void {
        this._store.dispatch(new SavePlanPosteDetail(this.form.formGroup.getRawValue()));
    }

    loadDetail(filterForDetail: PlanPosteDetailFilter): void {
        this._store.dispatch(new LoadPlanPosteDetail(filterForDetail));
    }

    getBaseChartBar(): BaseChartBar {
        //recherche ppf
        const currentPpf =  this.form.getValue(x=>x.planPosteFrequencies).isYearly
            ? this.form.getValue(x=>x.planPosteFrequencies).yearly
            : this.form.getValue(x=>x.planPosteFrequencies).monthly;

        const baseChartBar = new BaseChartBar();
        baseChartBar.data = {
            datasets: this.mapPreviewAmountToDatasets(currentPpf.map(y=>y.previewAmount)),
            labels: (currentPpf.map(y=>y.frequency) as Frequency[]).map(x=>x.labelShort)
        };

        return baseChartBar;
    }

    changeAmountMonthly(frequency: string, chartInfo: ChartInfo): void {
        //recherche ppf
        const currentPpf: PlanPosteFrequencyForDetail[] = this._helperService.getDeepClone(this.form.getValue(x=>x.planPosteFrequencies).monthly);

        switch(frequency) {
            case 'once':
                //recherche index du mois
                const index = currentPpf.findIndex(x=>x.frequency.labelShort===chartInfo.x);
                //mise à jour des données du mois
                currentPpf[index].previewAmount=this.form.getValue(x=>x.currentAmount) as number;
                break;
            case 'all':
                //mise à jour des montants pour tous les mois
                currentPpf.forEach((x: PlanPosteFrequencyForDetail)=> {
                    x.previewAmount=this.form.getValue(y=>y.currentAmount) as number;
                });
                break;
        }

        //mise à jour du ppf
        this.form.setValue(x=>x.planPosteFrequencies.monthly, currentPpf);
        //reinit du currentAmount
        this.form.setValue(x=>x.currentAmount, null);
    }

    changePlanPosteUserPercentage(planPosteUserForDetail: PlanPosteUserForDetail, percentage: number): void {

        //recherche ppu
        const ppu: PlanPosteUserForDetail[] = this._helperService.getDeepClone(this.form.getValue(x=>x.planPosteUser) as PlanPosteUserForDetail[]);
        const ppu1 = ppu.filter(x=>x.user.id===planPosteUserForDetail.user.id)[0] as PlanPosteUserForDetail;
        const ppu2 = ppu.filter(x=>x.user.id!==planPosteUserForDetail.user.id)[0] as PlanPosteUserForDetail;

        ppu1.percentagePart = percentage;
        if(ppu2){
            ppu2.percentagePart =  100 - percentage;
        }
        this.form.setValue(x=>x.planPosteUser, ppu);
        this.form.getControl(x=>x.planPosteUser).markAsDirty();
    }
    // PlanPosteUserForDetail): void {
    //     this._planPosteForDetailService.changePlanPosteUserPercentage(planPosteUser, $event);

    //     let toto:PlanPosteUserForDetail;
    //     toto= this.data.planPosteUser.filter(x=>x.user.id==planPosteUser.user.id)[0];

    //     let tata:PlanPosteUserForDetail;
    //     tata= this.data.planPosteUser.filter(x=>x.user.id!=planPosteUser.user.id)[0];

    //     toto.percentage=$event.value;
    //     tata.percentage = 100-toto.percentage;
    // private mapFrequencyToSelect(frequencies: Frequency[]): SelectModel[] {
    //     const labels=[] as SelectModel[];
    //     frequencies.forEach((value: Frequency) => {
    //         labels.push({ id: value.id, label: value.labelShort });
    //     });
    //     return labels;
    // }

    private mapPreviewAmountToDatasets(previewAmounts: number[]): ChartDataset<'bar'>[] {
        return  [ {
            label: 'Montant Prévisionnel',
            data: previewAmounts,
            backgroundColor:  new Array(previewAmounts.length).fill('#7CA3FF'), // previewAmounts.forEach['red', 'green', 'blue'],
            hoverBackgroundColor: new Array(previewAmounts.length).fill('#4D659E') // ['darkred', 'darkgreen', 'darkblue'],
        } ];
    }
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

    private initTrigger(): void {
        this.initFormReferenceTable();
        // this.initFormTriggerOperationMethod();
        // this.initFormTriggerOperationTypeFamily();
        // this.initFormTriggerOperationType();
        // this.initFormTriggerOperation();
    }

    private initFormReferenceTable(): void {
        this.form.getControl(x=>x.referenceTable).valueChanges.subscribe((value) => {
            if(this.form.formGroup.dirty) {
                 this.updateReferenceTable(value);
            }
        });
    }

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
    // //===   REFERENCE TABLE
    // //===========================================================
    private updateReferenceTable(referenceTable: SelectModel): void {
        this.triggerReferenceTable(referenceTable);
    }

    private triggerReferenceTable(referenceTable: SelectModel): void {
        //modification reference table implique:
        //-->change planPosteReference

        this.changePlanPosteReferenceList(referenceTable);
    }

    // //===========================================================
    // //===   PLAN POSTE REFERENCE
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

    private changePlanPosteReferenceList(referenceTable: SelectModel): void {
        const filter: PlanPosteReferenceFilter ={
            // idPlanPoste: this.form.getValue(x=>x.id),
            idReferenceTable: referenceTable.id,
            idPoste: this.form.getValue(x=>x.idPoste),
            idUserGroup: this._authervice.user.idUserGroup
        };
        this._store.dispatch(new PlanPosteDetailFilterChangePlanPosteReference(filter));
    }

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
