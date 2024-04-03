import { NgModule } from '@angular/core';
import { PlanPosteDetailModule } from './detail/plan-poste-detail.module';
import { PlanPosteTableModule } from './table/plan-poste-table.module';

@NgModule({
    declarations: [ ],
    imports     : [
        PlanPosteTableModule,
        PlanPosteDetailModule,
    ],
    exports: [
        PlanPosteTableModule,
        PlanPosteDetailModule
     ]
})
export class PlanPosteModule
{
}
