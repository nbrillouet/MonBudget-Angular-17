import { NgModule } from '@angular/core';
import { TranslocoModule } from '@ngneat/transloco';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { PlanCrudDetailDataModule } from 'app/services/plan/crud/detail/plan-crud-detail.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { PlanCrudDetailContentComponent } from './main/content/plan-crud-detail-content.component';
import { PlanCrudDetailContentGeneralComponent } from './main/content/tab-01-general/plan-crud-detail-content-general.component';
import { PlanCrudDetailHeaderComponent } from './main/header/plan-crud-detail-header.component';
import { PlanCrudDetailMainComponent } from './main/plan-crud-detail-main.component';
import { PlanNotAsTableModule } from './plan-not-as/table/plan-not-as-table.module';
import { PlanPosteModule } from './plan-poste/plan-poste.module';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { ColorPickerModule } from 'ngx-color-picker';

@NgModule({
    declarations: [
        PlanCrudDetailMainComponent,
        PlanCrudDetailHeaderComponent,
        PlanCrudDetailContentComponent,
        PlanCrudDetailContentGeneralComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        NgxsFormPluginModule,
        TranslocoModule,
        ColorPickerModule,


        PlanCrudDetailDataModule,

        PlanPosteModule,
        PlanNotAsTableModule

    ]
})
export class PlanCrudDetailModule
{
}
