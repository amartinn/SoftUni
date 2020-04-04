function solve() {
	const backgroundColor = 'rgb(65, 63, 94)';

	const $elements = {
		table: document.querySelector('.minimalistBlack'),
		tableRows: Array.from(document.querySelectorAll('.minimalistBlack tbody tr'))
	};
	for (tr of $elements.tableRows) {
		tr.addEventListener('click', changeColor);
	}

	function changeColor() {
		let lastClicked = $elements.tableRows.find((x) => x.style.backgroundColor === backgroundColor);
		if (lastClicked) {
			if (lastClicked === this) {
				this.removeAttribute('style');
			} else {
				lastClicked.removeAttribute('style');
				this.style.backgroundColor = backgroundColor;
			}
		} else {
			this.style.backgroundColor = backgroundColor;
		}
	}
}
