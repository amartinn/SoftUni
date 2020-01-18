function rotate(input){
    const rotations = +input.pop();
    for (let i = 0; i < rotations % 10; i++) {
        input.unshift(input.pop());
    }
    console.log(input.join(' '));
}
