window.onload = function () {
  configurarMascaraCnpj();
  configurarMascaraCep();
  configurarMascaraTel();
  clickBotao();

}

function configurarMascaraTel() {
  const tel= document.getElementById('tel')
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
  const cnpj = document.getElementById("cnpj")
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
  const cep = document.getElementById("cep")
  cep.addEventListener('keypress', () => {
    let inputlength = cep.value.length

    if (inputlength === 5) {
      cep.value += '-'
    }
  })
}

function clickBotao(){  
  const Cadastrar = document.getElementById('botaoCadastrar')   
  Cadastrar.addEventListener('click', enviarMensagem); 
}

function enviarMensagem(){
 if (!validarEmail()) {
   alert("Email inv\u00e1lido, deve conter um @ e .com.");
    const emailInput = document.getElementById("email") 
    emailInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
   return;
  }
}

function validarEmail(){
  const emailInput = document.getElementById("email") 
  let email = emailInput.value;
  if (email.search('@') != -1 && email.search('.com') != -1) {
    return true;
  }
  return false;
}












/* const cepzin = document.getElementById("cepzin")
cepzin.addEventListener('keypress', () => {
  let inputlength = cepzin.value.length

  if(inputlength === 5){
    cepzin.value += '-'
  }
}) */


/* document.getElementById('testezin').addEventListener('click', ()=> {
  
  console.log("You Clicked me");
  
}); */