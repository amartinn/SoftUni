import { monkeys } from './monkeys.js';
(() => {
	fetch('./monkeyTemplate.hbs').then((r) => r.text()).then((monkeyTemplate) => {
		const template = Handlebars.compile(monkeyTemplate);
		const result = template({ monkeys });
		$('.monkeys').append(result);
		$('button').each(function() {
			$(this).click(showInfo);
		});
	});
	function showInfo() {
		if ($(this).text().startsWith('Show')) {
			$(this).siblings('p').css('display', 'block');
			$(this).text('Hide Info');
		} else {
			const p = $(this).parent().children()[3];
			$(this).siblings('p').css('display', 'none');
			$(this).text('Show Info');
		}
	}
})();
