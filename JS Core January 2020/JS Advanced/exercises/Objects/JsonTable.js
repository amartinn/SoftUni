function table(input){
console.log(`<table>`);
    // <tr>
	// 	<td>Pesho</td>
	// 	<td>Promenliva</td>
	// 	<td>100000</td>
    // </tr>
    let data = [];
input.forEach(element => {
    console.log(`\t<tr>`);
    let json = JSON.parse(element);
    let name = json.name;
    let position = json.position;
    let salary = json.salary;
    console.log(`\t\t<td>${name}</td>`);
    console.log(`\t\t<td>${position}</td>`);
    console.log(`\t\t<td>${salary}</td>`);
    console.log(`\t</tr>`);
});
console.log(`</table>`);
}