$(".info-pedido-acompanhamento").click(function (e) {
    $("#modal-informacoes-acompanhamento").show();
    var teste = e.target;
    
    var id = $(teste).attr("name")
    preencheCamposInfoPedido(id);
});

$("#fechar-modal-info-pedidos").click(function () {
    $("#modal-informacoes-acompanhamento").hide();
});

function preencheCamposInfoPedido(id) {
    var pedidoId = $("#id-pedido-informacao");
    var fornecedorNome = $("#nome-fornecedor-informacoes");
    var status = $("#status-pedido-informacoes");
    var valorTotal = $("#valor-Total-informacoes");
    $("#body-tabela-produtos-pedidos tr").remove();

    $.ajax({
        url: "/Fornecedor/VisualizaPedido",
        data: { id: id },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            var acompanhamento = resposta.Acompanhamento;
            var produtos       = resposta.PP;

            $(pedidoId).text(acompanhamento[0].PedidoId);
            $(fornecedorNome).val(acompanhamento[0].Fornecedor);
            $(valorTotal).val(acompanhamento[0].ValorTotal);
            $(valorTotal).mask('000.000.000.000.000,00', { reverse: true });
            if (acompanhamento[0].Status == true) {
                $(status).val("Entregue");
            } else {
                $(status).val("Em espera");
            }
            for (var i = 0; i < produtos.length; i++) {
                $("#body-tabela-produtos-pedidos").append("<tr><td>" + produtos[i].ProdutoId +
                    "</td><td>" + produtos[i].ProdutoNome +
                    "</td><td>" + produtos[i].Quantidade + "</td></tr>");
            }
        }
    });
}