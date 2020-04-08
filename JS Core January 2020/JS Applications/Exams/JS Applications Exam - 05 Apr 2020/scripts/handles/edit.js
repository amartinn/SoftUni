import { applyCommon } from './common.js';
import { createFormEntity } from '../helpers/form-helper.js';
import { fireBaseRequestFactory } from '../helpers/firebaseRequest.js';
import { notificationHandler, notificationMessages } from './notification.js';

export async function editHandler() {
	await applyCommon.call(this);
	this.partials.editForm = await this.load('../../templates/crud/edit/editForm.hbs');
	await this.partial('../../templates/crud/edit/editPage.hbs');

	const id = this.params.id;
	const currentCategory = this.params.category;
	const currentUserEmail = sessionStorage.getItem('email');
	const token = sessionStorage.getItem('token');
	const articleToEdit = await fireBaseRequestFactory(`articles/${currentCategory}`, token).getById(id);

	if (currentUserEmail !== articleToEdit.creator) {
		this.redirect('#/home');
		return;
	}
	const formRef = document.querySelector('form');

	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'title', 'category', 'content' ]);
		let { title, category, content } = form.getValue();
		const availableCategories = [ 'csharp', 'java', 'js', 'javascript', 'pyton' ];
		if (!category) {
			await fireBaseRequestFactory(`articles/${currentCategory}`, token).patchEntity({ title, content }, id);
		} else {
			category = category === 'c#' ? 'csharp' : category.toLowerCase();
			category = category === 'js' ? 'javascript' : category;
			if (!availableCategories.find((x) => x.toLowerCase() === category)) {
				notificationHandler(notificationMessages.articles.error.category(category));
				return;
			}
			//deleting the entity from the current category;
			await fireBaseRequestFactory(`articles/${currentCategory}`, token).deleteEntity(id);
			// creating the new entity;
			const body = {
				category,
				creator: articleToEdit.creator,
				content,
				title
			};
			await fireBaseRequestFactory(`articles/${category}`, token).createEntity(body);
			notificationHandler(notificationMessages.articles.editted(title));
		}
		this.redirect([ '#/home' ]);
	});
}
