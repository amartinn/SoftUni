function solution(input){
    const step = +input.pop();
    for (let i = 0; i < input.length; i+=step) {
        const element = input[i];
        console.log(element)
    }
}
