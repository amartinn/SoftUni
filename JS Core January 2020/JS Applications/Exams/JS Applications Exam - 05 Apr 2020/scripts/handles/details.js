import { applyCommon } from './common.js';
import { fireBaseRequestFactory } from '../helpers/firebaseRequest.js';
import { notificationHandler } from './notification.js';

export async function detailsHandler() {
	this.articleId = this.params.id;
	const category = this.params.category;
	const token = sessionStorage.getItem('token');
	// incase a user types the url himself
	if (!token) {
		this.redirect([ '#/home' ]);
		return;
	}

	let { content, title, creator } = await fireBaseRequestFactory(`articles/${category}`, token).getById(
		this.params.id
	);
	this.content = content;

	this.title = title;
	this.category = category;

	this.isAuthor = creator === sessionStorage.getItem('email');
	await applyCommon.call(this);
	this.partial('../../templates/articles/details.hbs');
}
