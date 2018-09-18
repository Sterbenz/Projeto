$(document).ready(function () {
    $('.data').mask('00/00/0000');
    $('.cep').mask('00000-000');
    $('.telefone').mask('(00) 00000-0000');
    $('.cpf').mask('000.000.000-00', { reverse: false });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });
});

$(document).on("input", function () {
    $('.data').mask('00/00/0000');
    $('.cep').mask('00000-000');
    $('.telefone').mask('(00) 00000-0000');
    $('.cpf').mask('000.000.000-00', { reverse: false });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });
});
