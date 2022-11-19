var idPedido = document.querySelector("#id-pedido")


var nomeCliente = document.querySelector("#nome-cliente")
const btnBuscar = document.getElementById("button-addon2")
const mensagem = document.getElementById("mensagem")

const ISDEVELOPMENTTEST = true;

function GetCurrentApiUrl() {
    if (ISDEVELOPMENTTEST)
        return "https://localhost:7292/v1/controller/";

    return "http://laborum-001-site1.btempurl.com/v1/controller/";
}

btnBuscar.addEventListener("click", (e) => {
    buscaNomeCliente();
})

function buscaNomeCliente(){
    var apiUrl = GetCurrentApiUrl();
    var idPedidoValue = idPedido.value
    fetch(apiUrl + "pedido/" + idPedidoValue + "/cliente").then(resp => resp.text())
        .then(function(data) {
            nomeCliente.value = data;
            mensagem.value = "Prezado(a) " + nomeCliente.value + ", ";
        });
}