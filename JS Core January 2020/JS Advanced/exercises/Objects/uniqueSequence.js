function findUniques(input) {
    let arrays = new Map();
    for (let i = 0; i < input.length; i++) {
        let currentArray = JSON.parse(input[i]).map(Number).sort((a, b) => b - a)
        let toAdd = currentArray.join(', ');
        if (!arrays.has(toAdd)) {
            arrays.set(toAdd, currentArray.length);
        }
    }
    let result = Array.from(arrays.keys()).sort((a, b) => arrays.get(a) - arrays.get(b));
    result.forEach(a => console.log(`[${a}]`));
}
