const getBtn = document.querySelector("#clickToGet");
var comboCidades = document.getElementById("cboCidades");

const norte = document.getElementById("norte")

window.onload = function(){
 console.log(norte)
}

function getTransportadora(){
    fetch('https://localhost:7292/v1/controller/transportadora/teste', {
    method: 'POST',
    headers: {
      "content-type": "application/json"
    }
  })
  .then(data => data.json())
  .then(response => console.log(response));
}

getBtn.addEventListener('click', function() {
    getTransportadora();
})


const abrirModal = document.querySelector("#modal");
const modal = document.querySelector("dialog");
const closeModal = document.querySelector("dialog button")

abrirModal.onclick = function(){
    modal.showModal();
    console.log(norte.checked)
}

closeModal.onclick = function(){
    modal.close();
}