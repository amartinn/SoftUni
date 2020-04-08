import { applyCommon } from './common.js';
import { fireBaseRequestFactory } from '../helpers/firebaseRequest.js';
import { notificationHandler, notificationMessages } from './notification.js';
export async function deleteHandler() {
	await applyCommon.call(this);
	const id = this.params.id;
	const category = this.params.category;
	const token = sessionStorage.getItem('token');
	if (!token) {
		this.redirect('#/home');
		return;
	}
	await fireBaseRequestFactory(`articles/${category}`, token).deleteEntity(id);
	notificationHandler(notificationMessages.articles.deleted);
	this.redirect('#/home');
}
