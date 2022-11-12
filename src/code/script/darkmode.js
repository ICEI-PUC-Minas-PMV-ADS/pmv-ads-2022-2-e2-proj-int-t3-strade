/* DARK MODE */
loadTheme();

// Toggle dark mode
function toggleDarkMode() {
    document.body.classList.toggle("dark");
}

// Load light or dark mode
function loadTheme() {
    const darkMode = localStorage.getItem("dark")

    if(darkMode) {
        toggleDarkMode();
    }
}

function clickDarkBtn() {
  const changeThemeBtn = document.querySelector("#change-theme");

  changeThemeBtn.addEventListener("change", function () {
    toggleDarkMode();

    // Save or remove dark mode
    localStorage.removeItem("dark");

    if(document.body.classList.contains("dark")) {
        localStorage.setItem("dark", 1);
    }
});
}

function validarCheckbox(){
  var checkboxes = document.getElementsByName('checkboxEncomendas')
  console.log(checkboxes)
  
  for (let i=0; i<checkboxes.length; i++){
    if (checkboxes[i].checked)
      return true;
  }
  return false;
}