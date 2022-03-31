let modal = document.getElementById("category-menu");

let btn = document.getElementById("category-menu-button");

btn.onclick = function () {
    if (modal.style.display === "flex") {
        modal.style.display = "none";
    }
    else {
        modal.style.display = "flex"
    }
}

let mainCategoriesBlock = document.getElementById("main-categories");
let mainCategories = document.getElementsByClassName("main-category");
let subCategoryBlocks = document.getElementsByClassName("sub-categories");

let deselectButtons = function () {
    for (let categoryButton of mainCategories) {
        if (categoryButton.classList.contains("btn-primary")) {
            categoryButton.classList.remove("btn-primary");
            categoryButton.classList.add("btn-secondary");
        }
    }
}

let selectButton = function (button) {
    deselectButtons();
    button.classList.remove("btn-secondary");
    button.classList.add("btn-primary");
}

mainCategoriesBlock.onmouseover = function (event) {
    let element = event.fromElement;
    if (element.classList.contains("main-category")) {
        selectButton(element);
        let categoryId = element.getAttribute("data-category-id");
        for (let subCategoryBlock of subCategoryBlocks) {
            subCategoryBlock.style.display = "none";
            let parentCategoryId = subCategoryBlock.getAttribute("data-parent-category-id");
            if (parentCategoryId === categoryId) {
                subCategoryBlock.style.display = "flex";
            }
        }
    }
}

modal.onmouseleave = function (event) {
    for (let subCategoryBlock of subCategoryBlocks) {
        subCategoryBlock.style.display = "none";
    }
    deselectButtons();
    modal.style.display = "none";
}