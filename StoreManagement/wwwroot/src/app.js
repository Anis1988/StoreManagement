import Error404Screen from "./screens/Error404Screen.js";
import HomeScreen from "./screens/HomeScreen.js";
import ProductScreen from "./screens/ProductScreen.js";
import { parseRequestUrl } from "./utils.js";

var routes = {
  "/": HomeScreen,
  "/product/:id": ProductScreen,
};
var router = () => {
  var request = parseRequestUrl();
  var parseUrl =
    (request.resource ? `/${request.resource}` : "/") +
    (request.id ? "/:id" : "") +
    (request.verb ? `/${request.verb}` : "");

  var screen = routes[parseUrl] ? routes[parseUrl] : Error404Screen;

  var main = document.getElementById("main-container");
  main.innerHTML = screen.render();
};
window.addEventListener("load", router);
window.addEventListener("hashchange", router);
