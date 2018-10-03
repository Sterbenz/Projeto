function ProdutosVendidosNoMes() {
    var ctx = document.getElementById("myChart");
    $.ajax({
        url: "Home/MaisVendidosDoMes",
        type: "post",
        dataType: "Json",
        success: function (resultado) {
            var labels;
            var data    ;
            for (var i = 0; i < resultado.length; i++) {
                labels[i] = resultado[i].Nome;
                data[i] = resultado[i].Quantidade;
            }
            console.log(labels[i]);
            console.log(data[i]);
            
            /*var myChart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: [resultado.Nome],
                    datasets: [{
                        label: '# of Votes',
                        data: [resultado.Quantidade],
                    }],
                    borderWidth: 1
                },

            });*/
        }
    });
    
}