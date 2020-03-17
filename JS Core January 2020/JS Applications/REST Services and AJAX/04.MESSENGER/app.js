const URL = 'https://rest-messanger.firebaseio.com/messanger.json';
function attachEvents() {
	const buttons = {
		send: document.querySelector('#submit'),
		refresh: document.querySelector('#refresh')
	};
	buttons.send.addEventListener('click', sendData);
	buttons.refresh.addEventListener('click', refresh);
}
function sendData() {
	const author = document.querySelector('#author');
	const content = document.querySelector('#content');
	if (!author.value || !content.value) return;
	let obj = {
		author: author.value,
		content: content.value
	};
	fetch(URL, {
		method: 'POST',
		headers: {
			Accept: 'application/json',
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(obj)
	}).then(refresh);
	author.value = '';
	content.value = '';
}
function refresh() {
	const textarea = document.querySelector('#messages');
	textarea.innerHTML = '';
	fetch(URL, {
		method: 'GET'
	})
		.then((resp) => resp.json())
		.then((resp) => Object.entries(resp))
		.then(function(responses) {
			Object.values(responses).forEach(([ id, data ]) => {
				const { author, content } = data;

				if (!author || !content) return;
				// ако базата е пълна със дата която не съответства не се
				// визуализира
				textarea.textContent += `${author}: ${content}\n`;
			});
		});
}

attachEvents();
