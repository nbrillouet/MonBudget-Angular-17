import { NgModule } from '@angular/core';
import { PlanPosteDetailStoreModule } from 'app/state/plan/plan-detail/plan-poste/plan-poste-detail/plan-poste-detail.store.module';
import { PlanPosteForDetailService } from './plan-poste-detail.service';

@NgModule({
    imports  : [
        PlanPosteDetailStoreModule

    ],
    providers: [
        PlanPosteForDetailService
    ]
})
export class PlanPosteDetailDataModule { }
