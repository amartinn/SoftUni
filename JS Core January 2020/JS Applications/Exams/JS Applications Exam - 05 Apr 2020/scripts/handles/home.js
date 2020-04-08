import { applyCommon } from './common.js';
import { fireBaseRequestFactory } from '../helpers/firebaseRequest.js';

export async function homeHandler() {
	const token = sessionStorage.getItem('token');
	if (!token) {
		this.redirect('#/login');
		return;
	}
	await applyCommon.call(this);
	this.partials.missingArticle = await this.load('../../templates/articles/noArticles.hbs');
	this.partials.article = await this.load('../../templates/articles/article.hbs');

	await this.partial('../../templates/home/home.hbs');
}
