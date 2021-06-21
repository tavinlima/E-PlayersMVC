// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
var menu = document.getElementById("links");
function BotaoDoMenu() {
    if (screen.width <= 768) {
        if (menu.style.display === "flex") {
            //Esconder o menu
            menu.style.display = "none";
        } else {
            //Mostrar o menu
            menu.style.display = "flex";
        }
    }
}

function SairMenu() {
    if (screen.width <= 768) {
        if (menu.style.display === "flex") {
            //Esconder o menu
            menu.style.display = "none";
        }
    }
}
window.onresize = () => {
    if (screen.width > 768) {
        menu.style.display = "flex";
    } else {
        menu.style.display = "none";
    }
}
// Write your JavaScript code.
