import { NgModule } from '@angular/core';
import { OTableStoreModule } from 'app/state/referential/operation/operation-table/o-table.store.module';
import { OTableFilterSelectedService } from './o-table-filter-selected.service';
import { OTableFilterSelectionService } from './o-table-filter-selection.service';
import { OTableService } from './o-table.service';

@NgModule({
    imports  : [
        OTableStoreModule
    ],
    providers: [
        OTableFilterSelectedService,
        OTableFilterSelectionService,
        OTableService
    ]
})
export class OTableDataModule { }
