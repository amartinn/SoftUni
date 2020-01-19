function diagonalAttack(matrix) {
    matrix.map(Number);
    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;
    let index = 1;
    const printBoard = (arr) => {
        arr.forEach(row => {
            console.log(row);
        });
    }
    for (let row = 0; row < matrix.length; row++) {
        let matrixRow = matrix[row, row];
        let elements = matrixRow.split(' ');
        leftDiagonalSum += +elements[row];
        rightDiagonalSum += +elements[matrix.length - index];

        index++;
    }
    index = 1;
    let output = [];
    if (leftDiagonalSum === rightDiagonalSum) {
        for (let row = 0; row < matrix.length; row++) {
            let matrixRow = matrix[row, row];
            let elements = matrixRow.split(' ');
            let leftDiagonalNumber = +elements[row];
            let rightDiagonalNumber = +elements[matrix.length - index];
            let leftNumberIndex = row;
            output[row] = [];
            let rightNumberIndex = matrix.length - index;
            for (let i = 0; i < matrix.length; i++) {
                output[row][i] = leftDiagonalSum;
            }
            output[row][leftNumberIndex] = leftDiagonalNumber;
            output[row][rightNumberIndex] = rightDiagonalNumber;
            index++;
        }
        output.forEach(row => {
            console.log(row.join(' '));
        })
    } else {
        printBoard(matrix);
    }


}
diagonalAttack(
    ['1 1 1',
        '1 1 1',
        '1 1 0'
    ]
);