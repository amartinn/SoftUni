import { fireBaseRequestFactory } from '../helpers/firebaseRequests.js';
import { applyCommon } from './common.js';
import { notificationHandler, notificationMessages } from './notification.js';
import { createFormEntity } from '../helpers/form-helper.js';
export async function registerHandler() {
	await applyCommon.call(this);
	await this.partial('../templates/register/register.hbs');
	const formRef = document.querySelector('form');
	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'email', 'password', 'rePassword' ]);
		const { email, password, rePassword } = form.getValue();
		if (email.length < 3 || !email) {
			form.clear();
			notificationHandler('error', notificationMessages.error.register.email);
			return;
		}
		if (password.length < 6 || !password) {
			form.clear();
			notificationHandler('error', notificationMessages.error.register.password);
			return;
		}
		if (password !== rePassword) {
			form.clear();
			notificationHandler('error', notificationMessages.error.register.passwordMatch);
			return;
		}
		try {
			const user = await firebase.auth().createUserWithEmailAndPassword(email, password);
			const token = await firebase.auth().currentUser.getIdToken();
			sessionStorage.setItem('email', email);
			sessionStorage.setItem('userId', firebase.auth().currentUser.uid);
			sessionStorage.setItem('token', token);
			form.clear();
			this.redirect([ '#/home' ]);

			notificationHandler('success', notificationMessages.successfull.register);
		} catch (e) {
			notificationHandler('error', e.message);
		}
	});
}
export async function logoutHandler() {
	sessionStorage.clear();
	await firebase.auth().signOut();
	notificationHandler('success', notificationMessages.successfull.logout);
	this.redirect([ '#/home' ]);
}
export async function loginHandler() {
	await applyCommon.call(this);
	await this.partial('../templates/login/login.hbs');

	const formRef = document.querySelector('form');
	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'email', 'password' ]);
		const { email, password } = form.getValue();

		if (!email || !password) {
			form.clear();
			notificationHandler('error', notificationMessages.error.login.both);
			return;
		}

		try {
			const loggedUser = await firebase.auth().signInWithEmailAndPassword(email, password);
			const token = await firebase.auth().currentUser.getIdToken();
			sessionStorage.setItem('email', loggedUser.user.email);
			sessionStorage.setItem('userId', firebase.auth().currentUser.uid);
			sessionStorage.setItem('token', token);
			notificationHandler('success', notificationMessages.successfull.login);
			this.redirect([ '#/home' ]);
			form.clear();
		} catch (e) {
			notificationHandler('error', notificationMessages.error.login.both);
			form.clear();
		}
	});
}
