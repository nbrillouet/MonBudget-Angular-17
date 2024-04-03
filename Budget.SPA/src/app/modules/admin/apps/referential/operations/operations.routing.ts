/* eslint-disable @typescript-eslint/explicit-function-return-type */
import { AuthGuard } from 'app/core/auth/guards/auth.guard';
import { OtfDetailMainComponent } from './content/operation-type-family/detail/otf-detail-main.component';
import { OtDetailMainComponent } from './content/operation-type/detail/ot-detail-main.component';
import { ODetailMainComponent } from './content/operation/detail/o-detail-main.component';
import { OperationsComponent } from './operations.component';

export const operationsRoutes = [
    // // main routes
    // {
    //     path       : '',
    //     canActivate: [AuthGuard],
    //     canActivateChild: [AuthGuard],
    //     component  : OperationsComponent,
    //     children   : [
    //         // // Apps
    //         // {path: 'apps', children: [
    //             {path: 'operation-type-family', loadChildren: ()=> import('app/modules/main/apps/referential/operations/content/operation-type-family/otf.module').then(m => m.OtfModule)},

    //             // {path: 'referential/accounts', loadChildren: () => import('app/modules/main/apps/referential/account/account.module').then(m => m.AccountModule)},
    //             // {path: 'referential/operations', loadChildren: () => import('app/modules/main/apps/referential/operations/operations.module').then(m => m.OperationsModule)},

    //             // {path: 'account-statement-import', loadChildren: () => import('app/modules/main/apps/account-statement-import/asi.module').then(m => m.AsiModule)},
    //             // {path: 'account-statement', loadChildren: () => import('app/modules/main/apps/account-statement/as.module').then(m => m.AsModule)},

    //             // {path: 'plans', loadChildren: () => import('app/modules/main/apps/plan/crud/plan-crud.module').then(m => m.PlanCrudModule)},
    //             // {path: 'plans/follow-up', loadChildren: () => import('app/modules/main/apps/plan/follow-up/plan-follow-up.module').then(m => m.PlanFollowUpModule)},

    //     ]}


    {
        path     : '',
        component: OperationsComponent,
        canActivate: [AuthGuard]
    },
    {
        path     : 'operation-type-family',
        component: OperationsComponent,
        canActivate: [AuthGuard]
    },
    {
        path     : 'operation-type-family/:idOtf',
        component: OtfDetailMainComponent,
        canActivate: [AuthGuard]
    },
    {
        path     : 'operation-type-family/:idOtf/operation-type',
        component: OperationsComponent,
        canActivate: [AuthGuard]
    },
    {
        path     : 'operation-type-family/:idOtf/operation-type/:idOt',
        component: OtDetailMainComponent,
        canActivate: [AuthGuard]
    },
    {
        path     : 'operation-type-family/:idOtf/operation-type/:idOt/operation',
        component: OperationsComponent,
        canActivate: [AuthGuard]
    },
    {
        path     : 'operation-type-family/:idOtf/operation-type/:idOt/operation/:idO',
        component: ODetailMainComponent,
        canActivate: [AuthGuard]
    },
    // {
    //     path     : ':idAccount/detail',
    //     component: AccountDetailMainComponent,
    //     canActivate: [AuthGuard]
    // }

  ];
