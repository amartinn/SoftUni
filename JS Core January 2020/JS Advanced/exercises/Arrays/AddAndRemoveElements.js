function solution(input) {
    const output = [];
    let initialNumber = 1;
    input.forEach(command => {
        if (command === 'remove') {
            output.pop();
        } else {
            output.push(initialNumber);
        }
        initialNumber++;
    });
    let isEmpty = output.length === 0;
    console.log(isEmpty ? 'Empty' : output.join('\n'))
}