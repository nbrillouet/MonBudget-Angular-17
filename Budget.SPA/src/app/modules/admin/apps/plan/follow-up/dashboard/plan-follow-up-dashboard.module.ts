import { NgModule } from '@angular/core';
import { TranslocoModule } from '@ngneat/transloco';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { PlanFollowUpDashboardDataModule } from 'app/services/plan/follow-up/plan-follow-up-dashboard.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { PlanFollowUpAmountRealComponent } from './amount-real/plan-follow-up-amount-real.component';
import { PlanFollowUpDashboardComponent } from './plan-follow-up-dashboard.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';

@NgModule({
    declarations: [
        PlanFollowUpDashboardComponent,
        PlanFollowUpAmountRealComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        NgxsFormPluginModule,
        TranslocoModule,

        PlanFollowUpDashboardDataModule

    ]
})
export class PlanFollowUpDashboardModule
{
}
