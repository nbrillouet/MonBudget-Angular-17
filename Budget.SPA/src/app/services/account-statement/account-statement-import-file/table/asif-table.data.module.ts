import { NgModule } from '@angular/core';
import { AsifTableStoreModule } from 'app/state/account-statement-import-file/asif-table/asif-table.store.module';
import { AsifTableService } from './asif-table.service';

@NgModule({
    imports  : [
        AsifTableStoreModule
    ],
    providers: [
        AsifTableService
    ]
})
export class AsifTableDataModule { }
