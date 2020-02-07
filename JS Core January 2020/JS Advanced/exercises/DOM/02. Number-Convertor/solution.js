function solve() {
const selectMenu = document.getElementById('selectMenuTo');
const convertButton = document.getElementsByTagName('button')[0];
const result = document.getElementById('result');
const input = document.getElementById('input');
const systems = ['Binary','Hexadecimal'];
for (let i = 0; i < systems.length; i++) {
    const selectElement = document.createElement('option');
    selectElement.value = systems[i].toLocaleLowerCase();
    selectElement.text=systems[i];
    selectMenu.appendChild(selectElement);
}

convertButton.addEventListener('click',e =>{
    if(input.value==='' || selectMenu.value ===''){
        return;
    }
const selectedSystem = selectMenu.value;
const inputNumber =+input.value;
let output;
switch(selectedSystem){
    case'binary':
    output = inputNumber.toString(2);
    break;
    case'hexadecimal':
    output = inputNumber.toString(16).toUpperCase();
    break;
}
result.value=output;

})
}