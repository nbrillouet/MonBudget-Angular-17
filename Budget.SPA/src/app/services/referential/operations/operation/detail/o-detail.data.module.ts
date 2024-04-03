import { NgModule } from '@angular/core';
import { ODetailStoreModule } from 'app/state/referential/operation/operation-detail/o-detail.store.module';
import { ODetailService } from './o-detail.service';

@NgModule({
    imports  : [
        ODetailStoreModule
    ],
    providers: [
        ODetailService
    ]
})
export class ODetailDataModule { }
