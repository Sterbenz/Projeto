function fecharModal(res) {
    $.ajax({
        url: "/Produto/Index",
        success: function () {
            $("#novoProdutoModal").toggle();
            console.log($(document));
            console.log($("#novoProdutoModal"));
        }
    });    
}