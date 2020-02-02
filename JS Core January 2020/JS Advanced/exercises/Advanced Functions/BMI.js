function personalBMI(name,age,weight,height){
    let heightInMeters = height/100;
const bmi = Math.round(+weight/(+heightInMeters*+heightInMeters));
const output = {
    name:name,
    personalInfo:{
        age:age,
        weight:weight,
        height:height
    },
    BMI:bmi,
    status:bmi <18.5?`underweight`:bmi <25?'normal':bmi<30?'overweight':'obese',
}
if(output.status==='obese'){
    output.recommendation = 'admission required' 
}
return output;
}

console.log(personalBMI('Kotooshu', 33, 152, 203))