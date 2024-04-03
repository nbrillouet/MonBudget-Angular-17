import { NgModule } from '@angular/core';
import { AsiListStoreModule } from 'app/state/account-statement-import/asi-list/asi-list.store.module';
import { AsiService } from './asi.service';

@NgModule({
    imports  : [
        AsiListStoreModule
    ],
    providers: [
        AsiService
    ]
})
export class AsiDataModule { }
