class Rat {
    unitedRats;
    constructor(name) {
        this.name = name;
        this.unitedRats = [];
    }
    unite(otheRat) {
        if (otheRat instanceof(Rat)) {
            this.unitedRats.push(otheRat);
        }
    }
    getRats() {
        return this.unitedRats;
    }
    toString() {
        let output = this.name + '\n';
        this.unitedRats.forEach(rat => {
            output += `##${rat.name}\n`
        });
        return output;
    }

}
let rat2 = new Rat("Viktor");
rat2.unite(new Rat('asd'))
console.log(rat2.getRats())