import { WidgetCardChartPieSelect } from 'app/model/chart/widget-card-chart-pie-select.model';

export class AsChartCategorisation {
    debit: AsChartCategorisationSelect;
    // noIntTransfer: AsChartEvolutionCdb;
    // customOtfs: AsChartEvolutionCustomOtf;

    constructor() {
        this.debit = new AsChartCategorisationSelect();
        // this.noIntTransfer = new AsChartEvolutionCdb();
        // this.customOtfs = new AsChartEvolutionCustomOtf();
    }
}

export class AsChartCategorisationSelect {
    operationMethod: WidgetCardChartPieSelect;
    operationTypeFamily: WidgetCardChartPieSelect;
    operationType: WidgetCardChartPieSelect;

    constructor() {
        this.operationMethod = new WidgetCardChartPieSelect([]);
        this.operationTypeFamily = new WidgetCardChartPieSelect([]);
        this.operationType = new WidgetCardChartPieSelect([]);

    }
}
