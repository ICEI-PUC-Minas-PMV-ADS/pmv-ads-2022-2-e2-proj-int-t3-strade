const getBtn = document.querySelector("#clickToGet");

function getTransportadora(){
    fetch('https://localhost:7292/v1/controller/transportadora')
    .then(data => data.json())
    .then(response => console.log(response))
}

getBtn.addEventListener('click', function() {
    getTransportadora();
})


const abrirModal = document.querySelector("#modal");
const modal = document.querySelector("dialog");
const closeModal = document.querySelector("dialog button")

abrirModal.onclick = function(){
    modal.showModal();
}

closeModal.onclick = function(){
    modal.close();
}