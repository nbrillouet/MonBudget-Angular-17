import { NgModule } from '@angular/core';
import { OtTableModule } from './table/ot-table.module';
import { OtDetailModule } from './detail/ot-detail.module';
import { OtTableComponent } from './table/ot-table.component';
import { OtTableFooterComponent } from '../../footer/operation-type/table/ot-table.footer.component';
import { OtDetailMainComponent } from './detail/ot-detail-main.component';
import { OtDetailHeaderComponent } from './detail/header/ot-detail-header.component';
import { OtDetailContentComponent } from './detail/content/ot-detail-content.component';


@NgModule({
    declarations: [ ],
    imports     : [
        OtTableModule,
        OtDetailModule
    ],
    exports     : [
        OtTableComponent,
        OtTableFooterComponent,

        OtDetailMainComponent,
        OtDetailHeaderComponent,
        OtDetailContentComponent
    ]
})
export class OtModule
{
}
