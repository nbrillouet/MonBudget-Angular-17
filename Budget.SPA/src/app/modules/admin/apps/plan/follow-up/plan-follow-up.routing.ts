import { Route } from '@angular/router';
import { AuthGuard } from 'app/core/auth/guards/auth.guard';
import { PlanFollowUpDashboardComponent } from './dashboard/plan-follow-up-dashboard.component';

export const planFollowUpRoutes: Route[] = [
    {
        path     : '',
        component: PlanFollowUpDashboardComponent,
        canActivate: [AuthGuard]
    }
];
