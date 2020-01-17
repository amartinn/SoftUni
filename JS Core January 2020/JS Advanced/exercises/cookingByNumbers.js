function cooking(params){
const functions = {
    chop:(x)=>x/2,
    dice:(x)=>Math.sqrt(x),
    spice:(x)=>x+1,
    bake:(x) =>x*3,
    fillet:(x)=>x*0.8
}
let number = +params[0];

for (let i = 1; i < params.length; i++) {
    const element = params[i];
   number=  functions[element](number);
    console.log(number);
    
}

}
