import { applyCommon } from './common.js';
import { createFormEntity } from '../helpers/form-helper.js';
import { fireBaseRequestFactory } from '../helpers/firebaseRequest.js';
import { notificationHandler, notificationMessages } from './notification.js';
export async function createHander() {
	const token = sessionStorage.getItem('token');
	if (!token) {
		this.redirect('#/home');
		return;
	}
	await applyCommon.call(this);
	this.partials.createForm = await this.load('../../templates/crud/create/createForm.hbs');
	await this.partial('../../templates/crud/create/createPage.hbs');

	const availableCategories = [ 'csharp', 'java', 'js', 'javascript', 'pyton' ];
	const formRef = document.querySelector('form');
	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'title', 'category', 'content' ]);
		let { title, category, content } = form.getValue();
		const creator = sessionStorage.getItem('email');

		category = category === 'c#' ? 'csharp' : category.toLowerCase();
		category = category === 'js' ? 'javascript' : category;
		if (!availableCategories.find((x) => x.toLowerCase() === category)) {
			notificationHandler(notificationMessages.articles.error.category(category), 'error');
			form.clear([ 'category' ]);
			return;
		}
		const body = { title, content, creator, category };

		const createdEntity = await fireBaseRequestFactory(`articles/${category}`, token).createEntity(body);
		notificationHandler(notificationMessages.articles.created(title));

		this.redirect([ '#/home' ]);
	});
}
