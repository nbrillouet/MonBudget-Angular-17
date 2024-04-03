
// var point = this.getElementAtEvent(e);
// if (point.length) e.target.style.cursor = 'pointer';
// else e.target.style.cursor = 'default';

export class WidgetCardChartBarModel {

    public static get getEmptyGraph(): any {
        return {
            conversion: {},
            chartType : 'bar',
            datasets  : [],
            labels    : [],

            // colors    : [
            //     {
            //         borderColor    : '#42a5f5',
            //         backgroundColor: '#42a5f5'
            //     }
            // ],
            options   : {
                // onClick: (e) => {

                // },
                onHover: (evt, activeEls) => {
                    activeEls.length > 0 ? evt.chart.canvas.style.cursor = 'pointer' : evt.chart.canvas.style.cursor = 'default';
                },
                scaleShowValues: true,
                scales: {
                    y: {
                        beginAtZero: true
                    },
                    x: {
                        ticks: {
                            autoSkip: false
                        }
                    }
                },
                plugins: {
                    legend: {
                        display: false
                    }
                }

                // plugins: {
                //     datalabels: {
                //       listeners: {
                //         enter: (ctx) => {
                //           ctx.chart.canvas.style.cursor = 'pointer'
                //         },
                //         leave: (ctx) => {
                //           ctx.chart.canvas.style.cursor = 'default'
                //         }
                //       }
                //     }
                //   },
                // hover: {
                //     onHover: (evt, activeEls) => {

                //         activeEls.length > 0 ? evt.chart.canvas.style.cursor = 'pointer' : evt.chart.canvas.style.cursor = 'default';
                //       }

                //  },
                // spanGaps           : false,
                // legend             : {
                //     display: false
                // },
                // maintainAspectRatio: false,
                // layout             : {
                //     padding: {
                //         top   : 0,
                //         left  : 0,
                //         right : 0,
                //         bottom: 0
                //     }
                // },
                // scales             : {
                //     xAxes: [
                //         {
                //             callback: function(value) {
                //                 return value.substr(0, 2);
                //             }
                //         }
                //     ],
                //     yAxes: [
                //         {
                //             display: true,
                //             ticks  : {

                //                 stepValue:0
                //             }
                //         }
                //     ]
                // }
            }
        };
    }
}
