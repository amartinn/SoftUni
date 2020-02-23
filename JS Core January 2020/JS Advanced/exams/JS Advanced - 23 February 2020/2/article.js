'use strict'
class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
        this._id = 1;
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }
        if (this._likes.length === 1) {
            return `${this._likes[0].username} likes this article!`;
        }
        return `${this._likes[0].username} and ${this._likes.length-1} others like this article!`;
    }

    like(username) {
        if (this._likes.find(x => x.username === username)) {
            return "You can't like the same article twice!";
        }
        if (username === this.creator) {
            return "You can't like your own articles!"
        }
        this._likes.push({
            username
        })
        return `${username} liked ${this.title}!`

    }
    dislike(username) {
        let user = this._likes.find(x => x.username === username);
        if (!user) {
            throw new Error("You can't dislike this article!");
        }
        let index = this._likes.indexOf(user);
        this._likes.splice(index, 1)
        return `${username} disliked ${this.title}`;
    }
    comment(username, content, id) {
        let comment = this._comments.find(x => x.Id === id);
        if (!id || !comment) {
            let newComment = {
                Username: username,
                Content: content,
                Id: this._id++,
                Replies: []
            };
            this._comments.push(newComment);
            return `${username} commented on ${this.title}`
        } 
        else {
            let count = comment.Replies.length + 1;
            comment.Replies.push({
                Id: `${comment.Id}.${count===undefined?'1':count}`,
                Username: username,
                Content: content
            });
        }
        return "You replied successfully";
    }

    toString(sortingType) {
        let output = `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:\n`
        let sortedComments;
        if (sortingType === 'asc') {
            sortedComments = this._comments.sort((a, b) => {
                if (a.Id > b.Id) return 1;
                if (b.Id > a.Id) return -1;
                return 0;
            })
            sortedComments.forEach(c => {
                output += `-- ${c.Id}. ${c.Username}: ${c.Content}\n`
                c.Replies.sort((a, b) => {
                    if (a.Id > b.Id) return 1;
                    if (b.Id > a.Id) return -1;
                    return 0;
                })
                c.Replies.forEach(r => {
                    output += `--- ${r.Id}. ${r.Username}: ${r.Content}\n`
                })
            })
        } else if (sortingType === 'desc') {
            sortedComments = this._comments.sort((a, b) => {
                if (a.Id > b.Id) return -1;
                if (b.Id > a.Id) return 1;
                return 0;
            })

            sortedComments.forEach(c => {
                output += `-- ${c.Id}. ${c.Username}: ${c.Content}\n`
                c.Replies.sort((a, b) => {
                    if (a.Id > b.Id) return -1;
                    if (b.Id > a.Id) return 1;
                    return 0;
                })
                c.Replies.forEach(r => {
                    output += `--- ${r.Id}. ${r.Username}: ${r.Content}\n`
                })
            })
        } else if (sortingType === 'username') {
            sortedComments = this._comments.sort((a, b) => {
                if (a.Username > b.Username) return 1;
                if (b.Username > a.Username) return -1;
                return 0;
            })

            sortedComments.forEach(c => {
                output += `-- ${c.Id}. ${c.Username}: ${c.Content}\n`
                c.Replies.sort((a, b) => {
                    if (a.Username > b.Username) return 1;
                    if (b.Username > a.Username) return -1;
                    return 0;
                })
                c.Replies.forEach(r => {
                    output += `--- ${r.Id}. ${r.Username}: ${r.Content}\n`
                })
            })
        }
        return output.trim();
    }
}
