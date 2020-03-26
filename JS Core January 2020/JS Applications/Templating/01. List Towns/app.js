(() => {
	$('#btnLoadTowns').click(loadTowns);

	function loadTowns(e) {
		e.preventDefault;
		const towns = $('#towns').val().split(', ');
		$('ul').empty();
		$('#towns').val('');
		fetch('./town.hbs')
			.then((r) => r.text())
			.then((templateData) => {
				if (!towns[0]) {
					throw new Error('please enter a town');
				}
				const template = Handlebars.compile(templateData);
				const result = template({ towns });
				$('ul').append(result);
			})
			.catch((e) => {
				console.log('error');
				$('ul').append(`<p>${e.message}</p>`);
			});
	}
})();
