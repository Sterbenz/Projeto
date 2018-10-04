function ConfirmarEntregaFornecedores(id) {
    var fornecedorId = "#" + id;
    $.ajax({

        url: "/Fornecedor/ConfirmarEntrega",
        data: { id: id },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            $("#estado-pedido").text("Entregue");
            $(fornecedorId).attr("disabled", true);
        }
    });
}

function texte() {
    $("#estado-pedido").text("Entregue");
    $(fornecedorId).attr("disabled", true);
}