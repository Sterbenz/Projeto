
$("#filtrar-produtos").on("input", function () {
    
    var produtos = document.querySelectorAll(".produto");

    var selecionado = $("#tipo-filtro-produto :selected").val();
    var placeholder = $("#filtrar-produtos");

    if (selecionado == "nome") {
        var filtro = ".prod-nome";
    }
    else if (selecionado == "familia") {
        var filtro = ".prod-familia";
    }

    if (this.value.length > 0) {
        for (var i = 0; i < produtos.length; i++) {
            var produto = produtos[i];
            var tdNome = produto.querySelector(filtro);
            var nome = tdNome.textContent;
            
            var regex = new RegExp(this.value, "i");

            if (!regex.test(nome)) {
                produto.classList.add("filtro-ativo");
            } else {
                produto.classList.remove("filtro-ativo");
            }
        }
    } else {
        for (var i = 0; i < produtos.length; i++) {
            var produto = produtos[i];
            produto.classList.remove("filtro-ativo");
        }
    }
});