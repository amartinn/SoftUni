import { fireBaseRequestFactory } from '../helpers/firebaseRequest.js';
import { mapArticles, sortArticles } from '../helpers/articleMapper.js';
export async function applyCommon() {
	this.username = sessionStorage.getItem('username');
	this.loggedIn = !!sessionStorage.getItem('token');

	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs')
	};

	const token = sessionStorage.getItem('token');
	if (token) {
		const jsArticles = await fireBaseRequestFactory('articles/javascript', token).getAll();
		const csharpArticles = await fireBaseRequestFactory('articles/csharp', token).getAll();
		const javaArticles = await fireBaseRequestFactory('articles/java', token).getAll();
		const pytonArticles = await fireBaseRequestFactory('articles/pyton', token).getAll();

		this.articles = {};
		this.articles.js = mapArticles(jsArticles).sort(sortArticles);

		this.articles.csharp = mapArticles(csharpArticles).sort(sortArticles);

		this.articles.java = mapArticles(javaArticles).sort(sortArticles);
		this.articles.pyton = mapArticles(pytonArticles).sort(sortArticles);
	}
}
