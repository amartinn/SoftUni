const URL = `https://phonebook-nakov.firebaseio.com/phonebook`;
function attachEvents() {
	const buttons = {
		load: document.querySelector('#btnLoad'),
		create: document.querySelector('#btnCreate')
	};
	buttons.load.addEventListener('click', loadData);
	buttons.create.addEventListener('click', createData);
}
async function createData() {
	const personName = document.querySelector('#person');
	const personPhone = document.querySelector('#phone');
	if (!personName.value || !personPhone.value) return;
	const obj = {
		person: personName.value,
		phone: personPhone.value
	};
	await fetch(URL + '.json', {
		method: 'POST',
		headers: {
			Accept: 'application/json',
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(obj)
	}).then(loadData);

	personName.value = null;
	personPhone.value = null;
}
async function loadData() {
	await fetch(URL + '.json').then((response) => response.json()).then(displayData);
}
async function deleteEntry(id) {
	let request = {
		method: 'DELETE'
	};
	await fetch(URL + `/${id}.json`, request).then(loadData);
}
function displayData(data) {
	const book = document.querySelector('#phonebook');
	book.innerHTML = null;
	for (let key in data) {
		const person = data[key]['person'];
		const phone = data[key]['phone'];
		const li = document.createElement('li');
		li.textContent = `${person}: ${phone}`;
		const button = document.createElement('button');
		button.textContent = 'Delete';
		book.append(li, button);
		button.addEventListener('click', function() {
			deleteEntry(key);
		});
	}
}

attachEvents();
