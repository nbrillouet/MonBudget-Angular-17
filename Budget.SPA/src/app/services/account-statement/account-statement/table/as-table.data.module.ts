import { NgModule } from '@angular/core';
import { AsTableStoreModule } from 'app/state/account-statement/as-table/as-table.store.module';
import { AsTableFilterSelectedService } from './as-table-filter-selected.service';
import { AsTableFilterSelectionService } from './as-table-filter-selection.service';
import { AsTableService } from './as-table.service';

@NgModule({
    imports  : [
        AsTableStoreModule
    ],
    providers: [
        AsTableFilterSelectedService,
        AsTableFilterSelectionService,
        AsTableService
    ]
})
export class AsTableDataModule { }
