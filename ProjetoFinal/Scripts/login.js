$("#btn-login").click(function () {
    var usuario = $("#user-login").val();
    var senha = $("#pass-login").val();
    $("#span-user-errado").addClass("invisible");
    $("#span-senha-errada").addClass("invisible");

    $.ajax({
        url: "/Login/UsuarioExiste",
        data: { usuario: usuario,senha: senha },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            if (resposta == 0) {
                $("#span-user-errado").removeClass("invisible");
            }
            else if (resposta == 1) {
                $("#span-senha-errada").removeClass("invisible");
            }
            else if (resposta == 2) {
                autenticaLogin();
            }
        }
    });
})

function autenticaLogin() {
    $("#login-form").submit();
}