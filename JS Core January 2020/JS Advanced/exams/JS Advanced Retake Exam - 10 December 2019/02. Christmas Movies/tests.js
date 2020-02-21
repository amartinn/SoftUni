let ChristmasMovies = require('./movies');
let assert = require('assert');
//TODO: fix issues
describe('movies', () => {
    let actual;
    let expected;
    let movies;
    beforeEach(() => {
        actual = '';
        expected = '';
        movies = new ChristmasMovies();
    })
    describe('constructor', () => {
        it('should initialize empty movieCollection', () => {
                actual = movies.movieCollection;
                expected = [];
                assert.deepEqual(actual, expected)
            }),
            it('should initialize empty watched', () => {
                actual = movies.watched;
                expected = {};
                assert.deepEqual(actual, expected)
            }),
            it('should initialize empty actors', () => {
                actual = movies.actors;
                expected = [];
                assert.deepEqual(actual, expected)
            })
    })

    describe('buyMovie()', () => {
        it('should add movie if it does not exists', () => {
                movies.buyMovie('name', ['john', 'martin'])
                actual = movies.movieCollection.length;
                expected = 1;
                assert.deepEqual(actual, expected)
            }),
            it('should return message', () => {
                actual = movies.buyMovie('name', ['john', 'martin'])
                expected = `You just got name to your collection in which john, martin are taking part!`;
                assert.deepEqual(actual, expected)
                assert.deepEqual(movies.movieCollection[0].actors.length,2);
            }),
            it('should distinct authors', () => {
                movies.buyMovie('name', ['john', 'john', 'john', 'john', 'john', 'john'])
                actual = movies.movieCollection.find(x => x.name === 'name').actors.length;
                expected = 1
                assert.deepEqual(actual, expected)
            }),
            it('should throw error', () => {
                actual = movies.buyMovie('name', ['john', 'martin'])
                assert.throws(() => movies.buyMovie('name', ['john', 'martin']), new Error(`You already own name in your collection!`))
            })
    })

    describe('discardMovie()', () => {
        it('should throw if not watched', () => {
                movies.buyMovie('name', ['john', 'martin'])
                assert.throws(() => movies.discardMovie('name'), new Error(`name is not watched!`))
            }),
            it('should remove it from watched',()=>{
                movies.buyMovie('name', ['john', 'martin'])
                movies.watchMovie('name');
                movies.discardMovie('name');
                actual = Object.keys(movies.watched).length;
                expected=0;
                assert.deepEqual(actual, expected);
            })
            it('should remove the movie', () => {
                movies.buyMovie('name', ['john', 'martin'])
                movies.watchMovie('name');
                movies.discardMovie('name');
                actual = movies.movieCollection.length;
                expected = 0;
                assert.deepEqual(actual, expected);
            }),
            it('should throw if not present', () => {
                assert.throws(() => movies.discardMovie('name'), new Error(`name is not at your collection!`))
            }),
            it('should return message', () => {
                movies.buyMovie('name', ['john', 'martin'])
                movies.watchMovie('name');
                actual = movies.discardMovie('name')
                expected = `You just threw away name!`;
                assert.deepEqual(actual, expected);
            })
    })

    describe('watchMovie()', () => {
        it('increase watched', () => {
                movies.buyMovie('name', ['john', 'martin']);
                movies.watchMovie('name');
                movies.watchMovie('name');
                actual = movies.watched['name'];
                expected = 2;
                assert.deepEqual(actual, expected);
            }),
            it('throw error if movie is not present', () => {
                assert.throws(() => movies.watchMovie(''), new Error('No such movie in your collection!'));
            }),
            it('should set the watched to 1', () => {
                movies.buyMovie('name', ['john', 'martin']);
                movies.watchMovie('name');
                actual = movies.watched['name'];
                expected = 1;
                assert.deepEqual(actual, expected);
            })
    })
    describe('favouriteMovie()', () => {
        it('return correct message ', () => {
                movies.buyMovie('name', ['john', 'martin']);
                movies.watchMovie('name');
                movies.watchMovie('name');
                actual = movies.favouriteMovie();
                expected = `Your favourite movie is name and you have watched it 2 times!`;
                assert.deepEqual(actual, expected);
            }),
            it('throw error if movies are not watched this year', () => {
                assert.throws(() => movies.favouriteMovie(''), new Error('You have not watched a movie yet this year!'));
            })
    })
    describe('mostStarredActor()', () => {
        it('throw error', () => {
            assert.throws(()=> movies.mostStarredActor(),new Error('You have not watched a movie yet this year!'))
        })
        it('should return the most starred actor', () => {
            movies.buyMovie('name', ['john', 'martin']);
            movies.buyMovie('name1', ['joh4n', 'martin7']);
            movies.buyMovie('name2', ['john', 'martin6']);
            actual = movies.mostStarredActor();
            expected = `The most starred actor is john and starred in 2 movies!`;
            assert.deepEqual(actual,expected)

        })
    })
})