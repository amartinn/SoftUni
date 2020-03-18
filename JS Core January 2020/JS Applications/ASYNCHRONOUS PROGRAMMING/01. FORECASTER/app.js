(() => {
	const BASE_URL = `https://judgetests.firebaseio.com/locations.json`;
	const WEATHER_URL = (url) => `https://judgetests.firebaseio.com/forecast/${url}.json`;

	const elements = {
		submitBtn: document.querySelector('#submit'),
		input: document.querySelector('#location'),
		today: document.querySelector('#current'),
		upcoming: document.querySelector('#upcoming'),
		forecastDiv: document.querySelector('#forecast'),
		requestDiv: document.querySelector('#request')
	};
	const conditions = {
		s: '☀️',
		p: '⛅',
		o: '☁️',
		r: '☂️',
		d: '°'
	};
	let hasError = false;
	elements.submitBtn.addEventListener('click', getData);
	const jsonMiddeware = (response) => response.json();
	const errorHandler = (e) => {
		elements.forecastDiv.style.display = 'none';
		const errorH1 = createHTMLelement('h1', 'error', 'ERROR OCCURRED!');
		if (!hasError) elements.requestDiv.append(errorH1);

		hasError = true;
		elements.input.value = '';
	};
	function getData() {
		const location = elements.input.value;
		fetch(BASE_URL)
			.then(jsonMiddeware)
			.then((data) => {
				const { code, name } = data.find((o) => o.name.toLowerCase() === location.toLowerCase());
				fetchConditions(code);
			})
			.catch(errorHandler);
	}

	function fetchConditions(code) {
		reset();
		Promise.all([
			fetch(WEATHER_URL(`today/${code}`)).then(jsonMiddeware),
			fetch(WEATHER_URL(`upcoming/${code}`)).then(jsonMiddeware)
		]).then(([ today, upcoming ]) => {
			elements.forecastDiv.style.display = 'block';
			createCurrentElements(today);
			createUpcomingElements(upcoming);
		});
	}
	function reset() {
		const { upcoming, today, input, requestDiv } = elements;
		upcoming.removeChild(upcoming.lastChild);
		today.removeChild(today.lastChild);
		input.value = '';
		if (hasError) {
			hasError = false;
			requestDiv.removeChild(requestDiv.lastChild);
		}
	}
	function createUpcomingElements(data) {
		const infoDiv = createHTMLelement('div', 'forecast-info');
		for (let forecast of data.forecast) {
			const currentCondition = forecast.condition;
			const upcomingSpan = createHTMLelement('span', 'upcoming');
			const symbolSpan = createHTMLelement('span', 'condition', conditions[currentCondition[0].toLowerCase()]);
			const degrees = `${forecast.low}${conditions.d}/${forecast.high}${conditions.d}`;
			const degreeSpan = createHTMLelement('span', 'forecast-data', degrees);
			const currentConditionSpan = createHTMLelement('span', 'forecast-data', forecast.condition);

			upcomingSpan.append(symbolSpan, degreeSpan, currentConditionSpan);
			infoDiv.appendChild(upcomingSpan);
		}
		elements.upcoming.appendChild(infoDiv);
	}
	function createCurrentElements(data) {
		const currentCondition = data.forecast.condition;
		const forecastsDiv = createHTMLelement('div', 'forecasts');
		const symbolSpan = createHTMLelement('span', 'condition', conditions[currentCondition[0].toLowerCase()]);
		symbolSpan.classList.add('symbol');
		const conditionSpan = createHTMLelement('span', 'condition');
		const citySpan = createHTMLelement('span', 'forecast-data', data.name);
		const degrees = `${data.forecast.low}${conditions.d}/${data.forecast.high}${conditions.d}`;
		const degreeSpan = createHTMLelement('span', 'forecast-data', degrees);
		const currentConditionSpan = createHTMLelement('span', 'forecast-data', data.forecast.condition);
		conditionSpan.append(citySpan, degreeSpan, currentConditionSpan);
		forecastsDiv.append(symbolSpan, conditionSpan);
		elements.today.appendChild(forecastsDiv);
	}
	function createHTMLelement(tag, className, textContent) {
		const element = document.createElement(tag);
		if (className) element.classList.add(className);

		if (textContent) element.textContent = textContent;

		return element;
	}
})();
