import { NgModule } from '@angular/core';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { WidgetCardSimpleChartBarComponent } from './widget-card-simple-chart-bar.component';

@NgModule({
    declarations: [
        WidgetCardSimpleChartBarComponent
    ],
    imports: [
        SharedModule,
        AngularMaterialModule
        // NgChartsModule

    ],
    exports: [
        WidgetCardSimpleChartBarComponent
    ],
    providers: [

    ]
})
export class WidgetCardSimpleChartBarModule { }
