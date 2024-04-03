import { NgModule } from '@angular/core';
import { AccountListStoreModule } from 'app/state/referential/account/account-list/account-list.store.module';
import { AccountListService } from './account-list.service';

@NgModule({
    imports  : [
        AccountListStoreModule
    ],
    providers: [
        AccountListService
    ]
})
export class AccountListDataModule { }
