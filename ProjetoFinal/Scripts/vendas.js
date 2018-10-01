var produtos = [];
var total = 0;
var produtosAdicionados = [];

// Chama metodo para buscar o cliente
$("#clientes-compras").change(function () {
    var cli_id = $("#clientes-compras :selected").val();
    BuscaCliente(cli_id);
});

// Busca dados do cliente selecionado
function BuscaCliente(id) {
    var url = "/Home/BuscaCliente";
    $.ajax({
        url: url,
        data: { id: id },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            $("#cpf-cliente").val(resposta.Cpf);
            $("#email-cliente").val(resposta.Email);
            $("#telefone-cliente").val(resposta.Telefone);
        }
    });
}

// Adiciona o produto na tabela
$("#adicionar-produto-venda").click(function (event) {
    var teste = $("#produtos-lista-venda :selected").text();
    var tem = verificaItem();
    var valoresNulos = verificaValoresItem();

    if (tem == true || valoresNulos == true) {
        alert("Esse produto já foi adicionado ou valores incorretos");
    }
    else {
        if (teste == "Produtos") {
            alert("Essa opção não é um produto selecionavel");
        }
        else {
            var valor = document.querySelector("#valor-produto-venda").value;
            valor = valor.replace(/[^\d]/g, '');
            var quantidade = document.querySelector("#quantidade-produto-venda").value;
            var id = document.querySelector("#produtos-lista-venda").value;
            var url = "/Home/BuscaProduto";
            $.ajax({

                url: url,
                data: { id: id },
                type: "post",
                dataType: "Json",
                success: function (resposta) {
                    valor = valor.replace(/[^\d]/g, '');
                    $("#nada-na-venda").remove();
                    if ($("#valor-total-venda").length) {
                        $("#valor-total-venda").remove();
                    }
                    $("#tabela-venda-clientes").append("<tr id =" + id + "><td>" + resposta.Nome +
                        "</td><td class='dinheiro'>" + valor +
                        "</td><td>" + quantidade +
                        "</td><td class='dinheiro'>" + (valor * quantidade) +
                        "</td></tr>");
                    total += (valor * quantidade);
                    $("#tabela-venda-clientes").append("<tr id='valor-total-venda'><td colspan='3'></td><td class='bg-warning dinheiro'>" + total + "</td></tr>");
                    adicionaListaPedidos(resposta, valor, quantidade);
                },
                error: function () {
                    alert("falhou");
                }
            });
        }
    }
});

// Adiciona o produto no Array da venda
function adicionaListaPedidos(resposta, valor, quantidade) {

    resposta.Quantidade = quantidade;
    resposta.PrecoPorUnidade = valor;
    produtosAdicionados.push(resposta.Id);
    produtos.push(resposta);

}

// Verifica se o produto já esta no pedido
function verificaItem() {
    var Tem = false;

    if (produtosAdicionados.length == 0) {
        var Tem = false;
    }
    else {
        for (var i = 0; i < produtosAdicionados.length; i++) {
            var id = document.querySelector("#produtos-lista-venda").value;

            if (id == produtosAdicionados[i]) {
                Tem = true;
            }
        }
    }
    return Tem;
}

// Apaga item da tabela
$("#tabela-venda").dblclick(function (event) {
    var selec = event.target.parentNode;
    selec.classList.add("fadeOut");

    setTimeout(function () {
        selec.remove();
        for (var i = 0; i < produtos.length; i++) {
            if (produtos[i].Id == selec.id) {
                total = total - (produtos[i].PrecoPorUnidade * produtos[i].Quantidade);
                produtos.splice(i, 1);
                produtosAdicionados.splice(i, 1);
                if ($("#valor-total-venda").length) {
                    $("#valor-total-venda").remove();
                }

                $("#tabela-venda-clientes").append("<tr id='valor-total-venda'><td colspan='3'></td><td class='bg-warning dinheiro'>R$ " + total + "</td></tr>");
                break;
            }

        }
    }, 500);

});

// Pega dados sobre o produto escolhido
$("#produtos-lista-venda").change(function () {
    var id = document.querySelector("#produtos-lista-venda").value;
    var url = "/Home/BuscaProduto";

    $.ajax({

        url: url,
        data: { id: id },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            $("#quantidade-produto-estoque-venda").val(resposta.Quantidade);
            $("#quantidade-produto-venda").attr({
                "max": resposta.Quantidade,
                "min": 0
            });
            $("#quantidade-produto-venda").val(1);
            $("#valor-produto-venda").val(1);

        },
        error: function () {
            alert("falhou");
        }
    });

});

// Muda quantidade automaticamente ao exeder quantidade em estoque
$("#quantidade-produto-venda").blur(function () {
    var quantidade = $("#quantidade-produto-estoque-venda").val();
    var quantidadeVenda = $("#quantidade-produto-venda").val();
    if (parseInt(quantidadeVenda) > parseInt(quantidade)) {

        $("#quantidade-produto-venda").val(quantidade);
    }
});

// Verifica valores nulos
function verificaValoresItem() {
    var quantidade = $("#quantidade-produto-venda").val();
    var valor = $("#valor-produto-venda").val();
    if (quantidade == "" || valor == "") {
        return true;
    }
    else {
        return false;
    }
}

// Finaliza a compra
$("#btn-registra-venda").click(function () {
    var id = $("#clientes-compras :selected").val();

    if (total == null || produtos.length == 0) {
        alert("Nenhum produto adicionado ao pedido!");
    }
    else {
        $.ajax({
            url: "/Venda/RealizaVenda",
            data: { id: id, model: produtos, valorTotal: total },
            type: "post",
            dataType: "Json",
            success: function (resposta) {
                location.href = "/Home";
            }
        });
    }
});