import { AuthGuard } from 'app/core/auth/guards/auth.guard';
import { AccountDetailMainComponent } from './detail/main/account-detail-main.component';
import { AccountListMainComponent } from './list/main/account-list-main.component';

export const accountRoutes = [
    {
        path     : '',
        component: AccountListMainComponent,
        canActivate: [AuthGuard]
    }
    ,
    {
        path     : ':idAccount/detail',
        component: AccountDetailMainComponent,
        canActivate: [AuthGuard]
    }

  ];
