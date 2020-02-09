class Stringer{
    constructor(string,length){
        this.string =string;
        this.innerLength=length;
        this.dots = '...';
        this.innerString = string;


    }
    increase(length){
        this.string = this.innerString;
        this.innerLength+=length;
        this.string = this.string.slice(0,this.innerLength);
    }
    decrease(length){
        this.string=this.innerString
        if(this.innerLength-length<=0){
            this.innerLength=0;
            this.string =  this.dots;
            return;
        }
        this.innerLength-=length;
        this.string =  this.string.slice(0,this.innerLength) + this.dots;
    }
    toString(){
        return this.string;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test
test.increase(3);
test.increase(4); 
test.increase(4); 
console.log(test.toString()); // Te...
console.log(test.innerLength)
