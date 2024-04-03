import { NgModule } from '@angular/core';
import { PlanNotAsTableStoreModule } from 'app/state/plan/plan-detail/plan-not-as-table/plan-not-as-table.store.module';
import { PlanNotAsTableService } from './plan-not-as-table.service';

@NgModule({
    imports  : [
        PlanNotAsTableStoreModule
    ],
    providers: [
        PlanNotAsTableService
    ]
})
export class PlanNotAsTableDataModule { }
