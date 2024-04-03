import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OtfTableFooterComponent } from '../../footer/operation-type-family/table/otf-table.footer.component';
import { OtfDetailContentComponent } from './detail/content/otf-detail-content.component';
import { OtfDetailHeaderComponent } from './detail/header/otf-detail-header.component';
import { OtfDetailMainComponent } from './detail/otf-detail-main.component';
import { OtfDetailModule } from './detail/otf-detail.module';
import { OtfTableComponent } from './table/otf-table.component';
import { OtfTableModule } from './table/otf-table.module';

@NgModule({
    declarations: [ ],
    imports     : [
        OtfTableModule,
        OtfDetailModule
    ],
    exports     : [
        OtfTableComponent,
        OtfTableFooterComponent,

        OtfDetailMainComponent,
        OtfDetailHeaderComponent,
        OtfDetailContentComponent
    ]
})
export class OtfModule
{
}
