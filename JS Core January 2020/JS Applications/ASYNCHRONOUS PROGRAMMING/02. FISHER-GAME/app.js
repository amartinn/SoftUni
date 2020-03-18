const BASE_URL = `https://fisher-game.firebaseio.com/catches.json`;
const URL = (id) => `https://fisher-game.firebaseio.com/catches/${id}.json`;
(() => {
	const elements = {
		loadBtn: document.querySelector('.load'),
		addBtn: document.querySelector('.add'),
		addForm: document.querySelector('#addForm'),
		catches: document.querySelector('#catches')
	};
	elements.loadBtn.addEventListener('click', loadData);
	function getValue(className) {
		return elements.addForm.querySelector(className).value;
	}

	elements.addBtn.addEventListener('click', addEntry);

	const jsonMiddleware = (request) => request.json();
	const errorHandler = (e) => console.error(e.message);
	loadData();
	function addEntry() {
		let data = {
			angler: getValue('.angler'),
			weight: +getValue('.weight'),
			species: getValue('.species'),
			location: getValue('.location'),
			bait: getValue('.bait'),
			captureTime: +getValue('.captureTime')
		};
		reset();
		if (Object.values(data).some((x) => x === undefined || x === '')) return;
		fetch(BASE_URL, {
			method: 'POST',
			body: JSON.stringify(data)
		})
			.then(jsonMiddleware)
			.then(loadData)
			.catch(errorHandler);
	}
	function loadData() {
		elements.catches.innerHTML = '';
		fetch(BASE_URL).then(jsonMiddleware).then(parseData).catch(errorHandler);
	}
	function reset() {
		Array.from(elements.addForm.querySelectorAll('input')).forEach((element) => {
			element.value = '';
		});
	}
	function parseData(object) {
		for (let entry of Object.entries(object)) {
			let div = createAnglerDiv(entry);
			if (!div) continue;
			elements.catches.append(div);
		}
	}
	function createAnglerDiv([ id, { angler, bait, captureTime, location, species, weight } ]) {
		if (!angler || !bait || !captureTime || !location || !species || !weight) return;

		const catchDiv = createHTMLElement('div', 'catch', null, null, [ { key: 'data-id', value: id } ]);

		const anglerLabel = createHTMLElement('label', null, 'Angler');
		const anglerInput = createHTMLElement('input', 'angler', null, null, [
			{ key: 'type', value: 'text' },
			{ key: 'value', value: angler }
		]);
		const weightLabel = createHTMLElement('label', null, 'Weight');
		const weightInput = createHTMLElement('input', 'weight', null, null, [
			{ key: 'type', value: 'number' },
			{ key: 'value', value: weight }
		]);

		const speciesLabel = createHTMLElement('label', null, 'Species');
		const speciesInput = createHTMLElement('input', 'species', null, null, [
			{ key: 'type', value: 'text' },
			{ key: 'value', value: species }
		]);

		const locationLabel = createHTMLElement('label', null, 'Location');
		const locationInput = createHTMLElement('input', 'location', null, null, [
			{ key: 'type', value: 'text' },
			{ key: 'value', value: location }
		]);

		const baitLabel = createHTMLElement('label', null, 'Bait');
		const baitInput = createHTMLElement('input', 'bait', null, null, [
			{ key: 'type', value: 'text' },
			{ key: 'value', value: bait }
		]);

		const captureLabel = createHTMLElement('label', null, 'Capture Time');
		const captureInput = createHTMLElement('input', 'captureTime', null, null, [
			{ key: 'type', value: 'number' },
			{ key: 'value', value: captureTime }
		]);
		let elements = [
			anglerLabel,
			anglerInput,
			weightLabel,
			weightInput,
			speciesLabel,
			speciesInput,
			locationLabel,
			locationInput,
			baitLabel,
			baitInput,
			captureLabel,
			captureInput
		];

		for (let i = 0; i < elements.length - 1; i += 2) {
			let label = elements[i];
			let input = elements[i + 1];
			let hrElement = createHTMLElement('hr');
			catchDiv.append(label, input, hrElement);
		}
		const updateBtn = createHTMLElement('button', 'update', 'Update');
		updateBtn.addEventListener('click', function() {
			updateEntry(id);
		});
		const deleteBtn = createHTMLElement('button', 'delete', 'Delete');
		deleteBtn.addEventListener('click', function() {
			deleteEntry(id);
		});
		catchDiv.append(updateBtn, deleteBtn);
		return catchDiv;
	}
	function updateEntry(id) {
		let catchDivs = elements.catches.querySelectorAll('.catch');
		let currentDiv = Array.from(catchDivs).find((x) => x.dataset.id === id);

		let inputs = currentDiv.querySelectorAll('input');
		let obj = {
			angler: inputs[0].value,
			weight: inputs[1].value,
			species: inputs[2].value,
			location: inputs[3].value,
			bait: inputs[4].value,
			captureTime: inputs[5].value
		};
		fetch(URL(id), {
			method: 'PUT',
			body: JSON.stringify(obj)
		})
			.then(loadData)
			.catch(errorHandler);
	}
	function deleteEntry(id) {
		fetch(URL(id), {
			method: 'DELETE'
		});
		loadData();
	}
	function createHTMLElement(tag, className, textContent, value, attributes) {
		const element = document.createElement(tag);
		if (className) element.classList.add(className);
		if (textContent) element.textContent = textContent;

		if (value) element.value = value;
		if (attributes) {
			for (let { key, value } of attributes) {
				element.setAttribute(key, value);
			}
		}

		return element;
	}
})();
