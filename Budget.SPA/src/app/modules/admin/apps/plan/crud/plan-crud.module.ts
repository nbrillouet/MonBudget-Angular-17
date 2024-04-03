import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PlanCrudDetailModule } from './detail/plan-crud-detail.module';
import { planCrudRoutes } from './plan-crud.routing';
import { PlanCrudTableModule } from './table/plan-crud-table.module';

@NgModule({
    declarations: [ ],
    imports     : [
        RouterModule.forChild(planCrudRoutes),

        PlanCrudTableModule,
        PlanCrudDetailModule
    ],
    exports     : [

    ]
})
export class PlanCrudModule
{
}
