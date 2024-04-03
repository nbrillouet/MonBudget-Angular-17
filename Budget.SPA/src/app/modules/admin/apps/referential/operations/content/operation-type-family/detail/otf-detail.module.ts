import { NgModule } from '@angular/core';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { OtfDetailDataModule } from 'app/services/referential/operations/operation-type-family/detail/otf-detail.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { OtfDetailContentComponent } from './content/otf-detail-content.component';
import { OtfDetailHeaderComponent } from './header/otf-detail-header.component';
import { OtfDetailMainComponent } from './otf-detail-main.component';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';

@NgModule({
    declarations: [
        OtfDetailMainComponent,
        OtfDetailHeaderComponent,
        OtfDetailContentComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        NgxsFormPluginModule,
        OtfDetailDataModule
    ],
    exports: [
        OtfDetailMainComponent,
        OtfDetailHeaderComponent,
        OtfDetailContentComponent
    ]
})
export class OtfDetailModule
{
}
