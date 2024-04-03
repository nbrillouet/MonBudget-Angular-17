import { NgModule } from '@angular/core';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { WidgetCardChartBarComponent } from './widget-card-chart-bar.component';


@NgModule({
    declarations: [
        WidgetCardChartBarComponent
    ],
    imports: [
        SharedModule,
        AngularMaterialModule
    ],
    exports: [
        WidgetCardChartBarComponent
    ],
    providers: [

    ]
})
export class WidgetCardChartBarModule { }
