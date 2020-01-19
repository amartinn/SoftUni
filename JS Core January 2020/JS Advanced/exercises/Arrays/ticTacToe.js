function ticTacToe(moves) {
    const firstPlayerMark = 'X';
    const secondPlayerMark = 'O';
    const board = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];
    const printBoard = () => {
        board.forEach(row => {
            console.log(row.join('\t'));
        });
    }
    const isCellEmpty = (i, j) => board[i][j] === false;
    const isFirstPlayerMove = (index) => index % 2 == 0;
    const checkWin = (mark) => {
        let firstRow = board[0].every(x => x === mark);
        let secondRow = board[1].every(x => x === mark);
        let thirdRow = board[2].every(x => x === mark);

        let firstCol = board[0][0] === board[1][0] ?
            board[0][0] === board[2][0] ?
            board[0][0] === mark : false : false;

        let secondCol = board[0][1] === board[1][1] ?
            board[0][1] === board[2][1] ?
            board[0][1] === mark : false : false;

        let thirdCol = board[0][2] === board[1][2] ?
            board[0][2] === board[2][2] ?
            board[0][2] === mark : false : false;

        let firstDiagonal = board[0][0] === board[1][1] ?
            board[0][0] === board[2][2] ? board[0][0] === mark : false : false;

        let secondDiagonal = board[0][2] === board[1][1] ?
            board[0][2] === board[2][0] ?
            board[0][2] === mark : false : false;

        if (firstRow || secondRow || thirdRow || firstCol || secondCol || thirdCol ||
            firstDiagonal || secondDiagonal) {
            return true;
        }
        return false;
    }
    const fillCell = (mark, i, j) => board[i][j] = mark;
    const doTurn = (index, row, col) => {
        if (isFirstPlayerMove(index)) {
            //firstplayer do turn
            if (isCellEmpty(row, col)) {
                //cell is empty
                fillCell(firstPlayerMark, row, col);
            } else {
                // do repeated turn;
                repeatTurnFirstPlayer = true;
                console.log('This place is already taken. Please choose another!');
            }
        } else {
            //secondplaye do turn
            if (isCellEmpty(row, col)) {
                //cell is empty
                fillCell(secondPlayerMark, row, col);
            } else {
                // do repeated turn
                repeatTurnSecondPlayer = true;
                console.log('This place is already taken. Please choose another!');
            }
        }
    }
    const checkIfBoardIsFull = () => {
        for (let i = 0; i < board.length; i++) {
            const element = board[i];
            for (let j = 0; j < board.length; j++) {
                if (board[i][j] === false) {
                    return false;
                }
            }
        }
        return true;
    }
    let playerIndex = 0;
    let repeatTurnFirstPlayer = false;
    let repeatTurnSecondPlayer = false;
    for (let index = 0; index < moves.length; index++) {
        let cords = moves[index].split(' ');
        let i = +cords[0];
        let j = +cords[1];
        if (checkWin(firstPlayerMark) || checkWin(secondPlayerMark)) {
            break;
        }
        if (repeatTurnFirstPlayer) {
            repeatTurnFirstPlayer = false;
            //repeatTurnFirstPlayer
            playerIndex--;
            doTurn(playerIndex, i, j);
            playerIndex++;
            continue;

        }
        if (repeatTurnSecondPlayer) {
            repeatTurnSecondPlayer = false;
            // repeatTurnSecondPlayer
            playerIndex--;
            doTurn(playerIndex, i, j);
            playerIndex++;
            continue;

        }
        if (checkIfBoardIsFull()) {
            break;
        }
        doTurn(playerIndex, i, j);
        playerIndex++;
        if (checkWin(firstPlayerMark) || checkWin(secondPlayerMark)) {
            break;
        }
    }

    let symbol = checkWin(firstPlayerMark) ? firstPlayerMark :
        checkWin(secondPlayerMark) ? secondPlayerMark :
        undefined;
    if (symbol !== undefined) {
        console.log(`Player ${symbol} wins!`)
    } else {
        console.log(`The game ended! Nobody wins :(`);
    }
    printBoard();
}