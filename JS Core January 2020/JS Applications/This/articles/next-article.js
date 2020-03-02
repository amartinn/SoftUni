function getArticleGenerator(articles) {
	var current = 0;
	return function() {
		if (current === articles.length) {
			return;
		}
		let article = document.createElement('article');
		article.textContent = articles[current];
		document.querySelector('#content').appendChild(article);
		current++;
	};
}
