import {
	homeHandler,
	registerHandler,
	logoutHandler,
	loginHandler,
	catalogHandler,
	catalogDetailsHandler,
	aboutHandler,
	createTeamHander,
	editTeamHandler,
	joinTeamHandler,
	leaveTeamHandler
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

	this.get('#/about', aboutHandler);
	this.post('#/about', () => false);

	this.get('#/catalog', catalogHandler);
	this.post('#/catalog', () => false);

	this.get('#/catalog/details/:id', catalogDetailsHandler);
	this.post('#/catalog/details/:id', () => false);

	this.get('#/create', createTeamHander);
	this.post('#/create', () => false);

	this.get('#/edit/:id', editTeamHandler);
	this.post('#/edit/:id', () => false);

	this.get('#/join/:id', joinTeamHandler);
	this.post('#/join/:id', () => false);

	this.get('#/leave/:id', leaveTeamHandler);
	this.post('#/leave/:id', () => false);
});

firebase.initializeApp(firebaseConfig);

app.run('#/');
