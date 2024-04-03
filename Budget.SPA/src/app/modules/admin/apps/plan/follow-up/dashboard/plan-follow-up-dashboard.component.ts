import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Select } from '@corporate/model';
import { EnumMovement } from 'app/model/enum/enum-movement.enum';
import { PlanFollowUpAmountRealFilter } from 'app/model/filters/plan-follow-up-amount-real.filter';
import { PlanPosteDetailFilter } from 'app/model/filters/plan-poste.filter';
import { PlanForFollowUp } from 'app/model/plan/plan-follow-up/plan-follow-up.model';
import { HelperService } from 'app/services/helper.service';
import { PlanPosteDetailComponent } from '../../crud/detail/plan-poste/detail/plan-poste-detail.component';
import { PlanFollowUpAmountRealComponent } from './amount-real/plan-follow-up-amount-real.component';
import { Plan } from 'app/model/plan/plan.model';
import { PlanPosteTableService } from 'app/services/plan/crud/detail/plan-poste/table/plan-poste-table.service';
import { PlanFollowUpDashboardService } from 'app/services/plan/follow-up/plan-follow-up-dashboard.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'plan-follow-up-dashboard',
    templateUrl    : './plan-follow-up-dashboard.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class PlanFollowUpDashboardComponent implements OnInit, OnDestroy
{
    property: PlanForFollowUp;
    enumMovement: typeof EnumMovement = EnumMovement;

    constructor(
        public _userLoggedService: UserLoggedService,
        public _helperService: HelperService,
        public _planFollowUpDashboardService: PlanFollowUpDashboardService,
        private _planPosteTableService: PlanPosteTableService,
        private _dialog: MatDialog,
     )
    {
        this.property =  this._planFollowUpDashboardService.model;
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        this._planFollowUpDashboardService.changePlanFollowUpSelected();
    }

    changeYear(year: number): void {
        this._planFollowUpDashboardService.changeYearFilterSelected(year);
    }

    changeMonth(month: Select): void{
        this._planFollowUpDashboardService.changeMonthFilterSelected(month);
    }

    changePlanLabel(plan: Plan): void {
        this._planFollowUpDashboardService.changePlanFilterSelected(plan);
    }

    onPreviewAmountClick(idPlanPoste: number, idPoste: number, idPlan: number): void {
        this._dialog.open(PlanPosteDetailComponent,
            {
                autoFocus: false,
                disableClose: true,
                width: '35%',
                data: new PlanPosteDetailFilter(
                    {
                        id: idPlanPoste,
                        idPlan: idPlan,
                        idPoste: idPoste,
                        idUserGroup: this._userLoggedService.userForInfo.idUserGroup
                    }
                )
            })
            .afterClosed()
            .subscribe(() => {
                this._planFollowUpDashboardService.changePlanFollowUpSelected();
            });
    }

    onRealAmountClick(label: string, idPlanPoste: number, idPoste: number, idPlan: number): void {
        this._dialog.open(PlanFollowUpAmountRealComponent,
            {
                autoFocus: false,
                disableClose: true,
                width: '60%',
                data: {
                        label: label,
                        filter: new PlanFollowUpAmountRealFilter(
                            {
                                idPlanPoste: idPlanPoste,
                                idPlan: idPlan,
                                idPoste: idPoste,
                                monthYear: this._planFollowUpDashboardService.filterSelected.monthYear
                            }
                        )
                }
            })
            .afterClosed()
            .subscribe(() => {
                // this._planFollowUpDashboardService.changePlanFollowUpSelected();
            });
    }
}
