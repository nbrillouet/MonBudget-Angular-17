import { NgModule } from '@angular/core';
import { TranslocoModule } from '@ngneat/transloco';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { AsifTableDataModule } from 'app/services/account-statement/account-statement-import-file/table/asif-table.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { AsifTableHeaderComponent } from './header/asif-table-header.component';
import { AsifTableMainComponent } from './main/asif-table-main.component';
import { MatTableFilterModule } from '@corporate/mat-table-filter';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';

@NgModule({
    declarations: [
        AsifTableMainComponent,
        AsifTableHeaderComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,
        MatTableFilterModule,
        AsifTableDataModule,
        TranslocoModule
    ]
})
export class AsifTableModule
{
}
