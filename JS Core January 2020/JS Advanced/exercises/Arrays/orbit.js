function orbit(input) {
    const rows = input[0];
    const cols = input[1];
    const firstCellRow = input[2];
    const firstCellCol = input[3];

    let initialNumber = 1;

    const orbit = new Array(rows)
        .fill()
        .map(() => new Array(cols).fill(''));

    orbit[firstCellRow][firstCellCol] = initialNumber;

    const isInside = (row, col) => {
        return row >= 0 && row < orbit.length &&
            col >= 0 && col < orbit.length;
    }
    const isCellFree = (row, col) => orbit[row][col] === '';
    const changeNeighbours = (row, col, number) => {
        // '' '' ''
        // '' 1 ''
        // '' '' ''
        //upleft
        if (isInside(row - 1, col - 1) && isCellFree(row - 1, col - 1)) {
            orbit[row - 1][col - 1] = number;
        }
        // up middle
        if (isInside(row - 1, col) && isCellFree(row - 1, col)) {
            orbit[row - 1][col] = number;
        }
        // up right
        if (isInside(row - 1, col + 1) && isCellFree(row - 1, col + 1)) {
            orbit[row - 1][col + 1] = number;
        }
        // left
        if (isInside(row, col - 1) && isCellFree(row, col - 1)) {
            orbit[row][col - 1] = number;
        }
        // right
        if (isInside(row, col + 1) && isCellFree(row, col + 1)) {
            orbit[row][col + 1] = number;
        }
        // down left
        if (isInside(row + 1, col - 1) && isCellFree(row + 1, col - 1)) {
            orbit[row + 1][col - 1] = number;
        }
        //down middle
        if (isInside(row + 1, col) && isCellFree(row + 1, col)) {
            orbit[row + 1][col] = number;
        }
        // down right
        if (isInside(row + 1, col + 1) && isCellFree(row + 1, col + 1)) {
            orbit[row + 1][col + 1] = number;
        }
    }
    const isOrbitFull = () => {
        let flag = true;
        orbit.forEach(row => {
            const fill = row.every(x => x !== '');
            if (!fill) {
                flag = false;
            }
        });
        return flag;
    }
    while (!isOrbitFull()) {

        for (let i = 0; i < orbit.length; i++) {
            for (let j = 0; j < orbit.length; j++) {
                const element = orbit[i][j];
                if (element === initialNumber) {
                    changeNeighbours(i, j, initialNumber + 1);
                }

            }

        }
        initialNumber++;

    }
    orbit.forEach(row => {
        console.log(row.join(' '));
    })
}