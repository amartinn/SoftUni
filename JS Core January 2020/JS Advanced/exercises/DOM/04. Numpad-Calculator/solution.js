function solve() {
    const pad = document.getElementsByClassName('keys')[0];
    const expression = document.getElementById('expressionOutput');
    const result = document.getElementById('resultOutput');
    const clearBtn = document.querySelector('.clear');
    clearBtn.addEventListener('click', e => {
        expression.textContent = '';
        result.textContent = '';
    })
    const operators = ['*','/', '+', '-'];
    const operations = {
        '+': (num1,num2) =>+num1+(+num2),
        '-': (num1,num2) =>+num1-(+num2),
        '/': (num1,num2) =>+num1/(+num2),
        '*': (num1,num2) =>+num1*(+num2)
    }
    pad.addEventListener('click', e => {
        let value = e.target.value;
        if (!value) {
            return;
        }
     
        if(value==='='){
            let params = expression.textContent
            .split(' ')
            .filter(x=>x!== '');
            if(params[2] !== undefined){
                result.textContent = operations[params[1]](params[0],params[2]);
                return;
            }
            result.textContent = 'NaN';
            return;
        }
       
        if(operators.includes(value)){
            expression.textContent =    expression.textContent + ` ${value} `;
            return;
        }
        expression.textContent +=value;

    })
}