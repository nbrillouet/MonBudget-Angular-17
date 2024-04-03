import { NgModule } from '@angular/core';
import { TranslocoModule } from '@ngneat/transloco';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { AsDetailDataModule } from 'app/services/account-statement/account-statement/detail/as-detail.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { AsDetailHeaderComponent } from './header/as-detail-header.component';
import { AsDetailMainComponent } from './main/as-detail-main.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { GMapModule } from 'app/shared/web-component/g-map/g-map-search/g-map.module';

@NgModule({
    declarations: [
        AsDetailMainComponent,
        AsDetailHeaderComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,

        FuseScrollbarDirective,
        FuseScrollResetDirective,

        AsDetailDataModule,
        NgxsFormPluginModule,
        TranslocoModule,
        GMapModule
    ]
})
export class AsDetailModule
{
}
