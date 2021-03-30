
import HomeScreen from "./screens/HomeScreen.js";



const router = async () => {
    const main = document.getElementById("main-container");
    main.innerHTML = await HomeScreen.render();
    document.getElementById("name").innerHTML = localStorage.getItem("custId");

};

window.addEventListener("load", router);
