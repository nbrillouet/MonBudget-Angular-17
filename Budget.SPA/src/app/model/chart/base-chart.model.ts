import { Select } from '@corporate/model';
import { ChartConfiguration, ChartData, ChartType } from 'chart.js';

// export class BaseChart {
//     label?: string = null;
//     dataSets?: DataSet[] = null;
//     labels?: Select[] = null;
//     options?: Options = null;
//     colors?: Color[] = null;
// }

export class BaseChart  {
    title: string=null;
    type: ChartType=null;

}

export class BaseChartBar extends BaseChart {
    options: ChartConfiguration['options'] = null;
    data: ChartData<'bar'> = null;
    toReinit: boolean = false;
    
    constructor(){
        super();
        this.type = 'bar';
    }
}

export class DataSet {
    label?: string = null;
    data?: number[]= null;
    backgroundColor?: string[]= null;
}

export class Color {
    backgroundColor: string[];
}

export class ChartValue {
    id: number;
    xValue: string;
    yValue: number;
}

export class Options {
    scales: Scales;
}

export class Scales {
    yAxes: YAxe[];
}

export class YAxe {
    display: boolean;
    ticks: Tick;
}

export class Tick {
    beginAtZero: boolean;
    display: boolean;
    min: number;
    max: number;
    steps: number;
    stepValue: number;
}

export class ChartInfo {
    x: string;
    y: number;
}

