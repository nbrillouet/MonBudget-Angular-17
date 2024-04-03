import { NgModule } from '@angular/core';
import { PlanTableStoreModule } from 'app/state/plan/plan-table/plan-table.store.module';
import { PlanCrudTableService } from './plan-crud-table.service';

@NgModule({
    imports  : [
        PlanTableStoreModule
    ],
    providers: [
        PlanCrudTableService
    ]
})
export class PlanCrudTableDataModule { }
