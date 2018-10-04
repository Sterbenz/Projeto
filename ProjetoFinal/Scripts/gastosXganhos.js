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
                            }, {
                                type: 'linear',
                                display: true,
                                position: 'right',
                                id: 'y-axis-2',

                                gridLines: {
                                    drawOnChartArea: false,
                                },
                            }],
                        }
                    }
                });
            }
        }
    });
}