import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PlanFollowUpDashboardModule } from './dashboard/plan-follow-up-dashboard.module';
import { planFollowUpRoutes } from './plan-follow-up.routing';
import { ProgressBarCustomModule } from 'app/shared/web-component/progress-bar-custom/progress-bar-custom.module';

@NgModule({
    declarations: [ ],
    imports     : [
        RouterModule.forChild(planFollowUpRoutes),

        PlanFollowUpDashboardModule,
        ProgressBarCustomModule
    ],
    exports     : [

    ]
})
export class PlanFollowUpModule
{
}
