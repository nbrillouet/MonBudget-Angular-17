import { NgModule } from '@angular/core';
import { PlanFollowUpStoreModule } from 'app/state/plan/plan-follow-up/plan-follow-up.store.module';
import { PlanFollowUpAmountRealDataModule } from './amount-real/plan-follow-up-amount-real.data.module';
import { PlanFollowUpDashboardService } from './plan-follow-up-dashboard.service';

@NgModule({
    imports  : [
        PlanFollowUpStoreModule,

        PlanFollowUpAmountRealDataModule
    ],
    providers: [
        PlanFollowUpDashboardService
    ]
})
export class PlanFollowUpDashboardDataModule { }
