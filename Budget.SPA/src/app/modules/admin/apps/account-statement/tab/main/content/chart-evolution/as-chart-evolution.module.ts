import { NgModule } from '@angular/core';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { AsChartEvolutionDataModule } from 'app/services/account-statement/account-statement/chart-evolution/as-chart-evolution.data.module';
import { SharedModule } from 'app/shared/shared.module';
import { AsChartEvolutionComponent } from './as-chart-evolution.component';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { WidgetCardChartBarModule } from 'app/shared/widgets/widget-card-chart-bar/widget-card-chart-bar.module';

@NgModule({
    declarations: [
        AsChartEvolutionComponent
    ],
    imports     : [
        AngularMaterialModule,
        SharedModule,

        FuseScrollbarDirective,
        FuseScrollResetDirective,

        WidgetCardChartBarModule,
        AsChartEvolutionDataModule
    ],
    exports: [
        AsChartEvolutionComponent
    ]
})
export class AsChartEvolutionModule
{
}
