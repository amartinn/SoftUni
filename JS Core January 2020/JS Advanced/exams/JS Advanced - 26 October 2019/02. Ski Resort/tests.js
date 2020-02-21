describe('Ski Resort', () => {
    let actual;
    let expected;
    let resort;
    beforeEach(() => {
        actual = '';
        expected = '';
        resort = new SkiResort('name');
    })
    describe('constructor', () => {
        it('should initialize with correct name', () => {
                actual = resort.name;
                expected = 'name';
                assert.deepEqual(actual, expected);
            }),
            it('should initialzie with correct voters', () => {
                actual = resort.voters;
                expected = 0;
                assert.deepEqual(actual, expected);
            }),
            it('should initialize empty array hotels', () => {
                actual = resort.hotels;
                expected = [];
                assert.deepEqual(actual, expected);
            })
    })
    describe('best hotel getter', () => {
        it('should return correct text when voters equal zero', () => {
                actual = resort.bestHotel;
                expected = "No votes yet";
                assert.deepEqual(actual, expected);
            }),
            it('should return best hotel', () => {
                resort.build('test',1);
                resort.build('test2',2);
                resort.build('test3',3);
                resort.leave('test',1,3);
                resort.leave('test2',2,4);
                resort.leave('test3',3,5);
                actual = resort.bestHotel;
                expected = `Best hotel is test3 with grade 15. Available beds: 6`;
                assert.deepEqual(actual,expected)

                
            })
    })
    describe('build()', () => {
        it('should throw error if hotelName is null', () => {
                assert.throws(() => resort.build('', 2), new Error("Invalid input"))
            }),
            it('throw if beds are less than one', () => {
                assert.throws(() => resort.build('test', 0), new Error("Invalid input"))
            }),
            it('should add the hotel', () => {
                let hotel = {
                    name: 'name',
                    beds: 3,
                    points: 0
                }
                resort.build('name', 3);
                assert.deepEqual(resort.hotels.length, 1);
                assert.deepEqual(resort.hotels.find(x=>x.name==='name'), hotel);
            }),
            it('should return message', () => {
                actual = resort.build('name', 3);
                expected = `Successfully built new hotel - name`;
                assert.deepEqual(actual, expected)
            })
    })
    describe('book()', () => {
        it('should throw error if hotelName is null', () => {
                assert.throws(() => resort.book('', 2), new Error("Invalid input"))
            }),
            it('throw if beds are less than one', () => {
                assert.throws(() => resort.book('test', 0), new Error("Invalid input"))
            }),
            it('should throw if hotel not found', () => {
                assert.throws(() => resort.book('test', 3), new Error("There is no such hotel"))
            }),
            it('should throw if hotel beds are less than input', () => {
                resort.build('test', 3);
                assert.throws(() => resort.book('test', 4), new Error("There is no free space"))
            }),
            it('should remove the nessecery beds', () => {
                resort.build('test', 3);
                resort.book('test', 3);
                actual = resort.hotels.find(x=>x.name==='test').beds;
                expected = 0;
                assert.deepEqual(actual, expected);
            }),
            it('should return message', () => {
                resort.build('test', 3);
                actual = resort.book('test', 3);
                expected = "Successfully booked"
                assert.deepEqual(actual, expected);
            })
    })
    describe('leave()', () => {
        it('should throw error if hotelName is null', () => {
                assert.throws(() => resort.leave('', 2), new Error("Invalid input"))
            }),
        it('throw if beds are less than one', () => {
                assert.throws(() => resort.leave('test', 0), new Error("Invalid input"))
            }),
        it('should throw if hotel not found', () => {
                assert.throws(() => resort.leave('test', 3), new Error("There is no such hotel"))
            }),
        it('should add points to the hotel', () => {
                resort.build('name', 3);
                resort.leave('name', 2, 3);
                expected = {
                    beds: 5,
                    name: 'name',
                    points: 6
                }
                actual = resort.hotels.find(x=>x.name==='name');
                assert.deepEqual(actual, expected)
            }),
        it('should increase voters', () => {
            resort.build('name', 3);
            resort.leave('name', 2, 3);
            actual = resort.voters;
            expected = 2;
            assert.deepEqual(actual, expected)
        }),
        it('should increase beds',()=>{
            resort.build('name', 3);
            resort.leave('name', 2, 3);
            actual = resort.hotels.find(x=>x.name=='name').beds;
            expected=5;
            assert.deepEqual(actual,expected);
        })
        it('should return message', () => {
            resort.build('name', 3);
            actual = resort.leave('name', 2, 3);
            expected = `2 people left name hotel`;
            assert.deepEqual(actual, expected)
        })
    })
    describe('averageGrade()', () => {
        it('should return message if no voters', () => {
            actual = resort.averageGrade();
            expected = "No votes yet";
            assert.deepEqual(actual,expected);
        }),
        it('should calculate average', () => {
            resort.build('test',1);
            resort.build('test2',2);
            resort.build('test3',3);
            resort.leave('test',1,3);
            resort.leave('test2',2,4);
            resort.leave('test3',3,5);

            actual  = resort.averageGrade();
            expected =  `Average grade: 4.33`;
            assert.deepEqual(actual,expected)
        })
    })
})