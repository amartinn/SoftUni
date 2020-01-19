function checkMatrix(matrix) {
    const add = (a, b) => a + b;
    const rowSum = matrix[0, 0].reduce(add);
    let colSum = 0;
    for (let i = 0; i < matrix.length; i++) {
        const element = matrix[i][0];
        colSum += element;
    }
    const checkRowSum = (rowSum, currentRow) => {
        let currentRowSum = currentRow.reduce(add);
        if (currentRowSum !== rowSum) {
            return false;
        }
        return true;
    }
    const checkColSum = (ColSum, rowIndex) => {
        let currentRowSum = 0;
        for (let i = 0; i < matrix.length; i++) {
            let element = matrix[i][rowIndex];
            currentRowSum += element;
        }
        return currentRowSum === ColSum;
    }
    let index = 0;
    let flag = true;
    matrix.forEach(row => {
        let isRow = checkRowSum(rowSum, row);
        let isCol = checkColSum(colSum, index);
        if (!isRow || !isCol) {
            flag = false;
        }
        index++;
    });
    console.log(flag);
}