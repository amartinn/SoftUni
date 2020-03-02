class Company {
	constructor() {
		this.departments = [];
	}
	addEmployee(username, salary, position, department) {
		if (!username || !salary || !position || !department) {
			throw new Error('Invalid input!');
		}
		if (salary < 0) {
			throw new Error(' Invalid input!');
		}
		let currentDepartment = this.departments.find((x) => x.department === department);

		if (currentDepartment) {
			currentDepartment.employees.push({ username, salary: +salary, position });
		} else {
			this.departments.push({ department, employees: [ { username, salary: +salary, position } ] });
		}
		return `New employee is hired. Name: ${username}. Position: ${position}`;
	}
	bestDepartment() {
		let output = '';
		let bestDepartment = this.findBestDepartment();
		output += `Best Department is: ${bestDepartment.name}\n`;
		output += `Average salary: ${bestDepartment.average.toFixed(2)}\n`;

		bestDepartment.employees
			.sort(function(a, b) {
				if (a.salary === b.salary) {
					return a.username.localeCompare(b.username);
				}
				return b.salary - a.salary;
			})
			.forEach((emp) => {
				output += `${emp.username} ${emp.salary} ${emp.position}\n`;
			});

		return output.trim();
	}
	findBestDepartment() {
		let temp = [];
		for (let department of this.departments) {
			let currentTotal = 0;
			for (let employee of department.employees) {
				currentTotal += employee.salary;
			}
			temp.push({
				name: department.department,
				average: currentTotal / department.employees.length,
				employees: department.employees
			});
		}
		return temp.sort((a, b) => a.average > b.average)[0];
	}
}
let c = new Company();
c.addEmployee('Stanimir', 2000, 'engineer', 'Human resources');
c.addEmployee('Pesho', 1500, 'electrical engineer', 'Construction');
c.addEmployee('Slavi', 500, 'dyer', 'Construction');
c.addEmployee('Stan', 2000, 'architect', 'Construction');
c.addEmployee('Stanimir', 1200, 'digital marketing manager', 'Marketing');
c.addEmployee('Pesho', 1000, 'graphical designer', 'Marketing');
c.addEmployee('Gosho', 1350, 'HR', 'Human resources');
console.log(c.bestDepartment());
