import { NgModule } from '@angular/core';
import { AsDetailStoreModule } from 'app/state/account-statement/account-statement-detail/as-detail.store.module';
import { AsDetailService } from './as-detail.service';

@NgModule({
    imports  : [
        AsDetailStoreModule
    ],
    providers: [
        AsDetailService
    ]
})
export class AsDetailDataModule { }
