import { BaseChartBar } from './base-chart.model';

export class WidgetCardChartBar {
    chart: BaseChartBar = new BaseChartBar();
    title: WidgetCardChartBarTitle = new WidgetCardChartBarTitle();
    isLoaded: boolean = false;

    constructor() {
    }
}

export class WidgetCardChartBarTitle {
    label: string=null;
    averageAmount: number=null;
    ratioAmount: number=null;
    ratioLabel: string=null;
}
