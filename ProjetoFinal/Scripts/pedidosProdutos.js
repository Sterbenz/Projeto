var produtos = [];
var total = 0;
$("#adicionar-produto-pedidos").click(function (event) {

    var valor = document.querySelector("#valor-produto-pedido").value;
    var quantidade = document.querySelector("#quantidade-produto-pedido").value;
    var id = document.querySelector("#produtos-lista-pedidos").value;
    var url = "/Home/BuscaProduto";
    
    $.ajax({

        url: url,
        data: { id: id },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            $("#nada-no-pedido").remove();
            if ($("#valor-total-pedido").length) {
                console.log(true);
                $("#valor-total-pedido").remove();
            }
            
            $("#tabela-pedidos-fornecedores").append("<tr id =" + id + "><td>" + resposta.Nome +
                "</td><td>" + resposta.Quantidade +
                "</td><td> R$ " + valor +
                "</td><td>" + quantidade +
                "</td><td> R$ " + (valor * quantidade) +
                "</td></tr>");
            total += (valor * quantidade);
            $("#tabela-pedidos-fornecedores").append("<tr id='valor-total-pedido'><td colspan='4'></td><td class='bg-warning'>R$ "+ total +"</td></tr>");
            adicionaListaPedidos(resposta, valor, quantidade);
        },
        error: function () {
            alert("falhou");
        }
    });
    
});

function adicionaListaPedidos(resposta, valor, quantidade) {   

    resposta.Quantidade = quantidade;
    resposta.PrecoPorUnidade = valor;   

    produtos.push(resposta);

    console.log(produtos);
    console.log(produtos.length);
}


$("#tabela-pedidos").dblclick(function (event) {
    var selec = event.target.parentNode;
    selec.classList.add("fadeOut");

    setTimeout(function () {
        selec.remove();
        for (var i = 0; i < produtos.length; i++) {
            if (produtos[i].Id == selec.id) {
                console.log(produtos.PrecoPorUnidade);
                console.log(total);
                console.log(total - produtos.PrecoPorUnidade);
                total = total - produtos[i].PrecoPorUnidade;
                produtos.splice(i, 1);
                if ($("#valor-total-pedido").length) {
                    console.log(true);
                    $("#valor-total-pedido").remove();
                }
               
                $("#tabela-pedidos-fornecedores").append("<tr id='valor-total-pedido'><td colspan='4'></td><td class='bg-warning'>R$ " + total + "</td></tr>");
                break;
            }

        }
        console.log(produtos);
    }, 500);

});

