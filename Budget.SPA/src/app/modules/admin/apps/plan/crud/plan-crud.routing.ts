import { Route } from '@angular/router';
import { AuthGuard } from 'app/core/auth/guards/auth.guard';
import { PlanCrudDetailMainComponent } from './detail/main/plan-crud-detail-main.component';
import { PlanCrudTableMainComponent } from './table/main/plan-crud-table-main.component';

export const planCrudRoutes: Route[] = [
    {
        path     : '',
        component: PlanCrudTableMainComponent,
        canActivate: [AuthGuard]
    },
    {
      path     : ':idPlan/detail',
      component: PlanCrudDetailMainComponent,
      canActivate: [AuthGuard]
    }
];
