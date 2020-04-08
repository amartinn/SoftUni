import { applyCommon } from './common.js';
import { createFormEntity } from '../helpers/form-helper.js';
import { notificationHandler, notificationMessages } from './notification.js';
export async function registerHandler() {
	await applyCommon.call(this);
	this.partials.registerForm = await this.load('../../templates/auth/register/registerForm.hbs');
	await this.partial('../../templates/auth/register/registerPage.hbs');

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
			sessionStorage.setItem('userId', firebase.auth().currentUser.uid);
			sessionStorage.setItem('token', userToken);
			notificationHandler(notificationMessages.register.successfull);
			this.redirect([ '#/home' ]);
		} catch (e) {
			if (e.code === 'auth/weak-password') {
				form.clear([ 'password', 'repeatPassword' ]);
			} else {
				form.clear([ 'email' ]);
			}
			notificationHandler(e.message, 'error');
		}
	});
}
export async function loginHandler() {
	await applyCommon.call(this);
	this.partials.loginForm = await this.load('../../templates/auth/login/loginForm.hbs');
	await this.partial('../../templates/auth/login/loginPage.hbs');
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
			sessionStorage.setItem('email', loggedInUser.user.email);
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
	await firebase.auth().signOut();
	this.redirect([ '#/login' ]);
}
