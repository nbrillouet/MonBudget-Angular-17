import { NgModule } from '@angular/core';
import { TranslocoModule } from '@ngneat/transloco';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { AsifDetailDataModule } from 'app/services/account-statement/account-statement-import-file/detail/asif-detail.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { AsifDetailHeaderComponent } from './header/asif-detail-header.component';
import { AsifDetailMainComponent } from './main/asif-detail-main.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { GMapModule } from 'app/shared/web-component/g-map/g-map-search/g-map.module';

@NgModule({
    declarations: [
        AsifDetailMainComponent,
        AsifDetailHeaderComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,
        AsifDetailDataModule,
        NgxsFormPluginModule,
        TranslocoModule,
        GMapModule
    ]
})
export class AsifDetailModule
{
}
