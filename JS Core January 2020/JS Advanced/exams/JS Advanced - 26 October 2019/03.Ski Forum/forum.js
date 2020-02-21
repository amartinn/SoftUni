//TODO: fix test#6
class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
    }
    register(username, password, repeatPassword,email) {
        if (!username || !password || !repeatPassword || !email) {
            throw new Error("Input can not be empty");
        }
        if (password !== repeatPassword) {
            throw new Error("Passwords do not match");
        }
        let user = this._users.find(x => x.email === email ||x.user===username);
        if (user !== undefined) {
            throw new Error("This user already exists!");
        }
        this._users.push({
            username,
            password,
            email,
            isLoggedIn: false
        });
        return `${username} with ${email} was registered successfully!`
    }
    login(username, password) {
        let user = this._users.find(x => x.username === username);
        if (!user) {
            throw new Error("There is no such user");
        }
        if (user.password === password) {
            user.isLoggedIn = true;
            return "Hello! You have logged in successfully";

        }
    }
    logout(username, password) {
        let user = this._users.find(x => x.username === username);
        if (!user) {
            throw new Error("There is no such user");
        }
        if (user.password === password) {
            user.isLoggedIn = false;
            return "You have logged out successfully";
        }
    }
    postQuestion(username, question) {
        let user = this._users.find(x => x.username === username);
        if (!user || !user.isLoggedIn) {
            throw new Error("You should be logged in to post questions");
        }
        if (!question) {
            throw new Error("Invalid question");
        }
        this._questions.push({
            id: this._id++,
            user: user.username,
            question,
            answers: []
        });
        return "Your question has been posted successfully";
     }
     postAnswer(username, questionId, answer) {
        let user = this._users.find(x => x.username === username);
        if (!user || !user.isLoggedIn) {
            throw new Error("You should be logged in to post answers");
        }
        if (!answer) {
            throw new Error("Invalid answer");
        }
        let question = this._questions.find(x => x.id === questionId);
        if (!question) {
            throw new Error("There is no such question");
        }
        question.answers.push({
            user: user.username,
            answer
        });
        return "Your answer has been posted successfully";
    }
    showQuestions() {
        let output = '';
        for (let question of this._questions) {
            output += `Question ${question.id} by ${question.user}: ${question.question}\n`;
            for (let answer of question.answers) {
                output += `---${answer.user}: ${answer.answer}\n`;
            }
        }
        return output.trim();
    }
}

let forum = new Forum();

forum.register('Michael', '123', '123', 'michael@abv.bg');
forum.register('Stoyan', '123ab7', '123ab7', 'some@gmail@.com');
forum.login('Michael', '123');
forum.login('Stoyan', '123ab7');

forum.postQuestion('Michael', "Can I rent a snowboard from your shop?");
forum.postAnswer('Stoyan',1, "Yes, I have rented one last year.");
forum.postQuestion('Stoyan', "How long are supposed to be the ski for my daughter?");
forum.postAnswer('Michael',2, "How old is she?");
forum.postAnswer('Michael',2, "Tell us how tall she is.");

console.log(forum.showQuestions());
