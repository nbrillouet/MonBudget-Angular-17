import { NgModule } from '@angular/core';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { AsMainDataModule } from 'app/services/account-statement/account-statement/main/as-main-data.module';
import { AsSoldeDataModule } from 'app/services/account-statement/account-statement/solde/as-solde.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { AsTabMainComponent } from './as-tab-main.component';
import { AsTabHeaderComponent } from './header/as-tab-header.component';
import { AsTabTableModule } from './content/table/as-table.module';
import { AsChartEvolutionModule } from './content/chart-evolution/as-chart-evolution.module';
import { AsDetailModule } from './content/detail/as-detail.module';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';

@NgModule({
    declarations: [
        AsTabMainComponent,
        AsTabHeaderComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        AsMainDataModule,
        AsSoldeDataModule,

        AsTabTableModule,
        AsDetailModule,
        AsChartEvolutionModule
    ]
})
export class AsTabMainModule
{
}
