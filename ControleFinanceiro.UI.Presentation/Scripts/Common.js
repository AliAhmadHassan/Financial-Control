$(document).ready(function () {
    var tamanhoH = $(window).height();
    if (tamanhoH < $("#menuDireito").height())
        tamanhoH = $("#menuDireito").height();

    $("#menuEsquerdo").height(tamanhoH);

});


/*$(document).ready(function () {
    $("#menuEsquerdo").height($("#menuDireito").height());
});*/