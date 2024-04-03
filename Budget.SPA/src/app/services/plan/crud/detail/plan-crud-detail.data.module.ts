import { NgModule } from '@angular/core';
import { PlanDetailStoreModule } from 'app/state/plan/plan-detail/plan-detail.store.module';
import { PlanCrudDetailService } from './plan-crud-detail.service';

@NgModule({
    imports  : [
        PlanDetailStoreModule
    ],
    providers: [
        PlanCrudDetailService
    ]
})
export class PlanCrudDetailDataModule { }
