import { NgModule } from '@angular/core';
import { OtfDetailStoreModule } from 'app/state/referential/operation-type-family/otf-detail/otf-detail.store.module';
import { OtfDetailService } from './otf-detail.service';

@NgModule({
    imports  : [
        OtfDetailStoreModule
    ],
    providers: [
        OtfDetailService
    ]
})
export class OtfDetailDataModule { }
