loadTheme();
validacaoCep();
configurarMascaraCep();


const changeThemeBtn = document.querySelector("#change-theme");

// Toggle dark mode
function toggleDarkMode() {
    document.body.classList.toggle("dark");
}

// Load light or dark mode
function loadTheme() {
    const darkMode = localStorage.getItem("dark")

    if(darkMode) {
        toggleDarkMode();
    }
}

changeThemeBtn.addEventListener("change", function () {
    toggleDarkMode();

    // Save or remove dark mode
    localStorage.removeItem("dark");

    if(document.body.classList.contains("dark")) {
        localStorage.setItem("dark", 1);
    }
});


// botão cep
const form = document.getElementById("form");
const cep = document.getElementById("cep");

form.addEventListener("submit", (e) => {
  e.preventDefault();

  checkInputs();
});

function checkInputs() {
  const cepValue = cep.value;

  if (cepValue === "") {
    setErrorFor(cep, "Número cep obrigatório.");
  } else {
    setSuccessFor(cep);
  }

  const formControls = form.querySelectorAll(".form-control");

  const formIsValid = [...formControls].every((formControl) => {
    return formControl.className === "form-control success";
  });

  if (formIsValid) {
    console.log("O formulário está 100% válido!");
  }
}

function setErrorFor(input, message) {
  const formControl = input.parentElement;
  const small = formControl.querySelector("small");

  // Adiciona a mensagem de erro
  small.innerText = message;

  // Adiciona a classe de erro
  formControl.className = "form-control error";
}

function setSuccessFor(input) {
  const formControl = input.parentElement;

  // Adicionar a classe de sucesso
  formControl.className = "form-control success";
}

// HTTP
const getBtn = document.querySelector("#getTransportadora");
const modal = document.querySelector("dialog");
const closeModal = document.querySelector("dialog button");
const notesContainer = document.querySelector("#notes_container");

var consoleStorage = [];

function getTransportadora(){
  const cepValue = cep.value;

  if (cepValue === "") {
    setErrorFor(cep, "Número cep obrigatório.");
  } else {
    modal.showModal();
    fetch('https://localhost:7292/v1/controller/transportadora/')
    .then(data => data.json())
    .then(response => displayNotes(response));
  }
}

function displayNotes(notes){
  let allNotes = '';

  notes.forEach(note => {
    const noteElement = 
    `<div class="note">
      <h3>Transportadora: ${note.nome}</h3>
      <p>Preço: ${note.mediaPreco}</p>
      <p>Nota: ${note.notaMediaQualidade}</p>
      </div>`;

    allNotes += noteElement;

  })

  notesContainer.innerHTML = allNotes;
}

closeModal.onclick = function(){
  modal.close();
}

getBtn.addEventListener('click', function() {
    getTransportadora();
})

//Envia MSG Validação
function enviarMensagem(){
  if (!validacaoCep()) {
    alert("CEP inválido, digite os dados corretamente.");
      return;
      }
}

//Valida CEP
function validacaoCep(){
  const minimoAlgarismosCep = 9
  const cepInput = document.getElementById("cep")
  return cepInput.value.length >= minimoAlgarismosCep;
}

//Máscara CEP
function configurarMascaraCep() {
  const cep = document.getElementById("cep")
  cep.addEventListener('keypress', () => {
    let inputlength = cep.value.length

    if (inputlength === 5) {
      cep.value += '-'
    }
  })
}

//Somente números no input type='text'
function somenteNumeros(e) {
  var charCode = e.charCode ? e.charCode : e.keyCode;
  // charCode 8 = backspace   
  // charCode 9 = tab
  if (charCode != 8 && charCode != 9) {
      // charCode 48 equivale a 0   
      // charCode 57 equivale a 9
      if (charCode < 48 || charCode > 57) {
          return false;
      }
  }
}