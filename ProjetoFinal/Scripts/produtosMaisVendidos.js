function ProdutosVendidosNoMes() {
    var ctx = document.getElementById("myChart");
    $.ajax({
        url: "Home/MaisVendidosDoMes",
        type: "post",
        dataType: "Json",
        success: function (resultado) {
            var labels = [];
            var data = [];
            if (resultado.length === 0) {
                var nenhumRegistro = "<h1>Nenhum registro este mês</h1>"
                $("#myChart").before(nenhumRegistro);
                $("#myChart").addClass("filtro-ativo");
            }
            else {
                $("#myChart").removeClass("filtro-ativo")
                for (var i = 0; i < resultado.length; i++) {
                    labels[i] = resultado[i].Nome;
                    data[i] = resultado[i].Quantidade;
                }


                var myChart = new Chart(ctx, {
                    type: 'pie',
                    data: {
                        labels: labels,
                        datasets: [{
                            label: '# of Votes',
                            data: data,
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.4)',
                                'rgba(54, 162, 235, 0.4)',
                                'rgba(255, 206, 86, 0.4)',
                                'rgba(75, 192, 192, 0.4)',
                                'rgba(153, 102, 255, 0.4)',
                                'rgba(255, 159, 64, 0.4)'
                            ],
                            borderColor: [
                                'rgba(255,99,132,1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(255, 206, 86, 1)',
                                'rgba(75, 192, 192, 1)',
                                'rgba(153, 102, 255, 1)',
                                'rgba(255, 159, 64, 1)'
                            ],
                            borderWidth: 1
                        }],

                    },

                });
            }
            
        }
    });
    
}