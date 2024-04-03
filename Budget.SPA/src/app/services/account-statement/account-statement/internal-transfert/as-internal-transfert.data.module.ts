import { NgModule } from '@angular/core';
import { AsInternalTransfertStoreModule } from 'app/state/account-statement/account-statement-internal-transfer/as-internal-transfert.store.module';
import { AsMainFilterSelectedService } from '../main/as-main-filter-selected.service';
import { AsInternalTransfertService } from './as-internal-transfert.service';

@NgModule({
    imports  : [
        AsInternalTransfertStoreModule
    ],
    providers: [
        AsMainFilterSelectedService,
        AsInternalTransfertService
    ]
})
export class AsInternalTransfertDataModule { }
