let Parser = require("./solution.js");
let assert = require("chai").assert;
describe("MyTests", () => {
    let actual;
    let expected;
    let parser;
    beforeEach(() => {
        actual = '';
        expected = '';
        parser = new Parser('[{"Nancy":"architect"},{"John":"developer"},{"Kate":"HR"}]');
    })
    describe('constructor', () => {
        it('_data should be parsed to JSON', () => {
            expected = JSON.parse('[{"Nancy":"architect"},{"John":"developer"},{"Kate":"HR"}]');
            actual = parser._data;
            assert.deepEqual(actual, expected);
        })
        it('_log should be []', () => {
            expected = []
            actual = parser._log;
            assert.deepEqual(actual, expected);
        })
        it('_addToLog', () => {
            expected = 'Added to log'
            actual = parser._addToLog()
            assert.deepEqual(actual, expected);
            assert.deepEqual(parser._log, ['0: undefined'])
        }),
        it('_addToLog should add undefined with 0 ',()=>{
            expected = ['0: undefined']
            parser._addToLog()
            actual = parser._log
            assert.deepEqual(actual,expected )
        })
        it('_addToLog type should be function',()=>{
            expected = typeof "function";
            actual =  typeof parser._addToLog();
            assert.deepEqual(actual,expected)
        })

    })
    describe('getter data', () => {
        it('should add to log', () => {
            parser._addToLog("getData");
            actual = parser._log;
            expected = ['0: getData'];
            assert.deepEqual(actual, expected)
        })
        it('should return data without deleted entries', () => {
            parser.addEntries("Steven:tech-support Edd:administrator");
            parser.removeEntry("Kate");
            actual=parser.data.length;
            expected=4;
            assert.deepEqual(actual,expected);
        })
        it('should return data ', () => {
            parser.addEntries("Steven:tech-support Edd:administrator");
            parser.removeEntry("Kate");
            actual=parser.data
            expected=[
                { Nancy: 'architect' },
                { John: 'developer' },
                { Steven: 'tech-support' },
                { Edd: 'administrator' }
              ]
            assert.deepEqual(actual,expected);
        })
    })
    describe('print()', () => {
        it('should add to log', () => {
            parser._addToLog("print");
            actual = parser._log;
            expected = ['0: print'];
            assert.deepEqual(actual, expected)
        })
        it('return filtered data', () => {
            expected = `id|name|position\n0|Nancy|architect\n1|John|developer\n2|Kate|HR`;
            actual = parser.print();
            assert.deepEqual(actual, expected);
        })
    })
    describe('addEntries', () => {
        it('should add to log', () => {
            parser._addToLog("addEntries");
            actual = parser._log;
            expected = ['0: addEntries'];
            assert.deepEqual(actual, expected)
        })
        it('should add entry', () => {
            parser.addEntries("Steven:tech-support Edd:administrator")
            expected = [{
                    Nancy: 'architect'
                },
                {
                    John: 'developer'
                },
                {
                    Kate: 'HR'
                },
                {
                    Steven: 'tech-support'
                },
                {
                    Edd: 'administrator'
                }
            ]
            actual = parser._data;
            assert.deepEqual(actual, expected)
        })
        it('should return message', () => {
            actual = parser.addEntries("Steven:tech-support Edd:administrator")
            expected = "Entries added!";
            assert.deepEqual(actual, expected)
        })
    })
    describe('removeEntry()', () => {
        it('should throw if entry is deleted', () => {
            key = 'Kate';
            parser.removeEntry(key)
            assert.throws(() => parser.removeEntry(key),"There is no such entry!")
        })
        it('should throw if entry is undefined', () => {
            key = undefined;
            assert.throws(() => parser.removeEntry(key),"There is no such entry!")
        })
        it('should add to log', () => {

            parser._addToLog("removeEntry");
            actual = parser._log;
            expected = ['0: removeEntry'];
            assert.deepEqual(actual, expected)

        }),
        it('should add property deleted',()=>{
            parser.removeEntry('Kate');
            expected = true;
            actual = parser._data[2].hasOwnProperty('deleted');
            assert.deepEqual(actual,expected);
        })
        it('should add property deleted with TRUE value',()=>{
            parser.removeEntry('Kate');
            expected = true;
            actual = parser._data[2].deleted;
            assert.deepEqual(actual,expected);
        })
        it('should return message', () => {
            expected = "Removed correctly!";
            actual = parser.removeEntry('Kate');
            assert.deepEqual(actual,expected)
        })
    })
    describe('_addToLog()', () => {
        it('should increase counter', () => {
            parser._addToLog('command1');
            parser._addToLog('command2');
            expected = 2;
            actual = parser._log.length;
            assert.deepEqual(actual, expected)
        })
        it('should add proper commands', () => {
            parser.addEntries("Steven:tech-support Edd:administrator");
            parser.removeEntry("Kate")
            parser.data
            expected = ['0: addEntries', '1: removeEntry', '2: getData']
            actual = parser._log;
            assert.deepEqual(actual, expected)
        })
    })
});