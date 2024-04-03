import { NgModule } from '@angular/core';
import { OtTableStoreModule } from 'app/state/referential/operation-type/ot-table/ot-table.store.module';
import { OtTableFilterSelectedService } from './ot-table-filter-selected.service';
import { OtTableFilterSelectionService } from './ot-table-filter-selection.service';
import { OtTableService } from './ot-table.service';

@NgModule({
    imports  : [
        OtTableStoreModule
    ],
    providers: [
        OtTableFilterSelectedService,
        OtTableFilterSelectionService,
        OtTableService
    ]
})
export class OtTableDataModule { }
