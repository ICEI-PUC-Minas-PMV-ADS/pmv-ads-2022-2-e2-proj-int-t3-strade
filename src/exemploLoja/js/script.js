window.onload = function () {
  loadTheme();
  localStorage.clear();
  console.log("Carreguei!")
}

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

function getRegiao(){
  // criando variaveis de selecao
  var norte = document.getElementById("norte").checked
  var sul = document.getElementById("sul").checked
  var leste = document.getElementById("leste").checked
  var oeste = document.getElementById("oeste").checked

  let regiao = 0

  if (norte) {
    regiao += 1
  } else if (sul) {
    regiao += 2
  } else if (leste) {
    regiao += 3
  } else if (oeste) {
    regiao += 4
  }

  return regiao
}

// botão buscar
const form = document.getElementById("form");

function carregarLista() {
  var regiao = getRegiao()

  modal.showModal();
  fetch('http://laborum-001-site1.btempurl.com/v1/controller/transportadora/regiao/' + regiao)
    .then(function(response) {
      var contentType = response.headers.get("content-type");
      if(contentType && contentType.indexOf("application/json") !== -1) {
        return response.json().then(function(json) {
          displayTransportadoras(json);
        });
      } 
    }); 
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
//const getBtn = document.querySelector("#getTransportadora");
const modal = document.querySelector("#dialog-selecionar");
const closeModal = document.querySelector("#fechar-selecionar");
const notesContainer = document.querySelector("#notes_container");

function displayTransportadoras(notes){
  let allNotes = '';

  notes.forEach(note => {
    const noteElement = 
    `<ul class="note">
      <li class="list-group-item">
      <input type="radio" name="transp" id="${note.idTransportadora}">
        <h3>Transportadora: ${note.nome}</h3>
        <p>Preço: ${note.mediaPreco}</p>
        <p>Nota: ${note.notaMediaQualidade}</p>
      </li>
    </ul>`;

    allNotes += noteElement;
  })

  //console.log(allNotes);
  notesContainer.innerHTML = allNotes;
}

/* function fechaPopup(){
  const popupSelecionar = document.getElementById('dialog-selecionar')
  popupSelecionar.setAttribute('style', 'display: none');
} */

/* function fechaPopup() {
  modal.close();
} */

closeModal.onclick = function(){
  modal.close();
}

//Mostra ID Pedido
const modalId = document.querySelector("#dialog-comprar");
const notesContainerId = document.querySelector("#notes_container_id");

function displayIdPedido(response){

  const noteElement = 
    `<div class="note">
      <h3>: O número do seu pedido é: ${response}</h3>
    </div>`;

    notesContainerId.innerHTML = noteElement;

}

function popupIdPedido(){
  
  addPedido(detalhesPedido,idCliente);

}

const btnSelecionar = document.getElementById('selecionar')
btnSelecionar.addEventListener("click", SelecionaTransp);

function SelecionaTransp(){
  console.log("ta na hora!")
  var lista = document.getElementsByName("transp")
  var nTransp = lista.length

  for (var i = 0; i < nTransp; i++) {
    var node = lista[i].checked
    if (node === true) {
      localStorage.removeItem("idTransportadora")
      localStorage.setItem("idTransportadora", lista[i].id)
      modal.close();
    }
  }
}

async function addPedido(detalhes,idCliente){
  
  idTransportadora = parseInt(localStorage.getItem("idTransportadora"));
  
  var body = {
    "detalhes": detalhes,
    "idTransportadora": idTransportadora,
    "idCliente": idCliente,
    "status": 0
  }

  var apiUrl = 'http://laborum-001-site1.btempurl.com/v1/controller/';
  
  const res = await fetch(apiUrl + 'pedido', {
    method: 'POST',
    body: JSON.stringify(body),
    headers: {
      "content-type": "application/json"
    }
  });

  const data = await res.json();

  modalId.showModal();
  displayIdPedido(data);
}

/* (async () => {
  const res = await fetch(`https://api.github.com/users/jameshibbard`);
  const json = await res.json();
  console.log(json.public_repos);
  console.log("Hello!");
})(); */

const detalhesPedido = "Pedido de um par de tênis da marca Nike valor de R$ 299,99."
const idCliente = 2 // Sr Barriga

const btnComprar = document.getElementById('comprar')
btnComprar.addEventListener("click", popupIdPedido);

const fechaPopupComprar = document.getElementById('fechar-selecionar')
fechaPopupComprar.addEventListener("click", fecha);

function fecha(){
  console.log("ta na hora!")
  var lista = document.getElementsByName("transp")
  var nTransp = lista.length

  for (var i = 0; i < nTransp; i++) {
    var node = lista[i].checked
    if (node === true) {
      localStorage.removeItem("idTransportadora")
      localStorage.setItem("idTransportadora", lista[i].id)
    }
  }
}


const closeModalId = document.querySelector("#fechar-id");

closeModalId.onclick = function(){
  modalId.close();
}

