
function Deletar(id, controller) {

    if (confirm("Deseja remover!?")) {
        var url = controller + "/Remover";    
        $.ajax({
            url: url,
            data: { id: id},
            type: "post",
            dataType: "Json",
            success: function (resposta) {
                $fadeOut("slow", ("#" + resposta).remove());
            }                
        });
    }
}

function AtualizarPag(resposta) {    
    $("#" + resposta).remove();
}

function Teste(id, controller) {
    alert(id + " " + " ------ " + " " + controller);
}