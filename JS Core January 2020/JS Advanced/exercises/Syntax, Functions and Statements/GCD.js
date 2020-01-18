function GCD(first,second){
    while(second){
        let t = second;
        second=first%second;
        first=t;
    }
    console.log(first);
}
GCD(2154,458)