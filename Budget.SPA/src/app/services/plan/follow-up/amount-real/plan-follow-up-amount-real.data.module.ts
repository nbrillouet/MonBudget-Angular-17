import { NgModule } from '@angular/core';
import { PlanFollowUpAmountRealStoreModule } from 'app/state/plan/plan-follow-up/amount-real/plan-follow-up-amount-real.store.module';
import { PlanFollowUpAmountRealService } from './plan-follow-up-amount-real.data.service';

@NgModule({
    imports  : [
        PlanFollowUpAmountRealStoreModule
    ],
    providers: [
        PlanFollowUpAmountRealService
    ]
})
export class PlanFollowUpAmountRealDataModule { }
