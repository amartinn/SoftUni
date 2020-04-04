(() => {
	fetch('./catTemplate.hbs').then((r) => r.text()).then((catTemplate) => {
		const template = Handlebars.compile(catTemplate);
		const result = template({ cats });
		$('ul').append(result);
		$('.showBtn').each(function() {
			$(this).click(showContent);
		});
	});

	function showContent() {
		if ($(this).text().startsWith('Show')) {
			$(this).siblings('.status').css('display', 'block');
			$(this).text('Hide status code');
		} else {
			$(this).siblings('.status').css('display', 'none');
			$(this).text('Show status code');
		}
	}
})();
