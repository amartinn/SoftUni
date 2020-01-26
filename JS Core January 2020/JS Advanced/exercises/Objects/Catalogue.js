function catalogue(input) {
    let products = [];
    const letters = [];
    input.forEach(element => {
        let productArgs = element.split(' : ');
        let productName = productArgs[0];
        let productPrice = +productArgs[1];
        let product = {
            name: productName,
            price: productPrice
        }
        let letter = productName[0];
        if (products[letter] === undefined) {
            products[letter] = [];
            letters.push(letter);
        }
        products[letter].push(product);
    });
    letters.sort();
    letters.forEach(letter => {
        console.log(letter);
        products[letter].sort(function(a,b){
            if(a.name>=b.name){
                return 1;
            }
            else{
                return -1;
            }
        });
        products[letter].forEach(product => {
            console.log(`  ${product.name}: ${product.price}`)
        });
    });

}