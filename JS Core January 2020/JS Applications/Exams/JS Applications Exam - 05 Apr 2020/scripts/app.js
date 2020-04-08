import {
	homeHandler,
	registerHandler,
	logoutHandler,
	loginHandler,
	detailsHandler,
	editHandler,
	createHander,
	deleteHandler
} from './handles/index.js';

import { firebaseConfig } from '../firebaseConfig.js';

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

	this.get('#/create', createHander);
	this.post('#/create', () => false);

	this.get('#/articles/:category/edit/:id', editHandler);
	this.post('#/articles/:category/edit/:id', () => false);

	this.get('#/articles/:category/details/:id', detailsHandler);
	this.post('#/articles/:category/details/:id', () => false);

	this.get('#/articles/:category/delete/:id', deleteHandler);
	this.post('#/articles/:category/delete/:id', () => false);
});

$(function() {
	firebase.initializeApp(firebaseConfig);
	app.run('#/');
});
