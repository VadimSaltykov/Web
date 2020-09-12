window.onload = init;

function init(){
    var button = document.getElementById("refrigerator")
    button.onclick = handleButtonClick;
}

function textColorName() {
    var colorInput = document.getElementById("colorNameInput");
    var colorName = colorInput.value;
    return(colorName);
}

function textBrandName() {
    var brandInput = document.getElementById("brandNameInput");
    var brandName = brandInput.value;
    return(brandName);
}

function textModelName() {
    var modelInput = document.getElementById("modelNameInput");
    var modelName = modelInput.value;
    return(modelName);
}

function textPriceName() {
    var priceInput = document.getElementById("priceNameInput");
    var priceName = priceInput.value;
    return(priceName);
}

function handleButtonClick() {
    if((textColorName() == "") || (textBrandName() == "") || (textModelName() == "") || (textPriceName() == "")){
        alert("Ошибка! Какой-то из параметров не введён");
    } else {
    alert("Вы создали холодильник со следующими параметрами:\n"
    	+ "Цвет: " + textColorName() + "\n" 
    	+ "Марка: " + textBrandName() + "\n" 
    	+ "Модель: " + textModelName() + "\n" 
    	+ "Цена: " + textPriceName() + "\n");
    }
}