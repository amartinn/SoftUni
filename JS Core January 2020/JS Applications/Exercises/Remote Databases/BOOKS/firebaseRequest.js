export const apiKey = `https://bookstore-a2f9f.firebaseio.com/`;
export const listAllBooks = () => {
	return fetch(apiKey + 'books.json');
};
export const createBook = (book) => {
	return fetch(apiKey + 'books.json', {
		method: 'POST',
		body: JSON.stringify(book)
	});
};
export const updateBook = (id, newBook) => {
	return fetch(apiKey + 'books/' + id + '.json', {
		method: 'PUT',
		body: JSON.stringify(newBook)
	});
};
export const deleteBook = (id) => {
	return fetch(apiKey + 'books/' + id + '.json', {
		method: 'DELETE'
	});
};
export const getBook = (id) => {
	return fetch(apiKey + 'books/' + id + '.json');
};
