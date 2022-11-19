const idPedido = document.querySelector("#id-pedido")
const nomeCliente = document.querySelector("#nome-cliente")
const btnBuscar = document.getElementById("button-addon2")
const mensagem = document.getElementById("mensagem")

btnBuscar.addEventListener("click", (e) => {
    /*fetch("https://localhost:7292/v1/controller/pedido/" + idPedido)
        .then(response => response.json())
        .then(function(data) {
            nomeCliente.value = data.nomeCliente;
        });*/
        nomeCliente.value = idPedido.value; 
        mensagem.value = "Prezado(a) " + nomeCliente.value + ", ";
})