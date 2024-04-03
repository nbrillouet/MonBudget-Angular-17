import { Component, OnInit, ViewEncapsulation, EventEmitter, Output, Input, ViewChild, OnChanges, SimpleChanges } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { WidgetCardChartBarModel } from './widget-card-simple-chart-bar.model';
import { BaseChartDirective } from 'ng2-charts';
import { BaseChart, BaseChartBar } from 'app/model/chart/base-chart.model';
import { HelperService } from 'app/services/helper.service';
import { isEqual } from 'lodash';

@Component({
  selector: 'widget-card-simple-chart-bar',
  templateUrl: './widget-card-simple-chart-bar.component.html',
  encapsulation: ViewEncapsulation.None,
  animations   : fuseAnimations
})
// @Input() widgetCardChartBar: WidgetCardChartBar;
export class WidgetCardSimpleChartBarComponent implements OnInit, OnChanges  {
    @Input() baseChartBar: BaseChartBar;
    @Output() getCurrentMonthInfo = new EventEmitter<{x: string; y: number}>();

    baseChartDirective: BaseChartDirective;


    // barChartData: ChartData<'bar'> = {
    //     labels: [ '2006', '2007', '2008', '2009', '2010', '2011', '2012' ],
    //     datasets: [
    //       { data: [ 65, 59, 80, 81, 56, 55, 40 ], label: 'Series A' },
    //       { data: [ 28, 48, 40, 19, 86, 27, 90 ], label: 'Series B' }
    //     ]
    //   };

    // labels: [ '2006', '2007', '2008', '2009', '2010', '2011', '2012' ];
    // datasets: [
    //     { data: [ 65, 59, 80, 81, 56, 55, 40 ]; label: 'Series A' },
    //     { data: [ 28, 48, 40, 19, 86, 27, 90 ]; label: 'Series B' }
    //   ];


//     @ViewChild(BaseChartDirective) baseChartDirective: BaseChartDirective | undefined;

//   private _data = new BehaviorSubject<BaseChart>(new BaseChart());

//     // change data to use getter and setter
//     @Input()
//     set data(value) {
//         // set the latest value for _data BehaviorSubject
//         this._data.next(value);
//     };

//     get data() {
//         // get the latest value from _data BehaviorSubject
//         return this._data.getValue();
//     }

//   widget: any = {};
//   @Output() getCurrentMonthInfo = new EventEmitter<ChartValue>();
//   showChart: boolean;


//   @ViewChild(BaseChartDirective) private _chart;

// toto:boolean=false;
  constructor(
    public _helperService: HelperService
  ) {
    // this.baseChartDirective.op
    // this.widget = WidgetCardChartBarModel.getEmptyGraph;
   }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes.baseChartBar) {
            if(!isEqual(changes.baseChartBar.currentValue, changes.baseChartBar.previousValue)){
                if(this.baseChartDirective?.data) {
                    this.baseChartDirective.data = this._helperService.getDeepClone(changes.baseChartBar.currentValue.data);
                    // this._chart.refresh();
                }
            }
        }
    }

  ngOnInit(): void {
    this.baseChartDirective = WidgetCardChartBarModel.getEmptyGraph;
    this.baseChartDirective.data = this._helperService.getDeepClone(this.baseChartBar.data);


    // this.baseChartDirective.options.scales.yAxes[0].ticks.min=0;
    // this.baseChartDirective.options.scales.yAxes[0].ticks.stepValue=this.getScaleMin(this.baseChartDirective.data.datasets[0].data);
    // chartDataSet: ChartDataset[] = [];
    // this.baseChartDirective.datasets = this.baseChart.dataSets;


    console.log('baseChartBar',this.baseChartBar);
    // this._data
    //   .subscribe(x => {


    //       this.widget = WidgetCardChartBarModel.getEmptyGraph;
    //       // this.widget.datasets=null;

    //       this.widget.datasets = x.dataSets;
    //       this.widget.labels = x.labels.map(x=>x.label);
    //       this.getScale(x.dataSets[0].data);
    //       //force refresh graph
    //       setTimeout(() => {
    //         this._chart.refresh();
    //     }, 10);


    //   });
  }

  onClick($event): void {
    if ($event.active.length > 0) {
        const datasetIndex = $event.active[0].datasetIndex;
        const dataIndex = $event.active[0].index;
        const yValue = this.baseChartDirective.data.datasets[datasetIndex].data[dataIndex]; // this.baseChartDirective.data.[datasetIndex].data[dataIndex].dataObject
        const xValue = this.baseChartDirective.data.labels[dataIndex];

        console.log('chart-value', `${xValue}-${yValue}`);
        this.getCurrentMonthInfo.emit( { x: xValue as string, y: yValue as number });
    //   const chart = $event.active[0]._chart;

    //   const activePoints = chart.getElementAtEvent($event.event);
    //     if ( activePoints.length > 0) {
    //       // get the internal index of slice in pie chart
    //       const clickedElementIndex = activePoints[0]._index;
    //       const label = chart.data.labels[clickedElementIndex];
    //       // get value by index
    //       const value = chart.data.datasets[0].data[clickedElementIndex];
    //     console.log('xValue',label);
    //     console.log('xValue',value);


        //   let chartValue = <ChartValue>({
        //     xValue:label,
        //     yValue:value
        //   });

        //   this.getCurrentMonthInfo.emit(chartValue);

        // }
       }
  }

  onHovered($evt) {


  }

//   getScale(datas:number[]){
//     let maxValue=Math.ceil(Math.max.apply(Math,datas)*1.5);
//     let minValue=Math.ceil(maxValue/10);
//     this.widget.options.scales.yAxes[0].ticks.min=0;
//     // this.widget.options.scales.yAxes[0].ticks.max=minValue*11;
//     this.widget.options.scales.yAxes[0].ticks.stepValue=minValue;
//     // this.widget.options.scales.yAxes[0].ticks.max=maxValue;

//   }
    getScaleMin(datas: any): number {
        const maxValue=Math.ceil(Math.max.apply(Math,datas)*1.5);
        const minValue=Math.ceil(maxValue/10);

        return minValue;
    }
}
