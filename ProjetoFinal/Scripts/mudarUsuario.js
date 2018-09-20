function configurarUsuario(id) {

    var usuario = $("#newUsuario").val();
    var senha = $("#newSenha").val();
    console.log(true);
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
            console.log(true);
            $(".operacao-concluida").show();
            setTimeout(function () {

                $("#modalConfigUsuario").modal('hide');
            }, 1500);
        },
        fail: function () {
            alert("ERRO");
        }
    });
    
}

