import { applyCommon } from './common.js';
import { createFormEntity } from '../helpers/form-helper.js';
import { notificationHandler, notificationMessages } from './notification.js';
export async function registerHandler() {
	await applyCommon.call(this);
	this.partials.registerForm = await this.load('../../templates/register/registerForm.hbs');
	await this.partial('../../templates/register/registerPage.hbs');

	const userId = sessionStorage.getItem('userId');
	if (userId) {
		this.redirect('#/home');
		return;
	}
	const formRef = document.querySelector('form');
	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'email', 'password', 'repeatPassword' ]);
		const { email, password, repeatPassword } = form.getValue();
		if (!email) {
			notificationHandler(notificationMessages.register.invalidEmail, 'error');
			form.clear([ 'email' ]);
			return;
		}
		if (password !== repeatPassword) {
			notificationHandler(notificationMessages.register.passwordMatch, 'error');
			form.clear([ 'password', 'repeatPassword' ]);
			return;
		}
		try {
			const newUser = await firebase.auth().createUserWithEmailAndPassword(email, password);
			let userToken = await firebase.auth().currentUser.getIdToken();
			sessionStorage.setItem('email', email);
			sessionStorage.setItem('username', email);
			sessionStorage.setItem('userId', firebase.auth().currentUser.uid);
			sessionStorage.setItem('token', userToken);
			notificationHandler(notificationMessages.register.successfull);
			this.redirect([ '#/home' ]);
		} catch (e) {
			notificationHandler(e.message, 'error');
			form.clear([ 'email' ]);
		}
	});
}
export async function loginHandler() {
	await applyCommon.call(this);
	this.partials.loginForm = await this.load('../../templates/login/loginForm.hbs');
	await this.partial('../../templates/login/loginPage.hbs');
	const userId = sessionStorage.getItem('userId');
	if (userId) {
		this.redirect('#/home');
		return;
	}

	const formRef = document.querySelector('form');
	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'email', 'password' ]);
		const { email, password } = form.getValue();
		try {
			const loggedInUser = await firebase.auth().signInWithEmailAndPassword(email, password);
			const userToken = await firebase.auth().currentUser.getIdToken();
			sessionStorage.setItem('username', loggedInUser.user.email);
			sessionStorage.setItem('userId', firebase.auth().currentUser.uid);
			sessionStorage.setItem('token', userToken);
			notificationHandler(notificationMessages.login.successfull);
			this.redirect([ '#/home' ]);
		} catch (e) {
			notificationHandler(notificationMessages.login.unsuccessfull, 'error');
		}
	});
}
export async function logoutHandler() {
	notificationHandler(notificationMessages.logout.successfull);
	sessionStorage.clear();
	firebase.auth().signOut();
	this.redirect([ '#/home' ]);
}
