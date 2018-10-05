$(document).ready(function () {
    var url = window.location.href;

    if (/Fornecedor/.test(url)) {
        if (!/Acompanhamentos/.test(url)) {
        }
        else if (/Acompanhamentos/.test(url)) {
        }
    }
    else if (/Cliente/.test(url)) {
    }

    else if (/Categoria/.test(url)) {
    }

    else if (/Funcionario/.test(url)) {
    }

    else if (/Produto/.test(url)) {
    }

    else if (/Venda/.test(url)) {
    }

    else if (/Logs/.test(url)) {
    }

    else if (/Home/.test(url) && !/Logs/.test(url) || /^null|$/.test(url) && !/Logs/.test(url)) {
        ProdutosVendidosNoMes();
        GastosXGanhos();
    }

});

function GastosXGanhos() {
    var ctx = document.getElementById("myChart").getContext('2d');

    $.ajax({
        url: "Home/GanhosEGastos",
        type: "post",
        dataType: "Json",
        success: function (resultado) {
            var Ganhos = resultado.Ganhos;
            var Gastos = resultado.Gastos;

            var labelsGanhos = [];
            var dataGanhos = [];

            var dataGastos = [];

            if (resultado.length === 0) {
                var nenhumRegistro = "<h1>Nenhum registro feito!</h1>"
                $("#grafico-mais-vendidos").before(nenhumRegistro);
                $("#grafico-mais-vendidos").addClass("filtro-ativo");
            }
            else {
                
                for (var i = 0; i < Ganhos.length; i++) {
                    labelsGanhos[i] = Ganhos[i].Data;
                    dataGanhos[i] = Ganhos[i].ValorTotal;
                }

                for (var i = 0; i < Gastos.length; i++) {
                    dataGastos[i] = Gastos[i].ValorTotal;
                }

                var myChart = Chart.Line(ctx, {
                    data: {
                        labels: labelsGanhos,
                        datasets: [{
                            label: 'Ganhos',
                            backgroundColor: [
                                'rgba(255, 159, 64, 0.2)'
                            ],
                            borderColor: [
                                'rgba(255, 159, 64, 1)'
                            ],
                            fill: false,
                            data: dataGanhos,
                            yAxisID: 'y-axis-1',
                        }, {
                            label: 'Gastos',
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.2)',
                            ],
                            borderColor: [
                                'rgba(255,99,132,1)',
                            ],
                            fill: false,
                            data: dataGastos,
                            yAxisID: 'y-axis-2'
                        }]
                    },
                    options: {
                        responsive: true,
                        hoverMode: 'index',
                        stacked: false,
                        scales: {
                            yAxes: [{
                                type: 'linear',
                                display: true,
                                position: 'left',
                                id: 'y-axis-1',
                                ticks: {
                                    beginAtZero: true,
                                    callback: function (value, index, values) {
                                        if (parseInt(value) >= 1000) {
                                            return '$' + formatReal(value);
                                        } else {
                                            return '$' + value;
                                        }
                                    }
                                }
                            }, {
                                type: 'linear',
                                display: true,
                                position: 'right',
                                id: 'y-axis-2',
                                ticks: {
                                    beginAtZero: true,
                                    callback: function (value, index, values) {
                                            if (parseInt(value) >= 1000) {
                                                return '$' + formatReal(value);
                                        } else {
                                            return '$' + value;
                                        }
                                    }
                                },
                                gridLines: {
                                    drawOnChartArea: false,
                                },
                            }],
                        },
                    }
                });
            }
        }
    });
}

function formatReal(int) {
    var tmp = int + '';
    tmp = tmp.replace(/([0-9]{2})$/g, ",$1");
    if (tmp.length > 6)
        tmp = tmp.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");

    return tmp;
}