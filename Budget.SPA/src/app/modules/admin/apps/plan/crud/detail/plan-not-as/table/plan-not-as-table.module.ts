import { NgModule } from '@angular/core';
import { MatTableFilterModule } from '@corporate/mat-table-filter';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { PlanNotAsTableDataModule } from 'app/services/plan/crud/detail/plan-not-as/table/plan-not-as-table.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { PlanNotAsTableComponent } from './plan-not-as-table.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';

@NgModule({
    declarations: [
        PlanNotAsTableComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        MatTableFilterModule,
        PlanNotAsTableDataModule
    ],
    exports: [PlanNotAsTableComponent]
})
export class PlanNotAsTableModule
{
}
