function fruit(type,weightInGrams,pricePerKg){
    let weigthInKg = weightInGrams/1000;
    let price = weigthInKg*pricePerKg;
    console.log(`I need $${price.toFixed(2)} to buy ${weigthInKg.toFixed(2)} kilograms ${type}.`);


}
