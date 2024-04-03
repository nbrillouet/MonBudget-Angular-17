import { NgModule } from '@angular/core';
import { MatTableFilterModule } from '@corporate/mat-table-filter';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { PlanPosteTableComponent } from './plan-poste-table.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { PlanPosteTableDataModule } from 'app/services/plan/crud/detail/plan-poste/table/plan-poste-table.data.module';

@NgModule({
    declarations: [
        PlanPosteTableComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        MatTableFilterModule,
        PlanPosteTableDataModule
    ],
    exports: [PlanPosteTableComponent]
})
export class PlanPosteTableModule
{
}
