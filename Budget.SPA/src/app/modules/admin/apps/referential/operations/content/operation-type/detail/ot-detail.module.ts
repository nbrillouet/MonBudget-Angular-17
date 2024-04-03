import { NgModule } from '@angular/core';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { OtDetailContentComponent } from './content/ot-detail-content.component';
import { OtDetailHeaderComponent } from './header/ot-detail-header.component';
import { OtDetailMainComponent } from './ot-detail-main.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { OtDetailDataModule } from 'app/services/referential/operations/operation-type/detail/ot-detail.data.module';

@NgModule({
    declarations: [
        OtDetailMainComponent,
        OtDetailHeaderComponent,
        OtDetailContentComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        NgxsFormPluginModule,
        OtDetailDataModule
    ],
    exports: [
        OtDetailMainComponent,
        OtDetailHeaderComponent,
        OtDetailContentComponent
    ]
})
export class OtDetailModule
{
}
