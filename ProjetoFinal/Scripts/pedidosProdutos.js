﻿var produtos = [];
var total = 0;
$("#adicionar-produto-pedidos").click(function (event) {
    var teste = $("#produtos-lista-pedidos :selected").text();
    
    if (teste == "Produtos") {
        alert("Essa opção não é um produto selecionavel");
    }
    else {
        var valor = document.querySelector("#valor-produto-pedido").value;
        valor = valor.replace(/[^\d]/g, '');
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
                console.log(true);
                $("#tabela-pedidos-fornecedores").append("<tr id =" + id + "><td>" + resposta.Nome +
                    "</td><td class='dinheiro'> R$ " + valor +
                    "</td><td>" + quantidade +
                    "</td><td class='dinheiro'> R$ " + (valor * quantidade) +
                    "</td></tr>");
                total += (valor * quantidade);
                $("#tabela-pedidos-fornecedores").append("<tr id='valor-total-pedido'><td colspan='3'></td><td class='bg-warning dinheiro'>R$ "+ total +"</td></tr>");
                adicionaListaPedidos(resposta, valor, quantidade);
            },
            error: function () {
                alert("falhou");
            }
        });
    }
});

function adicionaListaPedidos(resposta, valor, quantidade) {   

    resposta.Quantidade = quantidade;
    resposta.PrecoPorUnidade = valor;   

    produtos.push(resposta);   
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
               
                $("#tabela-pedidos-fornecedores").append("<tr id='valor-total-pedido'><td colspan='3'></td><td class='bg-warning dinheiro'>R$ " + total + "</td></tr>");
                break;
            }

        }
        console.log(produtos);
    }, 500);

});

$("#btn-registra-pedido").click(function () {
    var id = $("#id-fornecedor").text();
    
    $.ajax({

        url: "/Fornecedor/RealizaPedido",
        data: { id: id, pedidos: produtos, valorTotal: total },
        type: "post",
        dataType: "Json"        
    });
});

$("#produtos-lista-pedidos").change(function () {
    var id = document.querySelector("#produtos-lista-pedidos").value;
    var url = "/Home/BuscaProduto";
    $.ajax({

        url: url,
        data: { id: id },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            $("#quantidade-produto-estoque").val(resposta.Quantidade);
            $("#quantidade-produto-pedido").val(1);
            $("#valor-produto-pedido").val(1);     
            
        },
        error: function () {
            alert("falhou");
        }
    });
    
});
$("#produtos-lista-pedidos").change(function () {
    var teste = $("#produtos-lista-pedidos :selected").text();
    console.log(teste)

});
