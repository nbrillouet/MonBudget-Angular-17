import { NgModule } from '@angular/core';
import { MatTableFilterModule } from '@corporate/mat-table-filter';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { OtTableFooterComponent } from '../../../footer/operation-type/table/ot-table.footer.component';
import { OtTableComponent } from './ot-table.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { OtTableDataModule } from 'app/services/referential/operations/operation-type/table/ot-table.data.module';

@NgModule({
    declarations: [
        OtTableComponent,
        OtTableFooterComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        MatTableFilterModule,

        OtTableDataModule
    ],
    exports: [
        OtTableComponent,
        OtTableFooterComponent
    ]
})
export class OtTableModule
{
}
