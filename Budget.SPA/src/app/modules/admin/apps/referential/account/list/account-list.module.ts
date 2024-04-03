import { NgModule } from '@angular/core';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { AccountListMainComponent } from './main/account-list-main.component';
import { AccountListContentComponent } from './main/content/account-list-content.component';
import { AccountListHeaderComponent } from './main/header/account-list-header.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';

@NgModule({
    declarations: [
        AccountListMainComponent,
        AccountListHeaderComponent,
        AccountListContentComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective

        // AccountDataModule

    ]
})

export class AccountListModule
{
}
