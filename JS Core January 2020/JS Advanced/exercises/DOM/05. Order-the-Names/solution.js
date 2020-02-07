function solve() {
    const addBtn = document.querySelector('button');
    const input = document.querySelector('input');
    const ol = document.querySelector('ol');
    const dataBase = Array.from(ol.children);
    addBtn.addEventListener('click', function () {
        let name = input.value;

        if (!name) {
            return;
        }
        name = name.charAt(0).toUpperCase() + name.slice(1).toLowerCase();
        let index = name.charCodeAt(0) - 65;
        if (dataBase[index].textContent.length === 0) {

            dataBase[index].textContent += name;
        } else {
            dataBase[index].textContent += ', ' + name;
        }
        input.value = null;

    });

}