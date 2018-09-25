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

$(".form-validacao-fornecedores").submit(function () {

    if (!validaCamposProduto()) {
        console.log("fase 1");
        return false;
    }
    else {
        console.log("fase 2");
        return true;
    }
});

$(".form-validacao-familia").submit(function () {

    if (!validaCamposCategoria()) {
        console.log("fase 1");
        return false;
    }
    else {
        console.log("fase 2");
        return true;
    }
});






/////////////////////////////////////////////////////////////////////////////////////////////////

function pegaCampos() {   
    campoNome = validaNome();
    campoCpf = validaCpf(cpfValido);
    campoDataNascimento = validaDataNascimento();
    campoEmail = validaEmail();
    campoValor = validaValor();
    campoQuantidade = validaQuantidade();
    campoEndereco = validaEndereco();
    campoBairro = validaBairro();
    campoCidade = validaCidade();    
    campoUf = validaUf();
    campoCep = validaCep();
    campoDataEntrega = validaDataEntrega();
    campoUsuarioMudar = validaUsuarioMudar();
    campoSenhaMudar = validaSenhaMudar();
    campoConfirmaSenhaMudar = validaConfirmaSenhaMudar();

}

/////////////////////////////////////////////////////////////////////////////////////////////////


function validaCampos() {
    pegaCampos();
    if (campoNome == false || campoCpf == false || campoDataNascimento == false || campoEmail == false || cpfValido == false) {
        return false;
    } else {
        return true;
    }
}

function validaCamposProduto() {
    pegaCampos();
    if (campoNome == false || campoValor == false || campoQuantidade == false) {
        return false;
    } else {
        return true;
    }
}

function validaCamposCategoria() {
    pegaCampos();
    if (campoNome == true) {
        return true;
    } else {
        return false;
    }
}

function validaCamposFornecedor() {
    pegaCampos();
    if (campoNome == true) {
        return true;
    } else {
        return false;
    }
}

function validaCamposMudarUsuario(id) {
    pegaCampos();
    if (campoUsuarioMudar == true && campoSenhaMudar == true && campoConfirmaSenhaMudar == true) {
        verificaMudancaUsuario(id);
    }    
}
/////////////////////////////////////////////////////////////////////////////////////////////////

function validaNome() {
    var nomeClass = $(".form-nome");
    var nomeText = $(".form-nome").val();

    if (nomeText == "") {
        nomeClass.removeClass(" valido");
        nomeClass.addClass(" invalido");
        console.log(0);
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
    cpfValido = VerificaCPFValido();
    if (cpfText == "" || cpfValido == false) {
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

function validaEndereco() {
    var enderecoClass = $(".form-endereco");
    var enderecoText = $(".form-endereco").val();

    if (enderecoText == "") {
        enderecoClass.removeClass(" valido");
        enderecoClass.addClass(" invalido");
        return false;
    }
    else {
        enderecoClass.removeClass(" invalido");
        enderecoClass.addClass(" valido");
        return true;
    }
}

function validaBairro() {
    var bairroClass = $(".form-bairro");
    var bairroText = $(".form-bairro").val();

    if (bairroText == "") {
        bairroClass.removeClass(" valido");
        bairroClass.addClass(" invalido");
        return false;
    }
    else {
        bairroClass.removeClass(" invalido");
        bairroClass.addClass(" valido");
        return true;
    }
}

function validaUf() {
    var ufClass = $(".form-uf");
    var ufText = $(".form-uf").val();
        
    if (ufText == "") {
        uf.removeClass(" valido");
        uf.addClass(" invalido");
        return false;
    }
    else {
        ufClass.removeClass(" invalido");
        ufClass.addClass(" valido");
        return true;
    }
}

function validaCidade() {
    var cidadeClass = $(".form-cidade");
    var cidadeText = $(".form-cidade").val();

    if (cidadeText == "") {
        cidadeClass.removeClass(" valido");
        cidadeClass.addClass(" invalido");
        return false;
    }
    else {
        cidadeClass.removeClass(" invalido");
        cidadeClass.addClass(" valido");
        return true;
    }
}

function validaCep() {
    var cepClass = $(".form-cep");
    var cepText = $(".form-cep").val();

    if (cepText == "") {
        cepClass.removeClass(" valido");
        cepClass.addClass(" invalido");
        return false;
    }
    else {
        cepClass.removeClass(" invalido");
        cepClass.addClass(" valido");
        return true;
    }
}

function validaDataEntrega() {
    var dataEntregaClass = $(".form-data-entrega");
    var dataEntregaText = $(".form-data-entrega").val();

    if (dataEntregaText == "") {
        dataEntregaClass.removeClass(" valido");
        dataEntregaClass.addClass(" invalido");
        return false;
    }
    else {
        dataEntregaClass.removeClass(" invalido");
        dataEntregaClass.addClass(" valido");
        return true;
    }
}

function validaConfirmaSenhaMudar() {
    var confirmaSenhaClass = $("#newConfirmaSenha");
    var confirmaSenhaText = $("#newConfirmaSenha").val();

    if (confirmaSenhaText == "") {
        confirmaSenhaClass.removeClass(" valido");
        confirmaSenhaClass.addClass(" invalido");
        return false;
    }
    else {
        confirmaSenhaClass.removeClass(" invalido");
        confirmaSenhaClass.addClass(" valido");
        return true;
    }
}

function validaSenhaMudar() {
    var senhaClass = $("#newSenha");
    var senhaText = $("#newSenha").val();

    if (senhaText == "") {
        senhaClass.removeClass(" valido");
        senhaClass.addClass(" invalido");
        return false;
    }
    else {
        senhaClass.removeClass(" invalido");
        senhaClass.addClass(" valido");
        return true;
    }
}

function validaUsuarioMudar() {
    var usuarioClass = $("#newUsuario");
    var usuarioText = $("#newUsuario").val();

    if (usuarioText == "") {
        usuarioClass.removeClass(" valido");
        usuarioClass.addClass(" invalido");
        return false;
    }
    else {
        usuarioClass.removeClass(" invalido");
        usuarioClass.addClass(" valido");
        return true;
    }
}