
import { Route } from '@angular/router';
import { AuthGuard } from 'app/core/auth/guards/auth.guard';
import { AsiMainComponent } from './list/main/asi-main.component';

export const asiRoutes: Route[] = [
    // {
        { path: '', component: AsiMainComponent, canActivate: [AuthGuard] },
        { path: 'folders/:folderId', component: AsiMainComponent, canActivate: [AuthGuard] },
        { path: 'file/:idFile', loadChildren: (): Promise<any>=> import('app/modules/admin/apps/account-statement-import-file/asif.module').then(m => m.AsifModule)}
        // path     : '',
        // component: AsiComponent,
        // children : [
        //     { path: '', component: AsiHeaderComponent, canActivate: [AuthGuard] },
        //     { path: 'folders/:folderId', component: AsiHeaderComponent, canActivate: [AuthGuard] },
        //     { path: 'file/:idFile', loadChildren: () => import('app/modules/main/apps/account-statement-import-file/asif.module').then(m => m.AsifModule)}
        // ]
    // }
];
