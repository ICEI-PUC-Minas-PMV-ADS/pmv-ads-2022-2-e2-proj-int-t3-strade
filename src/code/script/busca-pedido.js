window.onload = function () {
    clickDarkBtn();
}

const btnBuscar = document.getElementById("btnBuscar");
const idPedido = document.querySelector("#idPedido");
const notesContainer = document.querySelector("#notes_container")

btnBuscar.addEventListener("click", getStatusPedido);

function getStatusPedido(){
    var idPedidoValue = idPedido.value
    console.log(idPedidoValue)
    const apiUrl = GetCurrentApiUrl();
    fetch(apiUrl + "pedido/" + idPedidoValue)
    .then(function(data) {
        if (data.status != 200){
            retornoNaoEncontrado();
        } else {
            return data.json().then(function(json) {
                retornoMensagem(json.status)
            });
        }
    } )
    
}

function retornoMensagem(status){
    if (status == 0){
        const noteElement = 
        `<div class="note">
            <h3>A encomenda já foi separada, aguardando ser enviada</h3>
        </div>`;
    
        notesContainer.innerHTML = noteElement;
    }else if (status == 1){
        const noteElement = 
        `<div class="note">
            <h3>O pedido foi enviado pela transportadora</h3>
        </div>`;
    
        notesContainer.innerHTML = noteElement;
    }else if (status == 2){
        const noteElement = 
        `<div class="note">
            <h3>O pedido está a caminho de sua residência. Logo estará em suas mãos</h3>
        </div>`;
    
        notesContainer.innerHTML = noteElement;
    }else if (status == 3){
        const noteElement = 
        `<div class="note">
            <h3>Pedido entregue</h3>
        </div>`;
    
        notesContainer.innerHTML = noteElement;
    }else if (status == 4){
        const noteElement = 
        `<div class="note">
            <h3>Pedido cancelado. Contate a loja ou a transportadora para mais informações</h3>
        </div>`;
    
        notesContainer.innerHTML = noteElement;
    } else {
        const noteElement = 
        `<div class="note">
            <h3>Status do pedido inválido. Contate o administrador do Strade.</h3>
        </div>`;
    
        notesContainer.innerHTML = noteElement;
    }
  }

  function retornoNaoEncontrado(){
    const noteElement = 
        `<div class="note">
            <h3>Pedido não encontrado.</h3>
        </div>`;
    
        notesContainer.innerHTML = noteElement;
  }