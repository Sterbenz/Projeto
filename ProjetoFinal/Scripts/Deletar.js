﻿function Deletar(id, controller) {

    if (confirm("Deseja remover!?")) {
        var url = controller + "/Remover";    
        $.ajax({
            url: url,
            data: { id: id},
            type: "post",
            dataType: "Json",
            success: function (resposta) {
                $("#" + resposta).remove();
            }                
        });
    }
}