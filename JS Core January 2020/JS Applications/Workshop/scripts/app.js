import {
	homeHandler,
	registerHandler,
	logoutHandler,
	loginHandler,
	createTrekHandler,
	editTrekHandler,
	detailsTrekHandler,
	deleteTrekHandler,
	likeTrekHandler,
	showUserHandler
} from './handlers/index.js';
import { firebaseConfig } from '../firebaseSettings.js';

firebase.initializeApp(firebaseConfig);

var app = Sammy('#main', function() {
	this.use('Handlebars', 'hbs');
	this.get('#/', homeHandler);
	this.get('#/home', homeHandler);

	this.get('#/register', registerHandler);
	this.post('#/register', () => false);

	this.get('#/logout', logoutHandler);
	this.post('#/logout', () => false);

	this.get('#/login', loginHandler);
	this.post('#/login', () => false);

	this.get('#/create', createTrekHandler);
	this.post('#/create', () => false);

	this.get('#/edit/:id', editTrekHandler);
	this.post('#/edit/:id', () => false);

	this.get('#/details/:id', detailsTrekHandler);
	this.post('#/details/:id', () => false);

	this.get('#/delete/:id', deleteTrekHandler);
	this.post('#/delete/:id', () => false);

	this.get('#/likes/:id', likeTrekHandler);
	this.post('#/likes/:id', () => false);

	this.get('#/users/:id', showUserHandler);
	this.post('#/users/:id', () => false);
});
app.run('#/');
