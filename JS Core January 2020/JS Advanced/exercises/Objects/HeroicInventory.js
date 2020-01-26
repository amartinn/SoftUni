function invetory(data) {
    return JSON.stringify(data.reduce((acc, heroString, i, arr) => {
        let [name, level, items] = heroString.split(' / ');
        acc.push({
            name,
            level: +level,
            items: items? items.split(', '):[]
        });
        return acc;
    }, []));
}