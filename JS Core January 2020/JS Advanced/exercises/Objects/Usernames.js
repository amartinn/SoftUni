function solution(usernames) {
    const uniques = [...new Set(usernames)];

    uniques.sort((a, b) => {
        if (a.length != b.length) {
            return a.length - b.length;
        }
        return a.localeCompare(b);
    });
    console.log(uniques.join('\n'))
}