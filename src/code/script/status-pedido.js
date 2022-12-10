window.onload = function () {
    iniciaAlterarStatusDesativado();
    clickDarkBtn(); 
}

if(localStorage.getItem("token") == null){
    alert("Para acessar esta página, você precisa entrar em uma conta.")
    window.location.href = "./login-transp.html"
    document.getElementById("abaCadastrar").click();
}

const btnBuscar = document.getElementById("btnBuscar");
const idPedido = document.querySelector("#idPedido");
const notesContainer = document.querySelector("#notes_container")
const btnOutroPedido = document.querySelector("#btnOutroPedido")

btnOutroPedido.addEventListener("click", alteraHabilitacaoDosCampos)
btnBuscar.addEventListener("click", getStatusPedido);

function alteraHabilitacaoDosCampos(){
    var campos = document.querySelectorAll('#idPedido, #btnBuscar, #selectStatus, #btnAlterar, #btnOutroPedido');
    for (var i = 0; i < campos.length; i++) {
        campos[i].disabled = !campos[i].disabled;
    }
}

function iniciaAlterarStatusDesativado(){
    var status = document.querySelectorAll('#selectStatus, #btnAlterar, #btnOutroPedido');
    for (var i = 0; i < status.length; i++) {
        status[i].disabled = !status[i].disabled;
      }
}

function getStatusPedido(){
    var idPedidoValue = idPedido.value
    const apiUrl = GetCurrentApiUrl();
    fetch(apiUrl + "pedido/" + idPedidoValue)
    .then(function(data) {
        if (data.status != 200){
            retornoNaoEncontrado();
        } else {
            return data.json().then(function(json) {
                retornoMensagem(json.status)
                alteraHabilitacaoDosCampos()
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
            <h3>Status do pedido inválido.</h3>
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


const btnAlterar = document.querySelector("#btnAlterar");

btnAlterar.addEventListener("click", putStatusPedido);

function putStatusPedido(){
    var idPedidoValue = idPedido.value
    const apiUrl = GetCurrentApiUrl();

    const select = document.querySelector("#selectStatus");
    var value = select.options[select.selectedIndex].value;

    if (value == 5){
        const noteElement = 
            `<div class="note">
                <h3>Selecione um valor.</h3>
            </div>`;

            notesContainer.innerHTML = noteElement;
    } else {
        var body = {
            "status": value,
            "idPedido": idPedidoValue
        }

        fetch(apiUrl + 'pedido/status', {
            method: 'PUT',
            body: JSON.stringify(body),
            headers: {
            "content-type": "application/json"
            }
        })
        .then(function(response){
            if (response){
                retornoMensagem(value)
            } else {
                const noteElement = 
                `<div class="note">
                    <h3>Erro ao atualizar status.</h3>
                </div>`;

                notesContainer.innerHTML = noteElement;
            }
        })
    }
}