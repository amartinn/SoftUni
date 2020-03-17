let stopId = 'depot';
let stopName = 'depot';
function solve() {
	const elements = {
		departBtn: document.querySelector('#depart'),
		arriveBtn: document.querySelector('#arrive')
	};
	const { departBtn, arriveBtn } = elements;
	function depart() {
		fetch(`https://judgetests.firebaseio.com/schedule/${stopId}.json`)
			.then((res) => res.json())
			.then((res) => {
				const { name, next } = res;
				stopId = next;
				stopName = name;
			})
			.then(() => {
				updateDepartInfo(stopName);
			});
		departBtn.disabled = !departBtn.disabled;
		arriveBtn.disabled = !arriveBtn.disabled;
	}

	function arrive() {
		updateArriveInfo(stopName);
		departBtn.disabled = !departBtn.disabled;
		arriveBtn.disabled = !arriveBtn.disabled;
	}

	return {
		depart,
		arrive
	};
}

let result = solve();
function updateDepartInfo(name) {
	let info = document.querySelector('.info');
	info.textContent = `Next stop ${name}`;
}
function updateArriveInfo(name) {
	let info = document.querySelector('.info');
	info.textContent = `Arriving at ${name}`;
}
