import { NgModule } from '@angular/core';
import { AsMainStoreModule } from 'app/state/account-statement/as-main/as-main-store.module';
import { AsMainFilterSelectedService } from './as-main-filter-selected.service';
import { AsMainFilterSelectionService } from './as-main-filter-selection.service';
import { AsMainService } from './as-main.service';

@NgModule({
    imports  : [
        AsMainStoreModule
    ],
    providers: [
        AsMainFilterSelectedService,
        AsMainFilterSelectionService,
        AsMainService
    ]
})
export class AsMainDataModule { }
