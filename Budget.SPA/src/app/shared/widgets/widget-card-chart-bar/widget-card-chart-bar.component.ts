import { Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { WidgetCardChartBar } from 'app/model/chart/widget-card-chart-bar.model';
import { ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { WidgetCardChartBarSkeleton } from './widget-card-chart-bar.model';

@Component({
    selector: 'widget-card-chart-bar',
    templateUrl: './widget-card-chart-bar.component.html',
    // styleUrls: ['./widget-card-chart-bar.component.scss'],
    animations   : fuseAnimations
  })
export class WidgetCardChartBarComponent implements OnInit, OnChanges {
@Input() widgetCardChartBar: WidgetCardChartBar;
@ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;

widget: WidgetCardChartBar;
isLoaded: boolean;

// public barChartOptions: ChartConfiguration['options'] = {
//     responsive: true,
//     maintainAspectRatio: false,
//     // We use these empty structures as placeholders for dynamic theming.
//     scales             : {
//         xAxis:
//             {
//                 display: false,
//                 ticks: {
//                     display: false,
//                     stepSize: 500
//                 }
//             }
//         ,
//         yAxis:
//             {
//                 display: false,
//                 ticks  : {
//                 }
//             }

//     },
//     plugins: {
//       legend: {
//         display: false,
//       }
//     }
//   };
//   public barChartType: ChartType = 'bar';
//   public barChartPlugins = [
//     DataLabelsPlugin
//   ];

    // public barChartData: ChartData<'bar'> = {
    //     labels: [ '2006', '2007', '2008', '2009', '2010', '2011', '2012' ],
    //     datasets: [
    //     {
    //         data: [ 65, 59, 80, 81, 56, 55, 40 ],
    //         label: 'Series A',
    //         backgroundColor: ['#FF7360','#6FC8CE','#6FC8CE','#FFFCC4','#FFFCC4','#FFFCC4','#FFFCC4'],
    //         hoverBackgroundColor: ['#FF7360','#6FC8CE','#6FC8CE','#FFFCC4','#FFFCC4','#FFFCC4','#FFFCC4']
    //         //   borderColor: ['#FF7360','#FF7360','#FF7360','#FF7360','#FF7360','#FF7360','#FF7360'],
    //     }
    //     ],
    // };

    constructor() {
        this.widget = new WidgetCardChartBar();
        this.widget.chart.options =  WidgetCardChartBarSkeleton.getChartOptions;
    }

    // events
    public chartClicked({ event, active }: { event?: ChartEvent, active?: {}[] }): void {
        console.log(event, active);
    }

  public chartHovered({ event, active }: { event?: ChartEvent, active?: {}[] }): void {
    console.log(event, active);
  }

    ngOnChanges(changes: SimpleChanges): void {
    //   this.isLoaded = false;
        this.widgetCardChartBar = changes.widgetCardChartBar.currentValue;

        console.log('onChange-widgetCardChartBar', this.widgetCardChartBar);
        if(this.widgetCardChartBar) {
            this.widget.title= JSON.parse(JSON.stringify(this.widgetCardChartBar?.title));
            this.widget.chart.data=JSON.parse(JSON.stringify(this.widgetCardChartBar?.chart?.data));
        }


    //.labels = this.widgetCardChartBar.chart.labels.map(x=>x.label);
    //   this.widget.datasets = // this.widgetCardChartBar.chart.dataSets;
    //   this.widget.options = this.barChartOptions;
    //   this.widget.type = 'bar';
    //   if(this.widgetCardChartBar?.isLoaded) {
    //     // if(this.widgetCardChartBar.isLoaded) {

    //     //   this.widget = null;
    //       this.widget= WidgetCardChartBarSkeleton.getEmptyGraph;
    //     //   this.widget.datasets = this.widgetCardChartBar.chart.dataSets;
    //     //   this.widget.labels = this.widgetCardChartBar.chart.labels.map(x=>x.label);
    //     // //   this.widget.colors = this.widgetCardChartBar.chart.colors;
    //     //   this.widget.title = this.widgetCardChartBar.title;
    //     //   this.widget.options.scales.yAxes = this.widgetCardChartBar.chart.options.scales.yAxes;

    //     //   //force refresh graph
    //     //   setTimeout(() => {
    //     //     if(this._chart) {
    //     //         this._chart.refresh();
    //     //     }
    //     //   }, 100);

    //       this.isLoaded=true;

    //     // }
    //   }
    }

    ngOnInit(): void {
        console.log('onInit', this.widget);

        // this.widget.chart = WidgetCardChartBarSkeleton.getEmptyGraph;
        // this.chart?.update(); //.refresh();
    }

    // chartClicked($event): void {
    //   // console.log('chart-event',$event);
    //   // console.log("Index", $event.active[0]._index);
    //   // console.log("Data" , $event.active[0]._chart.config.data.datasets[0].data[$event.active[0]._index]);
    //   // console.log("Label" , $event.active[0]._chart.config.data.labels[$event.active[0]._index]);
    // }


  }
