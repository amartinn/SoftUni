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
        products[letter].forEach(product => {
            console.log(` ${product.name}:${product.price}`)
        });
    });

}
catalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
])