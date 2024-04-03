import { Component, OnInit, Inject, Output, EventEmitter, ViewEncapsulation, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ChartInfo } from 'app/model/chart/base-chart.model';
import { PlanPosteForDetail, PlanPosteUserForDetail } from 'app/model/plan/plan-poste/plan-poste.model';
import { HelperService } from 'app/services/helper.service';
import { PlanPosteForDetailService } from 'app/services/plan/crud/detail/plan-poste/detail/plan-poste-detail.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
  selector: 'plan-poste-detail',
  templateUrl: './plan-poste-detail.component.html',
  encapsulation: ViewEncapsulation.None
})
export class PlanPosteDetailComponent extends GenericFormComponent implements OnInit, OnDestroy  {
    property: PlanPosteForDetail;
    chartInfo: ChartInfo= null;

    constructor(
        @Inject(MAT_DIALOG_DATA) data,
        public _matDialogRef: MatDialogRef<PlanPosteDetailComponent>,
        public _planPosteForDetailService: PlanPosteForDetailService,
        public _helperService: HelperService
    )
    {
        super();
        this.property = this._planPosteForDetailService.form.model as PlanPosteForDetail;
        this._planPosteForDetailService.loadDetail(data);
    }

    ngOnInit(): void {

    }

    ngOnDestroy(): void{
        this._planPosteForDetailService.destroyForm();
    }

    close(): void {
        this._matDialogRef.close();
    }

    getChartInfo($event): void {
        this.chartInfo =$event;
        this._planPosteForDetailService.form.setValue(x=>x.currentAmount, $event.y);
    }

    changeAmountMonthly(frequency: string): void {
        this._planPosteForDetailService.changeAmountMonthly(frequency, this.chartInfo);
        this.chartInfo = null;
    }

    changeAmountYearly(): void {

    }

    changeUserPercentage($event,planPosteUser: PlanPosteUserForDetail): void {
        this._planPosteForDetailService.changePlanPosteUserPercentage(planPosteUser, $event.value);
    }

}
