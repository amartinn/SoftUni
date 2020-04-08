export function sortArticles(a, b) {
	return a.title.localeCompare(b.title);
}
export function mapArticles(articles) {
	return Object.entries(articles || {}).map(([ articleId, article ]) => ({ ...article, articleId }));
}
