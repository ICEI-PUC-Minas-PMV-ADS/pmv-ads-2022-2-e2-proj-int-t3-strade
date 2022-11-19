if(localStorage.getItem("token") == null){
	alert("Para acessar esta página, você precisa entrar em uma conta.")
	window.location.href = "./login-transp.html"
}