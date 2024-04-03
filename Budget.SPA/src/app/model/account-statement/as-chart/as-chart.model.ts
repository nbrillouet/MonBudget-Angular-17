import { AsChartCategorisation } from './as-chart-categorisation.model';
import { AsChartEvolution } from './as-chart-evolution.model';

export class AsChart {
    asChartEvolution: AsChartEvolution;
    asChartCategorisation: AsChartCategorisation;

    constructor() {
        this.asChartEvolution = new AsChartEvolution();
        this.asChartCategorisation = new AsChartCategorisation();
    }
}



