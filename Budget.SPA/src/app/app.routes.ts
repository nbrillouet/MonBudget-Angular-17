import { Route } from '@angular/router';
import { AuthGuard } from 'app/core/auth/guards/auth.guard';
import { NoAuthGuard } from 'app/core/auth/guards/noAuth.guard';
import { LayoutComponent } from 'app/layout/layout.component';

// @formatter:off
/* eslint-disable max-len */
/* eslint-disable @typescript-eslint/explicit-function-return-type */
export const appRoutes: Route[] = [

    // Redirect empty path to '/example'
    {path: '', pathMatch : 'full', redirectTo: 'apps'},

    // Redirect signed-in user to the '/example'
    //
    // After the user signs in, the sign-in page will redirect the user to the 'signed-in-redirect'
    // path. Below is another redirection for that path to redirect the user to the desired
    // location. This is a small convenience to keep all main routes together here on this file.
    {path: 'signed-in-redirect', pathMatch : 'full', redirectTo: 'apps/dashboard-alert'},

    // Auth routes for guests
    {
        path: '',
        canActivate: [NoAuthGuard],
        canActivateChild: [NoAuthGuard],
        component: LayoutComponent,
        data: {
            layout: 'empty'
        },
        children: [
            {path: 'confirmation-required', loadChildren: () => import('app/modules/auth/confirmation-required/confirmation-required.routes')},
            {path: 'forgot-password', loadChildren: () => import('app/modules/auth/forgot-password/forgot-password.routes')},
            {path: 'reset-password', loadChildren: () => import('app/modules/auth/reset-password/reset-password.routes')},
            {path: 'sign-in', loadChildren: () => import('app/modules/auth/sign-in/sign-in.routes')},
            {path: 'sign-up', loadChildren: () => import('app/modules/auth/sign-up/sign-up.routes')}
        ]
    },

    // Auth routes for authenticated users
    {
        path: '',
        canActivate: [AuthGuard],
        canActivateChild: [AuthGuard],
        component: LayoutComponent,
        data: {
            layout: 'empty'
        },
        children: [
            {path: 'sign-out', loadChildren: () => import('app/modules/auth/sign-out/sign-out.routes')},
            {path: 'unlock-session', loadChildren: () => import('app/modules/auth/unlock-session/unlock-session.routes')}
        ]
    },

    // Landing routes
    {
        path: '',
        component: LayoutComponent,
        data: {
            layout: 'empty'
        },
        children: [
            {path: 'home', loadChildren: () => import('app/modules/landing/home/home.routes')},
        ]
    },

    // Admin routes
    {
        path: '',
        canActivate: [AuthGuard],
        canActivateChild: [AuthGuard],
        component: LayoutComponent,
        // resolve: {
        //     initialData: initialDataResolver
        // },
        children: [
            {path: 'example', loadChildren: () => import('app/modules/admin/example/example.routes')},
        ]
    },

    // main routes
    {
        path       : '',
        canActivate: [AuthGuard],
        canActivateChild: [AuthGuard],
        component  : LayoutComponent,
        // resolve    : {
        //     initialData: InitialDataResolver,
        // },
        children   : [
            // Apps
            {path: 'apps', children: [
                {path: 'dashboard-alert', loadChildren: () => import('app/modules/admin/dashboard/dashboard-alert/dashboard-alert.module').then(m => m.DashboardAlertModule)},

                {path: 'referential/accounts', loadChildren: () => import('app/modules/admin/apps/referential/account/account.module').then(m => m.AccountModule)},
                {path: 'referential/operations', loadChildren: () => import('app/modules/admin/apps/referential/operations/operations.module').then(m => m.OperationsModule)},

                {path: 'account-statement-import', loadChildren: () => import('app/modules/admin/apps/account-statement-import/asi.module').then(m => m.AsiModule)},
                {path: 'account-statement', loadChildren: () => import('app/modules/admin/apps/account-statement/as.module').then(m => m.AsModule)},

                {path: 'plans', loadChildren: () => import('app/modules/admin/apps/plan/crud/plan-crud.module').then(m => m.PlanCrudModule)},
                {path: 'plans/follow-up', loadChildren: () => import('app/modules/admin/apps/plan/follow-up/plan-follow-up.module').then(m => m.PlanFollowUpModule)},

            ]},

            // Pages
            {path: 'pages', children: [
                // Profile
                {path: 'profile', loadChildren: () => import('app/modules/admin/pages/profile/profile.module').then(m => m.ProfileModule)}
            ]}
        ]
    }
];
