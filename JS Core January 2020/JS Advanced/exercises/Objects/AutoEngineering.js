function solution(data) {
    const carModelFormat = (model, quantity) => `###${model} -> ${quantity}`;
    const output = [];
    data.forEach(row => {
        let [brand, model, quantity] = row.split(' | ');
        quantity = +quantity;
        if (output[brand]) {

            const index = output[brand].models.findIndex(x => x.model === model);
            if (index !== -1) {

                output[brand].models[index].quantity += quantity;
            } else {
                output[brand].models.push({
                    model,
                    quantity
                });
            }

        } else {

            output[brand] = {
                models: []
            };

            output[brand].models.push({
                model,
                quantity
            });
        }
    });
    for (brand in output) {
        console.log(brand);
        output[brand].models.forEach(car => {
            console.log(carModelFormat(car.model, car.quantity));
        })
    }
}