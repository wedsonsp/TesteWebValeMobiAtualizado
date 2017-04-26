/* Arquivo Java Script 
Autor: Wedson Pereira de Souza*/

function validacao() {
    if (document.getElementById("txtMercadoria").value == "") {
        //alert("Informe o nome.");
        document.getElementById("txtMercadoria").focus();
        return false;
    }

    if (document.getElementById("txtNome").value == "") {
       // alert("Informe o nome.");
        document.getElementById("txtNome").focus();
        return false;
    }

    if (document.getElementById("txtQuantidade").value == "") {
        //alert("Informe o nome.");
        document.getElementById("txtQuantidade").focus();
        return false;
    }

    if (document.getElementById("txtPreco").value == "") {
        //alert("Informe o nome.");
        document.getElementById("txtPreco").focus();
        return false;
    }

    if (document.getElementById("txtTipoNegocio").value == "") {
        //alert("Informe o nome.");
        document.getElementById("txtTipoNegocio").focus();
        return false;
    }
}



