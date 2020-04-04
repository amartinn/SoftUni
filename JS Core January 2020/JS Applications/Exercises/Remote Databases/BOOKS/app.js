import { listAllBooks, updateBook, deleteBook, createBook, getBook } from './firebaseRequest.js';
(() => {
	const elements = {
		form: document.querySelector('form'),
		createBtn: document.querySelector('.createBook'),
		loadBtn: document.querySelector('#loadBooks'),
		tbody: document.querySelector('tbody'),
		editBtn: document.querySelector('.editBook')
	};

	elements.createBtn.addEventListener('click', addBook);
	elements.loadBtn.addEventListener('click', listBooks);
	elements.editBtn.addEventListener('click', submitNewBook);
	function addBook(e) {
		e.preventDefault();
		const [ title, author, isbn ] = Array.from(elements.form.querySelectorAll('input')).map((x) => x.value);
		createBook({ author, isbn, title });
		listAllBooks();
		reset();
	}
	async function listBooks() {
		elements.tbody.innerHTML = '';
		const books = await listAllBooks().then((r) => r.json()).catch(errorHandler);
		if (!books) return;
		for (let [ id, { author, isbn, title } ] of Object.entries(books)) {
			let tr = createHTMLElement('tr');
			tr.dataset.id = id;
			let titleTd = createHTMLElement('td', 'title', title);
			let authorTd = createHTMLElement('td', 'author', author);
			let isBnTd = createHTMLElement('td', 'isbn', isbn);

			let buttonsTd = createHTMLElement('td');
			let editBtn = createHTMLElement('button', 'edit', 'Edit');
			editBtn.addEventListener('click', function() {
				editBook(id);
			});
			let deleteBtn = createHTMLElement('button', 'delete', 'Delete');
			deleteBtn.addEventListener('click', function() {
				deletebook(id);
			});
			buttonsTd.append(editBtn, deleteBtn);
			tr.append(titleTd, authorTd, isBnTd, buttonsTd);
			elements.tbody.append(tr);
		}
	}
	async function editBook(id) {
		elements.createBtn.style.display = 'none';
		elements.editBtn.style.display = 'block';
		const { author, isbn, title } = await getBook(id).then((r) => r.json()).catch(errorHandler);
		const [ titleEl, authorEl, isbnEl ] = elements.form.querySelectorAll('input');
		authorEl.value = author;
		isbnEl.value = isbn;
		titleEl.value = title;
		elements.form.dataset.id = id;
	}
	async function submitNewBook(e) {
		e.preventDefault();
		console.log(true);
		const bookId = elements.form.dataset.id;
		elements.form.dataset.id = '';
		const [ title, author, isbn ] = Array.from(elements.form.querySelectorAll('input')).map((x) => x.value);
		const book = {
			author,
			isbn,
			title
		};
		await updateBook(bookId, book).catch(errorHandler);
		reset();
		listBooks();
		elements.createBtn.style.display = 'block';
		elements.editBtn.style.display = 'none  ';
	}
	async function deletebook(id) {
		await deleteBook(id).catch(errorHandler);
		listBooks();
	}
	function errorHandler(e) {
		console.log(e.message);
	}
	function createHTMLElement(tag, className, textContent) {
		const element = document.createElement(tag);
		if (className) element.classList.add(className);
		if (textContent) element.textContent = textContent;
		return element;
	}
	function reset() {
		Array.from(elements.form.querySelectorAll('input')).forEach((el) => {
			el.value = '';
		});
	}
})();
