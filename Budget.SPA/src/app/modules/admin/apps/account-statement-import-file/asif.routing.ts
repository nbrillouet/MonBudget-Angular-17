import { Route } from '@angular/router';
import { AuthGuard } from 'app/core/auth/guards/auth.guard';
import { AsifDetailMainComponent } from './detail/main/asif-detail-main.component';
import { AsifTableMainComponent } from './table/main/asif-table-main.component';

export const asifRoutes: Route[] = [
    {
        path: '',
        component: AsifTableMainComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'detail/:idAccountStatement',  component: AsifDetailMainComponent, canActivate: [AuthGuard]
    }
    // {path: 'detail/:idAccountStatement',  component: AsifTableComponent, canActivate: [AuthGuard]},
    // {path: 'file/:idFile', component: AsifTableComponent, canActivate: [AuthGuard] }
    // {path: 'folders/:folderId/details/:id', component: AsifTableComponent, canActivate: [AuthGuard] },
    // {path: 'details/:id', component: AsifTableComponent, canActivate: [AuthGuard]}
];
