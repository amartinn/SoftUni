function sameNumbers(number){
let isSame = true;
let sum = 0;
let digits = number
        .toString()
        .split('');
let firstDigit = digits[0];

digits.forEach(digit => {
    sum+=+digit;
    if (firstDigit!==digit) {
        isSame=false;
    }
});
console.log(isSame);
console.log(sum);
}
sameNumbers(1234)