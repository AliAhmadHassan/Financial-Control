function numeros() {
    tecla = event.keyCode;
    if (tecla >= 48 && tecla <= 57) {
        return true;
    }
    else {
        return false;
    }
}