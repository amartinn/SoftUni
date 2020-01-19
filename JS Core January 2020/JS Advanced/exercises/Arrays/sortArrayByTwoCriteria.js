function sort(input){
    input.sort((a,b) => {
        if(a.length < b.length){
            return -1;
        }
        if(a.length >b.length){
            return 1;
        }
        if(a > b){
            return 1;
        }
        if(a<b){
            return -1;
        }

    });
    console.log(input)
}
