let dddDatabaseJson;
  
window.onload = function () {
  console.log("Chamou a função window.onload");
  dddDatabaseJson =  getDddFromDatabase();
  configurarMascaraCnpj();
  configurarMascaraCep();
  configurarMascaraTel();
  clickCadastrar();
  desativaInputs();
  //toggleDarkMode();
  loadTheme();
  clickDarkBtn();
}

function clickCadastrar(){  
  const Cadastrar = document.getElementById('botaoCadastrar')   
  Cadastrar.addEventListener('click', enviarMensagem); 
  console.log('clicou')
}

/* Envia MSG e Valida no botão cadastrar */
function enviarMensagem(){
  const nomeFantasiaInput = document.getElementById('inputNomeFantasia')
  const nomeTransportadoraInput = document.getElementById('inputNomeTransportadora')
  const cnjpInput = document.getElementById('inputCnpj')
  const emailInput = document.getElementById('inputEmail')
  const telInput = document.getElementById('inputTel')
  const cepInput = document.getElementById("inputCep")

  if (!validarNomeFantasia()) {
    //alert("Nome Fantasia inválido, mínimo 2 caracteres.");
    nomeFantasiaInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
    return;
  }
  nomeFantasiaInput.setAttribute("style", "box-shadow: 0px 0px 3px green; border-color: green");
  
  if (!validarNomeTransportadora()) {
    //alert("Nome da Transportadora inválido, mínimo 2 caracteres.");
    nomeTransportadoraInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
    return;
  }
  nomeTransportadoraInput.setAttribute("style", "box-shadow: 0px 0px 3px green; border-color: green");
  
  if (!validarCnpj()) {
    alert("CNPJ inválido, insira os dados corretos.");
    cnjpInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
    return;
   } 
   cnjpInput.setAttribute("style", "box-shadow: 0px 0px 3px green; border-color: green");
  
  if (!validarEmail()) {
   alert("Email inválido, deve conter um @ e .com.");
   emailInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
   return;
  } 
  inputEmail.setAttribute("style", "box-shadow: 0px 0px 3px green; border-color: green");
  
  if (!validarTel()) {
  alert("Telefone inválido, digite os dados corretamente.");
    telInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
    return;
   } 
    telInput.setAttribute("style", "box-shadow: 0px 0px 3px green; border-color: green");

  if (!validacaoTel()) {
    alert("Telefone inválido, digite os dados corretamente.");
      telInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
      return;
      } 
      telInput.setAttribute("style", "box-shadow: 0px 0px 3px green; border-color: green");
    
  if (!validacaoCep()) {
    alert("CEP inválido, digite os dados corretamente.");
      cepInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
      return;
      } 
      cepInput.setAttribute("style", "box-shadow: 0px 0px 3px green; border-color: green");
   
}

/* Número de caracteres no  */
const minimoAlgarismosNome = 2
const minimoAlgarismosCnpj = 18
const minimoAlgarismosTel = 15
const minimoAlgarismosCep = 9

/* Desativar inputs do form */
document.addEventListener('DOMContentLoaded', function () {
  document.getElementById('inputConcordo').onchange = desativaInputs;
}, false);

function desativaInputs() {
  var itensForm = document.querySelectorAll('#itensForm input, #botaoCadastrar');
  
  for (var i = 0; i < itensForm.length; i++) {
    itensForm[i].disabled = !itensForm[i].disabled;
  }
}

/* Validações */
function validarNomeFantasia(){
  let inputNomeFantasia = document.getElementById('inputNomeFantasia')
  return inputNomeFantasia.value.length >= minimoAlgarismosNome;
}

function validarNomeTransportadora(){
  let inputNomeTransportadora = document.getElementById('inputNomeTransportadora')
  return inputNomeTransportadora.value.length >= minimoAlgarismosNome;
}

function validarCnpj(){
  let inputCnpj = document.getElementById('inputCnpj')
  return inputCnpj.value.length >= minimoAlgarismosCnpj;
}
  
function validarEmail(){
  const emailInput = document.getElementById("inputEmail")
  let email = emailInput.value;
  if (email.search('@') != -1 && email.search('.com') != -1) {
    return true;
  }
  return false;
}

function validacaoTel(){
  const telInput = document.getElementById("inputTel")
  return telInput.value.length >= minimoAlgarismosTel;
}

function validarTel(){
  const telInput = document.getElementById("inputTel")
  const dddEstados = 
  [
  /* AC */  "(68)",
  /* AL */  "(82)",
  /* AM */  "(92)", "(97)",
  /* AP */  "(96)",
  /* BA */  "(71)", "(73)", "(74)", "(75)", "(77)",
  /* CE */  "(85)", "(88)",
  /* DF */  "(61)",
  /* ES */  "(27)", "(28)",
  /* GO */  "(62)", "(64)",
  /* MA */  "(98)", "(99)",
  /* MG */  "(31)", "(32)", "(33)", "(34)", "(35)", "(37)", "(38)",
  /* MS */  "(67)",
  /* MT */  "(65)", "(66)",
  /* PA */  "(91)", "(93)", "(94)",
  /* PB */  "(83)",
  /* PE */  "(81)", "(87)",
  /* PI */  "(86)", "(89)",
  /* PR */  "(41)", "(42)", "(43)", "(44)", "(45)", "(46)",
  /* RJ */  "(21)", "(22)", "(24)",
  /* RN */  "(84)",
  /* RO */  "(69)",
  /* RR */  "(95)",
  /* RS */  "(51)", "(53)", "(54)", "(55)",
  /* SC */  "(47)", "(48)", "(49)",
  /* SE */  "(79)",
  /* SP */  "(11)", "(12)", "(13)", "(14)", "(15)", "(16)", "(17)", "(18)", "(19)",
  /* TO */  "(63)"
  ]

  let telefone = telInput.value;
  if (telefone.search(dddEstados.value) != -1 && telefone.search(' 9') != -1 && telefone.search('-') != -1) {
    return true;
  }
  return false;
}

function validacaoCep(){
  const cepInput = document.getElementById("inputCep")
  return cepInput.value.length >= minimoAlgarismosCep;
}

/* DDD Json */
async function getDddFromDatabase() {
  console.log("Chamou a função getDDDFromDatabase");
  const response = await fetch("src/code/database/ddd.json");
  const dddDatabaseJson = await response.json();
  console.log(dddDatabaseJson)
  return dddDatabaseJson.estadoPorDdd;
}

/* Máscaras */
function configurarMascaraTel() {
  const tel= document.getElementById('inputTel')
  tel.addEventListener('keypress', () => {
    let inputlength = tel.value.length

    if (inputlength === 0 ){
      tel.value += '('
    } else if (inputlength === 3) {
      tel.value += ') '
    } else if (inputlength === 4) {
      tel.value += ' '
    } else if (inputlength === 10) 
      tel.value += '-'
  })
}

function configurarMascaraCnpj() {
  const cnpj = document.getElementById("inputCnpj")
  cnpj.addEventListener('keypress', () => {
    let inputlength = cnpj.value.length

    if (inputlength === 2 || inputlength === 6) {
      cnpj.value += '.'
    } else if (inputlength === 10) {
      cnpj.value += '/'
    } else if (inputlength === 15)
      cnpj.value += '-'
  })
}

function configurarMascaraCep() {
  const cep = document.getElementById("inputCep")
  cep.addEventListener('keypress', () => {
    let inputlength = cep.value.length

    if (inputlength === 5) {
      cep.value += '-'
    }
  })
}

/* Campos type='text' recebem somente números */
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

/* DARK MODE */
loadTheme();

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

function clickDarkBtn() {
  const changeThemeBtn = document.querySelector("#change-theme");

  changeThemeBtn.addEventListener("change", function () {
    toggleDarkMode();

    // Save or remove dark mode
    localStorage.removeItem("dark");

    if(document.body.classList.contains("dark")) {
        localStorage.setItem("dark", 1);
    }
});
}


