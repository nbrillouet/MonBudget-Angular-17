import { NgModule } from '@angular/core';
import { OtfTableStoreModule } from 'app/state/referential/operation-type-family/otf-table/otf-table.store.module';
import { OtfTableFilterSelectedService } from './otf-table-filter-selected.service';
import { OtfTableFilterSelectionService } from './otf-table-filter-selection.service';
import { OtfTableService } from './otf-table.service';


@NgModule({
    imports  : [
        OtfTableStoreModule
    ],
    providers: [
        OtfTableFilterSelectedService,
        OtfTableFilterSelectionService,
        OtfTableService
    ]
})
export class OtfTableDataModule { }
