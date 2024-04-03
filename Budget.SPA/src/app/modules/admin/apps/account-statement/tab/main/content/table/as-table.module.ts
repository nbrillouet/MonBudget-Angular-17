import { NgModule } from '@angular/core';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { AsTableDataModule } from 'app/services/account-statement/account-statement/table/as-table.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { MatTableFilterModule } from '@corporate/mat-table-filter';
import { AsTableFooterComponent } from '../../footer/table/as-table.footer.component';
import { AsTableComponent } from './as-table.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';

@NgModule({
    declarations: [
        AsTableComponent,
        AsTableFooterComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,

        FuseScrollbarDirective,
        FuseScrollResetDirective,

        MatTableFilterModule,

        AsTableDataModule
    ],
    exports: [
        AsTableComponent,
        AsTableFooterComponent
    ]
})
export class AsTabTableModule
{
}
