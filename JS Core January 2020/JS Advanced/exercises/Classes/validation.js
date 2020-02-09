class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = this.setClientId(clientId);
        this.email = this.setEmail(email);
        this.firstName = this.setName(firstName, 'First');
        this.lastName = this.setName(lastName, 'Last');
    }
    isLetter(str) {
        return str.length === 1 && str.match(/[a-z]/i);
    }
    setClientId(id) {
        if (id.length !== 6 || typeof (id) !== 'string') {
            throw new TypeError('Client ID must be a 6-digit number');
        }
        return id;
    }
    setEmail(email) {
        let regex = `\w*@[A-Za-z.]{1,}`;
        if (!email.match(regex)) {
            throw new TypeError("Invalid e-mail");
        }
        return email;
    }
    setName(name, type) {
        let hasOnlyLetters = Array.from(name).every(x => this.isLetter(x));

        if (name.length < 3 || name.length > 20) {
            throw new TypeError(`${type} name must be between 3 and 20 characters long`)
        }
        if (!hasOnlyLetters) {
            throw new TypeError(`${type} name must contain only Latin characters`)
        }
        return name;
    }

}