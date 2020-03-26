import { listAll } from './firebaseRequest.js';

(async () => {
	const students = await listAll();
	const entries = [];
	for (let student of Object.entries(students)) {
		const { id, firstName, lastName, facultyNumber, grade } = student[1];
		if (!id || !firstName || !lastName || !facultyNumber || !grade) continue;
		entries.push({ id, firstName, lastName, facultyNumber, grade });
	}
	const html = (id, fName, lName, facultyNumber, grade) => {
		return `<tr>\n
		 <td>${id}</td>\n
	 	<td>${fName}</td>\n
	 	<td>${lName}</td>\n
	 	<td>${facultyNumber}</td>\n
	 	<td>${grade}</td>\n
		 </tr>`;
	};
	const tbody = document.querySelector('tbody');
	entries
		.sort(function(a, b) {
			return a.id - b.id;
		})
		.forEach((student) => {
			const { id, firstName, lastName, facultyNumber, grade } = student;
			const tableHTML = html(id, firstName, lastName, facultyNumber, grade);
			tbody.innerHTML += tableHTML;
		});
})();
