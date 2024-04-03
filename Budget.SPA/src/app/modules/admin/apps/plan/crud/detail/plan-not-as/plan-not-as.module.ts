import { NgModule } from '@angular/core';
import { PlanNotAsTableModule } from './table/plan-not-as-table.module';

@NgModule({
    declarations: [ ],
    imports     : [
        PlanNotAsTableModule
    ],
    exports: [
        PlanNotAsTableModule
     ]
})
export class PlanNotAsModule
{
}
