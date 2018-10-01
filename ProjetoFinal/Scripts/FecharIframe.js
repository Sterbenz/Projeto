function fecharModal(res) {
    $.ajax({
        url: "/Produto/Index",
        success: function () {
            $("#novoProdutoModal").toggle();
        }
    });    
}