const ISDEVELOPMENTTEST = true;

function GetCurrentApiUrl() {
    if (ISDEVELOPMENTTEST)
        return "https://localhost:7292/v1/controller/";

    return "http://laborum-001-site1.btempurl.com/v1/controller/";
}

window.onload = function () {
  loadTheme();
  clickDarkBtn();
  clickLogar();
}

function clickLogar(){
  const btnLogar = document.getElementById('botaoLogar')
  btnLogar.addEventListener('click', validarTodosOsCampos);
}

function validarTodosOsCampos(){
  const emailInput = document.getElementById('inputEmail').value
  const senhaInput = document.getElementById('inputSenha').value

  if (!validarEmail()) {
    alert("Email inválido, deve conter um @ e .com.");
    emailInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
    return;
  }

   /* if (!validarSenha()) {
    alert("Senha inválida, deve conter no mínimo um caractere especial ex. !@#$%¨&*_+=");
    senhaInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
    return;
   } */

   if (!validaQtdSenha()) {
        alert("Senha inválida, deve conter no mínimo 8 algarismos.");
        senhaInput.setAttribute("style", "box-shadow: 0px 0px 3px crimson; border-color: crimson");
        return;
   }

    var data = { Email: emailInput, Senha: senhaInput };
    var apiUrl = GetCurrentApiUrl() + "login/transportadora";

    var requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    }

    fetch(apiUrl, requestOptions)
    .then(
        response => response.json()
    ).then(
        function (response) {
            alert(response.message);
            console.log(response);

            if (response.isSuccess) {
                window.location.href = "index.html";
            }
        }
    )
        
}



//Validações
function validarEmail(){
  const emailInput = document.getElementById("inputEmail")
  let email = emailInput.value;
  if (email.search('@') != -1 && email.search('.com') != -1) {
    return true;
  }
  return false;
}

//&& senha.search('.com') != -1


//Teste pelo menos um caractere especial
function validarSenha(){
  const senhaInput = document.getElementById("inputSenha")
  const caracteresEspeciais = /([!,@,#,$,%,¨,&,*,_,+,=,`,^,?,:,>])/

  let senha = senhaInput.value;
  if 
  (senha.val().match(caracteresEspeciais)){
  return true;
  }
  return false;
}

const minimoAlgarismosSenha = 8
function validaQtdSenha(){
  const senhaInput = document.getElementById("inputSenha")
  return senhaInput.value.length >= minimoAlgarismosSenha;
}