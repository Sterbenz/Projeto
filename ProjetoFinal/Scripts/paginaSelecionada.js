var sel_logs = $("#selecao-logs");
var sel_home = $("#selecao-home");
var sel_produto = $("#selecao-produto");
var sel_cliente = $("#selecao-cliente");
var sel_familia = $("#selecao-familia");
var sel_fornecedor = $("#selecao-fornecedor");
var sel_funcionario = $("#selecao-funcionario");
var sel_fornecedor_pedidos = $("#selecao-fornecedor-pedidos");
var sel_fornecedor_index = $("#selecao-fornecedor-lista");
var sel_compra = $("#selecao-compra");


$(document).ready(function () {
    var url = window.location.href;

    if (/Fornecedor/.test(url)) {
        removeSelecoesMenus();
        sel_fornecedor.addClass("active");
        if (!/Acompanhamentos/.test(url)) {
            sel_fornecedor_index.addClass("active");
        }
        else if (/Acompanhamentos/.test(url)) {
            sel_fornecedor_pedidos.addClass("active");
        }
    }
    else if (/Cliente/.test(url)) {
        removeSelecoesMenus();
        sel_cliente.addClass("active");
    }    

    else if (/Categoria/.test(url)) {
        removeSelecoesMenus();
        sel_familia.addClass("active");
    }

    else if (/Funcionario/.test(url)) {
        removeSelecoesMenus();
        sel_funcionario.addClass("active");
    }

    else if (/Produto/.test(url)) {
        removeSelecoesMenus();
        sel_produto.addClass("active");
    }

    else if (/Venda/.test(url)) {
        removeSelecoesMenus();
        sel_compra.addClass("active");
    }

    else if (/Logs/.test(url)) {
        removeSelecoesMenus();
        sel_logs.addClass("active");
    }

    else if (/Home/.test(url) && !/Logs/.test(url) || /^null|$/.test(url) && !/Logs/.test(url)) {
        removeSelecoesMenus();
        sel_home.addClass("active");
    }

});

function removeSelecoesMenus() {

    
    
    sel_logs.removeClass("active");
    sel_home.removeClass("active");
    sel_produto.removeClass("active");
    sel_cliente.removeClass("active");
    sel_familia.removeClass("active");
    sel_fornecedor.removeClass("active");
    sel_compra.removeClass("active");
    sel_funcionario.removeClass("active");
}

$(".carrega-graficos").click(function () {
    ProdutosVendidosNoMes();
    GastosXGanhos();
});
