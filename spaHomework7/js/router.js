// Добавим метод route()
// Это событие, поэтому у него в отличии от предыдущего есть
// параметры например будит передоваться объект event
// И мы сможем в рамках этого метода обработать событие, которое
// возникнит при нажатии на элемент ссылки
const route = (event) => {

    event = event || window.event; // небольшая хитрость если
                                   // страницу меняют в браузере
    event.preventDefault();
    window.history.pushState({}, "", event.target.href); // инструкция
                                                         // для сохранения
                                                         // предыдущего
                                                         // состояния
                                                         // страници
    handleLocation();
}

// Создадим небольшой импровизированный dictionary
// у которого есть определённый ключ и определённое значение

const routers = {
    404: "/pages/404.html",
    "/": "/pages/main.html",
    "/settings": "/pages/settings.html",
    "/about": "/pages/about.html"
}

// Далее разработаем некоторую асинхронную функцию.
// Основное назначение этой функции взять маршрут с которым
// сейчас работаем распарсим его и взять соответствие этому
// маршруту значение в справочнике роутерс и далее каким то
// оброзом поработать с основной страницей.
const handleLocation = async() =>{
    // window - один из так называемых зашитых главных служебных
    // элементов (существуют в рамках работы слюбым браузером)
    // Этот элемент может предоставлять всю служебную информацию
    // о текущем окне, в том числе адресс по которому мы сейчас
    // находимся.
    const path = window.location.pathname;

    // Далее оброщаемся к dictionary routers и по пути path нужно
    // получить значение, а если этого значения нет то возвращается
    // ключ 404.
    // Тем самым оброботаются любые значения.
    // Для этого создадим ещё одну вспомогательную переменную
    // (конечный маршрут).
    const route = routers[path] || routers[404];

    // Далее по этому маршруту обротимся к документу и
    // получим его содержимое.
    const html = await fetch(route).then((data) => data.text());

    // Далее оброщаемся к такому элементу, как document он позволяет
    // с помощью метода getElementById() искать и обращатся к любому
    // элементу на вашей странице.
    // Так же существует свойство innerHTML, которое позволяет
    // обращатся к внутреностям и далее заменим все внутрености на
    // содержымое которое мы добавили в переменной html.
    document.getElementById("main-page").innerHTML = html;
}

// Переопределим ещё одно служебное свойство
window.onpopstate = handleLocation;

// Для работы метода route() нужно переопределить несколько базовых
// свойств window
// свойство route должно указывать на наш метод route(). Это надо
// для того, чтобы мы могли обрабатывать маршрутизацию не только
// по нажатию на кнопки, но и если захотим вбить адресс в самой
// строке браузера.
window.route = route;

// Далее просто вызываем метод.
handleLocation();