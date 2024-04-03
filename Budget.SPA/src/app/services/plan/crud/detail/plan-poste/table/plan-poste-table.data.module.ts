import { NgModule } from '@angular/core';
import { PlanPosteTableStoreModule } from 'app/state/plan/plan-detail/plan-poste/plan-poste-table/plan-poste-table.store.module';
import { PlanPosteTableService } from './plan-poste-table.service';


@NgModule({
    imports  : [
        PlanPosteTableStoreModule
    ],
    providers: [
        PlanPosteTableService
    ]
})
export class PlanPosteTableDataModule { }
