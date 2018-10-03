function ProdutosVendidosNoMes() {
    var ctx = document.getElementById("myChart");
    $.ajax({
        url: "Home/MaisVendidosDoMes",
        type: "post",
        dataType: "Json",
        success: function (resultado) {

            console.log(resultado.Quantidade);
            var myChart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: [resultado.Nome],
                    datasets: [{
                        label: '# of Votes',
                        data: [2],
                    }],
                    borderWidth: 1
                },

            });
        }
    });
    
}