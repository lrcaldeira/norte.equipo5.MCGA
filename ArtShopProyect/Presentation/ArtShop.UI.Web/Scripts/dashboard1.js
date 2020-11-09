$(function () {
    "use strict";
    // ############################################################
    // Sales of the Month
    // ############################################################
    var chart = c3.generate({
            bindto: '#visitor',
            data: {
                columns: [
                    ['Item A', 9],
                    ['Item B', 3],
                    ['Item C', 2],
                    ['Item D', 2],
                ],

                type: 'donut',
                tooltip: {
                    show: true
                }
            },
            donut: {
                label: {
                    show: false
                },
                title: "",
                width: 15,
            },

            legend: {
                hide: true
            },
            color: {
                pattern: ['#edf1f5', '#009efb', '#55ce63', '#745af2']
            }
    });
    // ############################################################
    // Revenue Statistics
    // ############################################################
    new Chartist.Line('.revenue', {
        labels: ['0', '4', '8', '12', '16', '20', '24', '30']
        , series: [
        [0, 2, 3.5, 0, 13, 1, 4, 1]
        , [0, 4, 0, 4, 0, 4, 0, 4]
      ]
    }, {
        high: 15
        , low: 0
        , showArea: true
        , fullWidth: true
        , plugins: [
        Chartist.plugins.tooltip()
      ], 
        // As this is axis specific we need to tell Chartist to use whole numbers only on the concerned axis
        axisY: {
            onlyInteger: true
            , offset: 20
            , labelInterpolationFnc: function (value) {
                return (value / 1) + 'k';
            }
        }
    });
    
    // ############################################################ 
    // Sales difference
    // ############################################################
    new Chartist.Pie('.sales-diff', {
        series: [35, 15, 10]
    }, {
        donut: true
        , donutWidth: 20
        , startAngle: 0
        , showLabel: false
    });
});



// ############################################################ 
// Sales Prediction
// ############################################################ 
var gaugeChart = echarts.init(document.getElementById('sales-prediction'));
option = {
    tooltip: {
        formatter: "{a} <br/>{b} : {c}%"
    }
    , toolbox: {
        show: false
        , feature: {
            mark: {
                show: true
            }
            , restore: {
                show: true
            }
            , saveAsImage: {
                show: true
            }
        }
    }
    , series: [
        {
            name: 'Sales'
            , type: 'gauge'
            , splitNumber: 1,
            axisLine: { 
                lineStyle: { 
                    color: [[0.2, '#029ff6'], [0.8, '#1badcb'], [1, '#42c386']]
                    , width: 20
                }
            }
            , axisTick: { 
                splitNumber: 0, 
                length: 12,
                lineStyle: { 
                    color: 'auto'
                }
            }
            , axisLabel: { 
                textStyle: { 
                    color: 'rgba(255,255,255,0.025)'
                }
            }
            , splitLine: { 
                show: false, 
                length: 50, 
                lineStyle: { 
                    color: 'auto'
                }
            }
            , pointer: {
                width: 5
                , color: '#54667a'
            }
            , title: {
                show: false
                , offsetCenter: [0, '-40%'],
                textStyle: {
                    fontWeight: 'bolder'
                }
            }
            , detail: {
                textStyle: { 
                    color: 'auto'
                    , fontSize: '12'
                    , fontWeight: 'bolder'
                }
            }
            , data: [{
                value: 50
                , name: 'Sales'
            }]
        }
    ]
};
    timeTicket = setInterval(function () {
        option.series[0].data[0].value = (Math.random() * 100).toFixed(2) - 0;
        gaugeChart.setOption(option, true);
    }, 2000)
    // use configuration item and data specified to show chart
    gaugeChart.setOption(option, true), $(function () {
    function resize() {
        setTimeout(function () {
            gaugeChart.resize()
        }, 100)
    }
    $(window).on("resize", resize), $(".sidebartoggler").on("click", resize)
});

