function sortArray(array, keyWord) {
    keyWord === 'asc' ? array.sort((a, b) => a - b) : array.sort((a, b) => b - a)
    return array;
}