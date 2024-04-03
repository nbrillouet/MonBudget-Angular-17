import { NgModule } from '@angular/core';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { ODetailContentComponent } from './content/o-detail-content.component';
import { ODetailHeaderComponent } from './header/o-detail-header.component';
import { ODetailMainComponent } from './o-detail-main.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { ODetailDataModule } from 'app/services/referential/operations/operation/detail/o-detail.data.module';

@NgModule({
    declarations: [
        ODetailMainComponent,
        ODetailHeaderComponent,
        ODetailContentComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        NgxsFormPluginModule,
        ODetailDataModule
    ],
    exports: [
        ODetailMainComponent,
        ODetailHeaderComponent,
        ODetailContentComponent
    ]
})
export class ODetailModule
{
}
