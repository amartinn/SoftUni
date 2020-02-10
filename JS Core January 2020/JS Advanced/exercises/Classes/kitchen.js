// TODO fix the bugs!

class Kitchen {
    constructor(budget) {
        this.budget = +budget;
        this.menu = [];
        this.productsInStock = [];
        this.actionsHistory = [];
    }
    loadProducts(products) {
        products.forEach(product => {
            let [productName, productQuantity, productPrice] = product.split(' ');
            productQuantity = +productQuantity;
            productPrice = +productPrice;
            let isAdded = true;
            if (this.budget - productPrice >= 0) {
                if (this.productsInStock[productName]) {
                    this.productsInStock[productName].productQuantity += productQuantity;
                } else {
                    this.productsInStock[productName] = {
                        productName,
                        productQuantity,
                        productPrice
                    };
                }
                this.budget -= productPrice;

            } else {
                isAdded = false;
            }
            this.actionsHistory.push(isAdded ? `Successfully loaded ${productQuantity} ${productName}` :
                `There was not enough money to load ${productQuantity} ${productName}`);
        });
        return this.actionsHistory.join('\n');
    }
    addToMenu(meal, neededProducts, price) {

        let products = neededProducts.reduce((acc, product) => {
            let [productName, productQuantity] = product.split(' ').map(x => x.trim());
            acc[productName] = productQuantity;
            return acc;
        }, {});

        if (this.menu[meal]) {
            return `The ${meal} is already in our menu, try something different.`

        } else {
            this.menu[meal] = {
                meal,
                products,
                price
            }   
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`

        }

    }
    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }    
        let gotProducts = true;
        Object.keys(this.productsInStock).forEach(product => {
            if (!this.menu[product]) {
                gotProducts = false;
            }
        })
        if (gotProducts) {
            this.productsInStock.forEach(product => {
                this.productsInStock[meal].productQuantity -= this.menu[meal][product].productQuantity;
            });
        }
        return gotProducts ? `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.` :
            `For the time being, we cannot complete your order (${meal}), we are very sorry...`;

    }
    showTheMenu() {
        if(this.menu.length===0){
            return "Our menu is not ready yet, please come later..."
        }
        let output = '';
        Object.keys(this.menu).forEach(key => {
            output += `${this.menu[key].meal} - $ ${this.menu[key].price}\n`
        })
        return output.trim();
    }
}
