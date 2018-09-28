function ConfirmarEntregaFornecedores(id) {
    $.ajax({

        url: "/Fornecedor/ConfirmarEntrega",
        data: { id: id },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            $("#estado-pedido").Text("Entregue");
            $("#botao-confirma-entrega").attr("disabled", true);
            console.log(true);
        }
    });
}