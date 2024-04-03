import { NgModule } from '@angular/core';
import { AccountDetailStoreModule } from 'app/state/referential/account/account-detail/account-detail.store.module';
import { AccountDetailService } from './account-detail.service';

@NgModule({
    imports  : [
        AccountDetailStoreModule
    ],
    providers: [
        AccountDetailService
    ]
})
export class AccountDetailDataModule { }
