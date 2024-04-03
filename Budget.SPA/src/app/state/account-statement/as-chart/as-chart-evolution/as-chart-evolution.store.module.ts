import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { AsApiService } from '../../as-api.service';
import { AsChartEvolutionState } from './as-chart-evolution.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AsChartEvolutionState
        ])
    ],
    providers:[
        AsApiService
    ]
})

export class AsChartEvolutionStoreModule
{

}
