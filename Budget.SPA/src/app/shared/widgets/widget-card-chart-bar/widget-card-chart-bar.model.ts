import { BaseChartBar } from 'app/model/chart/base-chart.model';
import { ChartConfiguration } from 'chart.js';

export class WidgetCardChartBarSkeleton {

    public static get getChartOptions(): ChartConfiguration['options'] {

        return {
            responsive: true,
            maintainAspectRatio: false,
            // We use these empty structures as placeholders for dynamic theming.
            scales             : {
                xAxis:
                    {
                        display: false,
                        ticks: {
                            display: false,
                            stepSize: 500
                        }
                    }
                ,
                yAxis:
                    {
                        display: false,
                        ticks  : {
                        }
                    }

            },
            plugins: {
              legend: {
                display: false,
              }
            }
          };
    }
}



            // title: {},
            // chartType : 'bar',
            // datasets  : [{ data: [45, 37, 60, 70], label: 'Best Fruits' }],
            // labels    : ['A','B','C','E'],
            // colors    : [ {
            //     backgroundColor: ['#FF7360','#6FC8CE','#6FC8CE','#FFFCC4']
            //     // borderColor    : ['#E83026','#E83026','#E83026','#E83026'],
            //     // hoverBackgroundColor: ['#0F172A','#0F172A','#0F172A','#0F172A']
            //     // // hoverBorderWidth : '0'
            // }],
            // options   : {
            //     spanGaps           : false,
            //     legend             : {
            //         display: false
            //     },
            //     maintainAspectRatio: false,
            //     layout             : {
            //         padding: {
            //             top   : 24,
            //             left  : 16,
            //             right : 16,
            //             bottom: 16
            //         }
            //     }

            // }
//         };
//     }
// }



// scales             : {
//     xAxes: [
//         {
//             display: false,
//             ticks: {
//                 display: false,
//                 step: 1000
//             }
//         }
//     ],
//     yAxes: [
//         {
//             display: false,
//             ticks  : {
//                 min: -5000,
//                 max: 0
//             }
//         }
//     ]
// }
