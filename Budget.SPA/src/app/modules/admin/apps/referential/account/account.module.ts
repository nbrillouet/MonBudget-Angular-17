import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { accountRoutes } from './account.routing';
import { AccountDetailModule } from './detail/account-detail.module';
import { AccountListModule } from './list/account-list.module';
import { AccountListDataModule } from 'app/services/referential/account/list/account-list.data.module';

@NgModule({
    declarations: [

    ],
    imports     : [
        RouterModule.forChild(accountRoutes),

        AccountListModule,
        AccountDetailModule,

        AccountListDataModule
    ],
    exports     : [

    ]
})
export class AccountModule
{
}
