var produtos = [];
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
            $("#tabela-pedidos-fornecedores").append("<tr id =" + id + "><td>" + resposta.Nome +
                "</td><td>" + resposta.Quantidade +
                "</td><td> R$ " + valor +
                "</td><td>" + quantidade +
                "</td><td> R$ " + (valor * quantidade) +
                "</td></tr>");
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
            if (produtos[i].Id == selec.id)
                produtos.splice(i, 1);
        }
        console.log(produtos);
    }, 500);

});

