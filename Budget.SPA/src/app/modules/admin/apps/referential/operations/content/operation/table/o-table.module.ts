import { NgModule } from '@angular/core';
import { MatTableFilterModule } from '@corporate/mat-table-filter';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { OTableComponent } from './o-table.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { OTableDataModule } from 'app/services/referential/operations/operation/table/o-table.data.module';
import { OTableFooterComponent } from '../../../footer/operation/table/o-table.footer.component';

@NgModule({
    declarations: [
        OTableComponent,
        OTableFooterComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        MatTableFilterModule,

        OTableDataModule
    ],
    exports: [
        OTableComponent,
        OTableFooterComponent
    ]
})
export class OTableModule
{
}
