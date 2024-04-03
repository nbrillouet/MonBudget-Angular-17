import { NgModule } from '@angular/core';
import { AsChartEvolutionStoreModule } from 'app/state/account-statement/as-chart/as-chart-evolution/as-chart-evolution.store.module';
import { AsMainFilterSelectedService } from '../main/as-main-filter-selected.service';
import { AsChartEvolutionService } from './as-chart-evolution.service';

@NgModule({
    imports  : [
        AsChartEvolutionStoreModule
    ],
    providers: [
        AsMainFilterSelectedService,
        AsChartEvolutionService
    ]
})
export class AsChartEvolutionDataModule { }
