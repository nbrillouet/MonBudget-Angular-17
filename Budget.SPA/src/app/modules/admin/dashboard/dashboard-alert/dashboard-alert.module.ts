import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'app/shared/shared.module';
import { DashboardAlertComponent } from './dashboard-alert.component';
import { DashboardAlertHeaderComponent } from './header/dashboard-alert-header.component';
import { DashboardAlertMainComponent } from './main/dashboard-alert-main.component';
import { dashboardAlertRoutes } from './dashboard-alert.routing';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { UserDetailModule } from 'app/services/referential/user/user-detail/user-detail.module';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseFindByKeyPipe } from '@fuse/pipes/find-by-key';

@NgModule({
    declarations: [
        DashboardAlertComponent,
        DashboardAlertHeaderComponent,
        DashboardAlertMainComponent
    ],
    imports     : [
        RouterModule.forChild(dashboardAlertRoutes),

        AngularMaterialModule,
        SharedModule,
        // FuseScrollbarModule,
        // FuseFindByKeyPipeModule,

        UserDetailModule,

        FuseScrollbarDirective,
        FuseFindByKeyPipe
    ]
})
export class DashboardAlertModule
{
}
