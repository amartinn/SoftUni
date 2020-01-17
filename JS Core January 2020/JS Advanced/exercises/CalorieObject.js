function calories(products){

let output = {};
for (let i = 0; i < products.length-1; i+=2) {
    const product = products[i].toString();
    const calorie = +products[i+1];
    output[product] = calorie;
}
console.log(output);
}
