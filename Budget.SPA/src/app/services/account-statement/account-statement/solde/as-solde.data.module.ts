import { NgModule } from '@angular/core';
import { AsSoldeStoreModule } from 'app/state/account-statement/account-statement-solde/as-solde.store.module';
import { AsSoldeService } from './as-solde.service';

@NgModule({
    imports  : [
        AsSoldeStoreModule
    ],
    providers: [
        AsSoldeService
    ]
})
export class AsSoldeDataModule { }
