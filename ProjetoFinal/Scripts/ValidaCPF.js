﻿
function validaCPF() {
    var cpf = document.getElementById("cpf").value;
    var result = 0;
    var result2 = 0;
    var R = 0;
    var R2 = 0;
    var N = 10;
    var N2 = 11;
    for (var i = 0; i < cpf.length - 2; i++) {
        result += (cpf.charAt(i) * N);
        N -= 1;
    }
    R = (result * 10) % 11;

    if (cpf.length != 11 ||
        cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999") {
        document.getElementById("cpf").className = "form-control invalido";
    }
    else {


        if (R == 10) {
            R = 0;
            if (R == cpf.charAt(9)) {
                document.getElementById("cpf").className = "form-control valido";
            } else {
                document.getElementById("cpf").className = "form-control invalido";
            }
        } else {
            if (R == cpf.charAt(9)) {
                for (var i = 0; i < cpf.length - 1; i++) {
                    result2 += (cpf.charAt(i) * N2);
                    N2 -= 1;
                }
                R2 = (result2 * 10) % 11;
                if (R2 == 10) {
                    R2 = 0;
                    if (R2 == cpf.charAt(10)) {
                        document.getElementById("cpf").className = "form-control valido";
                    } else {
                        document.getElementById("cpf").className = "form-control invalido";
                    }
                }
                else {
                    if (R2 == cpf.charAt(10)) {
                        document.getElementById("cpf").className = "form-control valido";
                    } else {
                        document.getElementById("cpf").className = "form-control invalido";
                    }

                }
            }
            else {
                document.getElementById("cpf").className = "form-control invalido";
            }
        }
    }
}