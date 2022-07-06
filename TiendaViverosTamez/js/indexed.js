var cajadatos, cajadatosBuscar, bd;

// **************** Guardar **************** 

function iniciar() {
    cajadatos = document.getElementById("cajadatos");
    var boton = document.getElementById("grabar");
    boton.addEventListener("click", agregarobjeto);
    var solicitud = indexedDB.open("basededatos");
    solicitud.addEventListener("error", mostrarerror);
    solicitud.addEventListener("success", comenzar);
    solicitud.addEventListener("upgradeneeded", crearbd);
}

function mostrarerror(evento) {
    alert("Error: " + evento.code + " " + evento.message);
}

function comenzar(evento) {
    bd = evento.target.result;
    mostrar();
}

function crearbd(evento) {
    var basededatos = evento.target.result;
    var almacen = basededatos.createObjectStore("peliculas", { keyPath: "id" });
    almacen.createIndex("BuscarFecha", "fecha", { unique: false });
}

function agregarobjeto() {
    var clave = document.getElementById("clave").value;
    var titulo = document.getElementById("titulo").value;
    var fecha = document.getElementById("fecha").value;
    var transaccion = bd.transaction(["peliculas"], "readwrite");
    var almacen = transaccion.objectStore("peliculas");
    transaccion.addEventListener("complete", mostrar);
    var solicitud = almacen.add({ id: clave, nombre: titulo, fecha: fecha });
    document.getElementById("clave").value = "";
    document.getElementById("titulo").value = "";
    document.getElementById("fecha").value = "";
}

function mostrar() {
    cajadatos.innerHTML = "";
    var transaccion = bd.transaction(["peliculas"]);
    var almacen = transaccion.objectStore("peliculas");
    var indice = almacen.index("BuscarFecha");
    var puntero = indice.openCursor(null, "prev");
    puntero.addEventListener("success", mostrarlista);
}

function mostrarlista(evento) {
    var puntero = evento.target.result;
    if (puntero) {
        cajadatos.innerHTML += "<div>" + puntero.value.id + " - " + puntero.value.nombre + " - " + puntero.value.fecha + "</div>";
        cajadatos.innerHTML += puntero.value.fecha + ' <input type="button" onclick="removerobjeto(\'' + puntero.value.id + '\')" value="Remover"></div>';
        puntero.continue();
    }
}

function removerobjeto(clave) {
    if (confirm("¿Está seguro?")) {
        var transacion = bd.transaction(["peliculas"], "readwrite");
        var almacen = transacion.objectStore("peliculas");
        transacion.addEventListener("complete", mostrar);
        var solicitud = almacen.delete(clave);
    }
}

// **************** Buscar **************** 

function iniciarBuscar() {
    cajadatosBuscar = document.getElementById("cajadatos-buscar");
    var boton = document.getElementById("buscar");
    boton.addEventListener("click", buscarobjetos);
    var solicitud = indexedDB.open("basededatos");
    solicitud.addEventListener("error", mostrarerrorBuscar);
    solicitud.addEventListener("success", comenzarBuscar);
    solicitud.addEventListener("upgradeneeded", crearbdBuscar);
}

function mostrarerrorBuscar(evento) {
    alert("Error: " + evento.code + " " + evento.message);
}

function comenzarBuscar(evento) {
    bd = evento.target.result;
}

function crearbdBuscar(evento) {
    var basededatos = evento.target.result;
    var almacen = basededatos.createObjectStore("peliculas", { keyPath: "id" });
    almacen.createIndex("BuscarFecha", "fecha", { unique: false });
}

function buscarobjetos() {
    cajadatosBuscar.innerHTML = "";
    var buscar = document.getElementById("clave-buscar").value;
    var transaccion = bd.transaction(["peliculas"]);
    var almacen = transaccion.objectStore("peliculas");
    var indice = almacen.index("BuscarFecha");
    var rango = IDBKeyRange.only(buscar);
    var puntero = indice.openCursor(rango);
    puntero.addEventListener("success", mostrarlistaBuscar);
}

function mostrarlistaBuscar(evento) {
    var puntero = evento.target.result;
    if (puntero) {
        cajadatosBuscar.innerHTML += "<div>" + puntero.value.id + " - " + puntero.value.nombre + " - " + puntero.value.fecha + "</div>";
        puntero.continue();
    }
}

window.addEventListener("load", iniciar);
window.addEventListener("load", iniciarBuscar);