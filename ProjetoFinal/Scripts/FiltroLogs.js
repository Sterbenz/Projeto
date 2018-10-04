﻿$(document).ready(function () {
    var filtro = $("#filtro-logs-gerais :selected").val();
    verificaFiltro(filtro);
});

$("#filtro-logs-gerais").change(function () {
    var filtro = $("#filtro-logs-gerais :selected").val();
    verificaFiltro(filtro);
});

function verificaFiltro(filtro) {    
    
    var logs_pessoas      = $(".logs-pessoas");
    var logs_produtos     = $(".logs-produtos");
    var logs_familias     = $(".logs-familias");
    var logs_vendas       = $(".logs-vendas");
    var logs_compras       = $(".logs-compras");
    var logs_fornecedores = $(".logs-fornecedores");
    

    if (filtro == "Geral") {

        logs_pessoas.removeClass("filtro-ativo");
        logs_produtos.removeClass("filtro-ativo");
        logs_familias.removeClass("filtro-ativo");
        logs_fornecedores.removeClass("filtro-ativo");
        logs_vendas.addClass("filtro-ativo");
        logs_compras.addClass("filtro-ativo");
    }
    else if (filtro == "Pessoas") {
        logs_pessoas.removeClass("filtro-ativo");
        logs_produtos.addClass("filtro-ativo");
        logs_familias.addClass("filtro-ativo");
        logs_fornecedores.addClass("filtro-ativo");
        logs_vendas.addClass("filtro-ativo");
        logs_compras.addClass("filtro-ativo");
    }
    else if (filtro == "Fornecedores") {
        logs_pessoas.addClass("filtro-ativo");
        logs_produtos.addClass("filtro-ativo");
        logs_familias.addClass("filtro-ativo");
        logs_fornecedores.removeClass("filtro-ativo");
        logs_vendas.addClass("filtro-ativo");
        logs_compras.addClass("filtro-ativo");
    }
    else if (filtro == "Produtos") {
        logs_pessoas.addClass("filtro-ativo");
        logs_produtos.removeClass("filtro-ativo");
        logs_familias.addClass("filtro-ativo");
        logs_fornecedores.addClass("filtro-ativo");
        logs_vendas.addClass("filtro-ativo");
        logs_compras.addClass("filtro-ativo");
    }
    else if (filtro == "Familias") {
        logs_pessoas.addClass("filtro-ativo");
        logs_produtos.addClass("filtro-ativo");
        logs_familias.removeClass("filtro-ativo");
        logs_fornecedores.addClass("filtro-ativo");
        logs_vendas.addClass("filtro-ativo");
        logs_compras.addClass("filtro-ativo");
    }
    else if (filtro == "Vendas") {
        logs_pessoas.addClass("filtro-ativo");
        logs_produtos.addClass("filtro-ativo");
        logs_familias.addClass("filtro-ativo");
        logs_fornecedores.addClass("filtro-ativo");
        logs_compras.addClass("filtro-ativo");
        logs_vendas.removeClass("filtro-ativo");
    }
    else if (filtro == "Compras") {
        logs_pessoas.addClass("filtro-ativo");
        logs_produtos.addClass("filtro-ativo");
        logs_familias.addClass("filtro-ativo");
        logs_compras.removeClass("filtro-ativo");
        logs_fornecedores.addClass("filtro-ativo");
        logs_vendas.addClass("filtro-ativo");
    }
}