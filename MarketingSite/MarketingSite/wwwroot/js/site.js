//Событие отправки формы на сервер
document.getElementsByTagName("form")[0].addEventListener("submit", function (event) {
    let date = document.getElementById("date").value;
    let dateParts = date.split('.');
    //GoogleChrome валидирует дату => проверка не осуществляется
    if (!isValidDate(date)) {
        //Enternet Explorer не валидирует дату => простая проверка
        if (dateParts.length !== 3 ||
            dateParts[0].length !== 2 || dateParts[1].length !== 2 || dateParts[2].length !== 4) {
            //Отмена события - дата не верная
            event.preventDefault();
            document.getElementById("errorMessages").textContent = "\nВведите 'Дату окончания разработки' в формате 'день.месяц.год'";
        }
    }

}, false)
//Проверка на тип введенной строки (дата)
function isValidDate(str) {
    let noSpace = str.replace(/\s/g, '')
    if (noSpace.length < 3) {
        return false
    }
    return Date.parse(noSpace) > 0
}

//Массив исходных элементов спаска
let initialOptions = [];
//Заполнение массива исходных элементов спаска по окончании загрузки страницы
document.addEventListener('DOMContentLoaded', function () {
    let options = document.getElementById("ApplicationId").children;
    for (let i = 0; i < options.length; i++) {
        initialOptions.push(options[i]);
    }
});

//Фильтрация выпадающего списка. Список очищается, затем запоняется элементами, включающими подстроку.
function filterSelect () {
    let substr = document.getElementById("filter").value.toLowerCase();
    let select = document.getElementById("ApplicationId");
    //Очистка списка
    removeOptions(select);
    for (let i = 0; i < initialOptions.length; i++) {
        //Текст элемента списка
        let text = initialOptions[i].textContent.toLowerCase();
        //Если подстрока найдена, добавляем элемент из списка исходных
        if (text.indexOf(substr) !== -1) {
            select.add(initialOptions[i]);
        }
    }
}

//Очистка списка
function removeOptions(select) {
    for (let i = select.options.length - 1; i >= 0; i--) {
        select.remove(i);
    }
}