function extract(input) {
    const output = [];
    const current = input[0];
    output.push(current);
    let biggest = current;
   input.forEach(function(curr,index,source){
       let next = source[index+1];
       if(next>=biggest){
           output.push(next);
           biggest=next;
       }
   });
    console.log(output.join('\n'));
}