import { NgModule } from '@angular/core';
import { MatTableFilterModule } from '@corporate/mat-table-filter';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { PlanCrudTableHeaderComponent } from './main/header/plan-crud-table-header.component';
import { PlanCrudTableMainComponent } from './main/plan-crud-table-main.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { PlanCrudTableDataModule } from 'app/services/plan/crud/table/plan-crud-table.data.module';

@NgModule({
    declarations: [
        PlanCrudTableMainComponent,
        PlanCrudTableHeaderComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        MatTableFilterModule,
        PlanCrudTableDataModule
    ]
})
export class PlanCrudTableModule
{
}
