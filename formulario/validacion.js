let formulario = document.getElementById("validacionjs");

window.onload = inciar;

function inciar() {
  document.getElementById("enviar").addEventListener("click", validar, false);
}

function validarNombre() {
  let elemento = document.getElementById("nombre");
  if (elemento.value == "") {
    alert("El nombre no puede quedar vacío");
    error(elemento);
    return false;
  } else {
    success(elemento);
    return true;
  }
}
function validarCorreo() {
  let elemento = document.getElementById("email");
  if (elemento.value == "") {
    alert("El email no puede quedar vacío");
    error(elemento);
    return false;
  } else {
    success(elemento);
    return true;
  }
}
function validar(e) {
  if (validarNombre() && validarCorreo()) {
    return true;
  } else {
    e.preventDefault();
    return false;
  }
}
function error(elemento) {
  elemento.className = "error";
  elemento.focus();
}

function success(elemento) {
  elemento.className = "success";
  elemento.focus();
}

const fechaNacim = document.getElementById("fechaNac");
const edad = document.getElementById("edad");

const calcularEdad = (fechaNacim) => {
  const fechaActual = new Date();
  const anoActual = parseInt(fechaActual.getFullYear());
  const mesActual = parseInt(fechaActual.getMonth());
  const diaActual = parseInt(fechaActual.getDate());

  const anoNacimiento = parseInt(String(fechaNacim).substring(0, 4));
  const mesNacimiento = parseInt(String(fechaNacim).substring(5, 7));
  const diaNacimiento = parseInt(String(fechaNacim).substring(8, 10));

  let edad = anoActual - anoNacimiento;
  if (mesActual < mesNacimiento) {
    edad--;
  } else if (mesActual == mesNacimiento) {
    if (diaActual < diaNacimiento) {
      edad--;
    }
  }
  return edad;
};

window.addEventListener("load", function () {
  fechaNacim.addEventListener("change", function () {
    if (this.value) {
      edad.innerText = calcularEdad(this.value) + " años";
    }
  });
});

const reset = document.getElementById("reset");

reset.addEventListener("click", function () {
  const resetEdad = document.getElementById("edad");
  resetEdad.innerText = "";
});
