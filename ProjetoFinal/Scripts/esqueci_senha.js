
$("#esqueci-senha").click(function () {
    $("#modal-login").show();
})

$("#fechar-modal-esquecisenha").click(function () {
    $("#modal-login").hide();
})

$("#btn-confirma-esquecisenha").click(function () {
    $("#loading").toggle();
    $("#span-email-nao-encontrado").addClass("invisible");
    $("#span-email-enviado").addClass("invisible");
    $("#loading").addClass("filtro-ativo");
    var email = $("#email").val();
    $.ajax({
        url: "/Login/Verifica_Email",
        data: { email: email },
        type: "post",
        dataType: "Json",
        
        success: function (resposta) {
            if (resposta == 0)
            {
                $("#loading").toggle();
                $("#span-email-nao-encontrado").removeClass("invisible");
            }
            else
            {
                $("#loading").removeClass("filtro-ativo");
                $("#span-email-enviado").removeClass("invisible");
            }
                realizaEnvioEmail(email);
            
            
        }
    });
});

function realizaEnvioEmail(email) {
    $.ajax({
        url: "/Login/Esqueci_Senha",
        data: { emailDestinatario: email },
        type: "post",
        dataType: "Json",
        success: function (resposta) {
            $("#span-email-enviado").show();
            setTimeout(function () {
                $("#span-email-enviado").hide();
                $("#modal-login").modal('hide');

            }, 1500);
        }
    });
}

