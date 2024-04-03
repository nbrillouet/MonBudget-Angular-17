import { NgModule } from '@angular/core';
import { OTableFooterComponent } from '../../footer/operation/table/o-table.footer.component';
import { ODetailContentComponent } from './detail/content/o-detail-content.component';
import { ODetailHeaderComponent } from './detail/header/o-detail-header.component';
import { ODetailMainComponent } from './detail/o-detail-main.component';
import { ODetailModule } from './detail/o-detail.module';
import { OTableComponent } from './table/o-table.component';
import { OTableModule } from './table/o-table.module';

@NgModule({
    declarations: [ ],
    imports     : [
        OTableModule,
        ODetailModule
    ],
    exports     : [
        OTableComponent,
        OTableFooterComponent,

        ODetailMainComponent,
        ODetailHeaderComponent,
        ODetailContentComponent
    ]
})
export class OModule
{
}
