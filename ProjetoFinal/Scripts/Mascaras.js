$(document).ready(function () {
    $('.data').mask('00/00/0000');
    $('.cep').mask('00000-000');
    $('.telefone').mask(maskBehavior, options);
    $('.cpf').mask('000.000.000-00', { reverse: false });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: false });
    //$('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });
});

$(document).on("input", function () {
    $('.data').mask('00/00/0000');
    $('.cep').mask('00000-000');
    $('.telefone').mask(maskBehavior, options);
    $('.cpf').mask('000.000.000-00', { reverse: false });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: false });
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });
});


var maskBehavior = function (val) {
  return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
},
options = {onKeyPress: function(val, e, field, options) {
        field.mask(maskBehavior.apply({}, arguments), options);
    }
};