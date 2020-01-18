function extract(input){
    const output = [];
    const current = input[0];
    output.push(current);
    let biggest = current;
    input.reduce(function(NaN,next){
        if( next>=biggest){
            output.push(next);
            biggest = next;
        }
        
    });
    console.log(output.join('\n'));
}
