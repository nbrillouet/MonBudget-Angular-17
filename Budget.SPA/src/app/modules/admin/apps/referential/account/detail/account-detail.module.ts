import { NgModule } from '@angular/core';
import { TranslocoModule } from '@ngneat/transloco';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { AccountDetailMainComponent } from './main/account-detail-main.component';
import { AccountDetailContentComponent } from './main/content/account-detail-content.component';
import { AccountDetailHeaderComponent } from './main/header/account-detail-header.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { AccountDetailDataModule } from 'app/services/referential/account/detail/account-detail.data.module';

@NgModule({
    declarations: [
        AccountDetailMainComponent,
        AccountDetailHeaderComponent,
        AccountDetailContentComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        NgxsFormPluginModule,
        TranslocoModule,
        // GMapModule,

        AccountDetailDataModule,

        FuseScrollbarDirective,
        FuseScrollResetDirective
    ]
})
export class AccountDetailModule
{
}
