function solution(data, sortType) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    const output = data.reduce((acc, curr) => {
            let [destination, price, status] = curr.split('|');
            let ticket = new Ticket(destination, +price, status);
            acc.push(ticket);
            return acc;
        }, [])
        .sort(function (a, b) {
            if (!sortType || sortType === 'destination') {
                return a.destination.localeCompare(b.destination);
            } else if (sortType === 'price') {
                return a.price - b.price;
            } else {
                return a.status.localeCompare(b.status);
            }
        })
    return output;
}
