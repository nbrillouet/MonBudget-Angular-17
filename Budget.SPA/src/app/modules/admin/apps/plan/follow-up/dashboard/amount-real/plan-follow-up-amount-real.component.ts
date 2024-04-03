import { Component, Inject, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HelperService } from 'app/services/helper.service';
import { PlanFollowUpAmountRealService } from 'app/services/plan/follow-up/amount-real/plan-follow-up-amount-real.data.service';

@Component({
    selector: 'plan-follow-up-amount-real',
    templateUrl: './plan-follow-up-amount-real.component.html',
    encapsulation: ViewEncapsulation.None
  })
  export class PlanFollowUpAmountRealComponent implements OnInit, OnDestroy  {
    // tableColumns= ['id','operationMethod','operationTypeFamily','operationType','operation','dateIntegration','amountOperation'];
    tableColumns= ['id','operationMethod','operationTypeFamily','operationType', 'operation', 'dateIntegration', 'amountOperation' ];
    label: string = null;

      constructor(
        @Inject(MAT_DIALOG_DATA) data,
        public _matDialogRef: MatDialogRef<PlanFollowUpAmountRealComponent>,
        public _planFollowUpAmountRealService: PlanFollowUpAmountRealService,
        public _helperService: HelperService
      )
      {
            this._planFollowUpAmountRealService.load(data.filter);
            this.label = data.label;
            // this._store.dispatch(new ChangePlanAmountTableFilter(this.planAmountFilter));
      }

      ngOnInit(): void {

      }

      ngOnDestroy(): void{
        //   this._planPosteForDetailService.destroyForm();
      }

      close(): void {
          this._matDialogRef.close();
      }

  }
