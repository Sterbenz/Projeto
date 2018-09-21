$(".form-validacao-pessoa").submit(function () {

    if (!validaCampos()) {
        console.log("fase 1");
            return false;
     }
    else {
        console.log("fase 2");
        return true;
     }
});

$(".form-validacao-produto").submit(function () {

    if (!validaCamposProduto()) {
        console.log("fase 1");
        return false;
    }
    else {
        console.log("fase 2");
        return true;
    }
});


function validaCampos() {
    if (validaNome(), validaCpf(), validaDataNascimento(), validaEmail()) {
        console.log(true);
        return true;
    } else {
        console.log(false);
        return false;
    }
}

function validaCamposProduto() {
    if (validaNome(), validaValor(), validaQuantidade()) {
        console.log(true);
        return true;
    } else {
        console.log(false);
        return false;
    }
}

function validaNome() {
    var nomeClass = $(".form-nome");
    var nomeText = $(".form-nome").val();

    if (nomeText == "") {
        nomeClass.removeClass(" valido");
        nomeClass.addClass(" invalido");
        return false;
    }
    else {
        nomeClass.removeClass(" invalido");
        nomeClass.addClass(" valido");
        return true;
    }
}

function validaCpf() {
    var cpfClass = $(".form-cpf");
    var cpfText = $(".form-cpf").val();

    if (cpfText == "") {
        cpfClass.removeClass(" valido");
        cpfClass.addClass(" invalido");
        return false;
    }
    else {
        cpfClass.removeClass(" invalido");
        cpfClass.addClass(" valido");
        return true;
    }
}

function validaDataNascimento() {
    var dataNascimentoClass = $(".form-data-nascimento");
    var dataNascimentoText = $(".form-data-nascimento").val();

    if (dataNascimentoText == "") {
        dataNascimentoClass.removeClass(" valido");
        dataNascimentoClass.addClass(" invalido");
        return false;
    }
    else {
        dataNascimentoClass.removeClass(" invalido");
        dataNascimentoClass.addClass(" valido");
        return true;
    }
}

function validaEmail() {
    var emailClass = $(".form-email");
    var emailText = $(".form-email").val();


    if (emailText == "") {
        emailClass.removeClass(" valido");
        emailClass.addClass(" invalido");
        return false;
    }
    else {
        emailClass.removeClass(" invalido");
        emailClass.addClass(" valido");

        return true;
    }
}

function validaValor() {
    var valorClass = $(".form-valor");
    var valorText = $(".form-valor").val();


    if (valorText == "") {
        valorClass.removeClass(" valido");
        valorClass.addClass(" invalido");
        return false;
    }
    else {
        valorClass.removeClass(" invalido");
        valorClass.addClass(" valido");

        return true;
    }
}

function validaQuantidade() {
    var quantidadeClass = $(".form-quantidade");
    var quantidadeText = $(".form-quantidade").val();


    if (quantidadeText == "") {
        quantidadeClass.removeClass(" valido");
        quantidadeClass.addClass(" invalido");
        return false;
    }
    else {
        quantidadeClass.removeClass(" invalido");
        quantidadeClass.addClass(" valido");

        return true;
    }
}