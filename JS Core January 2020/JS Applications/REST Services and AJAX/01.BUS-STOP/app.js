function getInfo() {
	var elements = {
		input: document.querySelector('#stopId'),
		stopName: document.querySelector('#stopName'),
		buses: document.querySelector('#buses')
	};
	const { input, stopName, buses } = elements;
	const inputValue = input.value;
	input.value = '';
	stopName.textContent = '';
	buses.innerHTML = '';
	doRequest(`https://judgetests.firebaseio.com/businfo/${inputValue}.json`);
}
function populate(response) {
	stopName.textContent = response.name;
	Object.entries(response.buses).forEach(([ busId, time ]) => {
		let li = document.createElement('li');
		li.textContent = `Bus ${busId} arrives in ${time} minutes`;
		buses.appendChild(li);
	});
}
function doRequest(url) {
	fetch(url).then((response) => response.json()).then(populate).catch(function() {
		stopName.textContent = 'Error';
	});
}
