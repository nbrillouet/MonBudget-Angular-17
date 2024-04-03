import { NgModule } from '@angular/core';
import { FuseScrollResetModule } from '@fuse/directives/scroll-reset';
import { FuseScrollbarModule } from '@fuse/directives/scrollbar';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { AsInternalTransfertDataModule } from 'app/services/account-statement/account-statement/internal-transfert/as-internal-transfert.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { AsInternalTransfertComponent } from './as-internal-transfert.component';

@NgModule({
    declarations: [
        AsInternalTransfertComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarModule,
        FuseScrollResetModule,

        AsInternalTransfertDataModule
    ],
    exports: [
        AsInternalTransfertComponent
    ]
})
export class AsInternalTransferModule
{
}
