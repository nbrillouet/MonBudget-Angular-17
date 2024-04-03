import { NgModule } from '@angular/core';
import { AsifDetailStoreModule } from 'app/state/account-statement-import-file/asif-detail/asif-detail.store.module';
import { AsifDetailService } from './asif-detail.service';

@NgModule({
    imports  : [
        AsifDetailStoreModule
    ],
    providers: [
        AsifDetailService
    ]
})
export class AsifDetailDataModule { }
