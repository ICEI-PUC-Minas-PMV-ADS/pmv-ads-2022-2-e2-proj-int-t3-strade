window.onload = function () {
  configurarMascaraCnpj();
  configurarMascaraCep();
  configurarMascaraTel();

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