class ChristmasDinner{
    constructor(budget){
        this.dishes=[];
        this.products =[];
        this.guests = {};
        if(budget<0){
            throw new Error("The budget cannot be a negative number");
        }
        this.budget=budget;
    };
    shopping([product,price]){
        let canBeBroght = this.budget - price>=0;
        if(!canBeBroght){
            throw new Error("Not enough money to buy this product");
        }
        this.budget-=price;
        this.products.push(product)
        return `You have successfully bought ${product}!`;
    }
    recipes(recipe){
        let name = recipe.recipeName;
        let products = recipe.productsList;
        if(products.every(x=>this.products.includes(x))){
            this.dishes.push(recipe);
            return `${name} has been successfully cooked!`;
        }
        throw new Error("We do not have this product");
    }
    inviteGuests(name, dish){
        let isDishFound = this.dishes.find(x=>x.recipeName === dish);
        if(!isDishFound){
            throw new Error("We do not have this dish");
        }
        if(Object.keys(this.guests).includes(name)){
            throw new Error("This guest has already been invited");
        }
        this.guests[name] = dish;
        return `You have successfully invited ${name}!`;
    }
    showAttendance(){
        let output = '';
        Object.keys(this.guests).forEach(g=>{
            let guestName = g;
            let dish = this.guests[g];
            let products = this.dishes.find(x=>x.recipeName === dish).productsList;
            output += `${guestName} will eat ${dish}, which consists of ${products.join(', ')}\n`
        })
        return output.trim();
    }
}
