$("#adicionar-produto-pedidos").click(function (event) {
    $("#nada-no-pedido").remove();
    var valor = document.querySelector("#valor-produto-pedido");
    var quantidade = document.querySelector("#quantidade-produto-pedido");
    var id = document.querySelector("#produtos-lista-pedidos").value;
    var url = "Home/BuscaProduto";
    buscarProduto(url, id);
});

function buscarProduto(url, id) {
    alert("teste");
    $.ajax({

        url: url,
        data: { id: id },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            $("#tabela-pedidos-fornecedores").append("<tr id =" + id + "><td>" + '11' +
        "</td><td>" + '12' +
        "</td><td>" + '320' +
        "</td><td>" + '100' +
        "</td><td>" + 'R$ 3.200' +
        "</td></tr>");
        }
    });
    alert("teste2");
}