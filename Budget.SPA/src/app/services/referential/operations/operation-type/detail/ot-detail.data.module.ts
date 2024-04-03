import { NgModule } from '@angular/core';
import { OtDetailStoreModule } from 'app/state/referential/operation-type/ot-detail/ot-detail.store.module';
import { OtDetailService } from './ot-detail.service';

@NgModule({
    imports  : [
        OtDetailStoreModule
    ],
    providers: [
        OtDetailService
    ]
})
export class OtDetailDataModule { }
