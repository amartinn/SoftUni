function solution(...data) {
    let counts = {};
    data.forEach(el => {
        const type = typeof el;
        console.log(`${typeof el}: ${el}`);
        if (!counts.hasOwnProperty(type)) {
            counts[type] = 0;
        }
        counts[type]++;
    })
    Object.entries(counts)
        .sort((a, b) => {
            const [aKey, aValue] = a;
            const [bKey, bValue] = b;
            return bValue - aValue;
        })
        .forEach(el => {
            console.log(`${el[0]} = ${[el[1]]} `);
        })
}
solution('cat', 42, function () {
    console.log('Hello world!');
})