function verificaMudancaUsuario(id) {
    $(".senha-incorreta").hide();
    var senha = $("#newSenha").val();
    var confirmaSenha = $("#newConfirmaSenha").val();

    if (senha == confirmaSenha)
        configurarUsuario(id);
    else {
        $(".senha-incorreta").toggle();
        $("#newConfirmaSenha").addClass("invalido");
    }        
}

function configurarUsuario(id) {

    var usuario = $("#newUsuario").val();
    var senha = $("#newSenha").val();
    $.ajax({

        url: "/Funcionario/ConfiguracaoUsuario",
        data: {
            id: id,
            usuario: usuario,
            senha: senha
        },
        type: "post",
        dataType: "Json",
        success: function () {
            $(".operacao-concluida").show();
            setTimeout(function () {
                $(".operacao-concluida").hide();
                $("#modalConfigUsuario").modal('hide');
                
            }, 1500);
        },
        fail: function () {
            alert("ERRO");
        }
    });
    
}

