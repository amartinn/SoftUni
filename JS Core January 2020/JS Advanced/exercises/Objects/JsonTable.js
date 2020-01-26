function table(data) {

    const parsedData = data.map(x => JSON.parse(x));

    const table = content => `<table>\n${content}\n</table>`;
    const tableRow = content => `\t<tr>\n${content}\t</tr>\n`;
    const tableData = content => `\t\t<td>${content}</td>\n`;

    let output = parsedData.reduce((accRow, row) => {

        let tdForPeson = Object.values(row).reduce((tdAcc, td) => {
            return tdAcc + tableData(td);

        }, '');
     
        return accRow + tableRow(tdForPeson);
    },'');

    output = table(output);
    
    console.log(output);
}
table(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']);