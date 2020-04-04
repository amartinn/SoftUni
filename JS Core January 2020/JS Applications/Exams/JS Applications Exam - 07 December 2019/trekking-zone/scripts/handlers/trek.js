import { fireBaseRequestFactory } from '../helpers/firebaseRequests.js';
import { applyCommon } from './common.js';
import { notificationHandler, notificationMessages } from './notification.js';
import { createFormEntity } from '../helpers/form-helper.js';
export async function likeTrekHandler() {
	const id = this.params.id;
	const token = sessionStorage.getItem('token');
	const { likes, organizer } = await fireBaseRequestFactory('treks', token).getById(id);
	if (organizer === sessionStorage.getItem('email')) {
		this.redirect[`#/details/${id}`];
		return;
	}
	await fireBaseRequestFactory('treks', token).patchEntity({ likes: likes + 1 }, id);
	notificationHandler('success', notificationMessages.successfull.like);
	this.redirect([ `#/details/${id}` ]);
}
export async function deleteTrekHandler() {
	const id = this.params.id;
	const token = sessionStorage.getItem('token');
	await fireBaseRequestFactory('treks', token).deleteEntity(id);
	notificationHandler('success', notificationMessages.successfull.delete);
	this.redirect([ '#/home' ]);
}
export async function editTrekHandler() {
	const token = sessionStorage.getItem('token');
	const id = this.params.id;
	const trek = await fireBaseRequestFactory('treks', token).getById(id);
	if (trek.organizer !== sessionStorage.getItem('email')) {
		this.redirect([ '#/home' ]);
	}
	await applyCommon.call(this);
	await this.partial('../templates/edit/edit.hbs');

	const formRef = document.querySelector('form');
	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'location', 'dateTime', 'description', 'imageURL' ]);

		const body = form.getValue();
		await fireBaseRequestFactory('treks', token).patchEntity(body, id);
		notificationHandler('success', notificationMessages.successfull.edit);
		this.redirect([ '#/home' ]);
	});
}
export async function detailsTrekHandler() {
	await applyCommon.call(this);
	const id = this.params.id;
	const token = sessionStorage.getItem('token');
	const trek = await fireBaseRequestFactory('treks', token).getById(id);
	this.description = trek.description;
	this.date = trek.date;
	this.likes = trek.likes;
	this.organizer = trek.organizer;
	this.imageURL = trek.imageURL;

	this.notOrganizer = trek.organizer !== sessionStorage.getItem('email');
	await this.partial('../templates/trek/details.hbs');
}
export async function createTrekHandler() {
	await applyCommon.call(this);

	await this.partial('../templates/create/create.hbs');

	const formRef = document.querySelector('form');

	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'location', 'dateTime', 'description', 'imageURL' ]);
		const { location, dateTime, description, imageURL } = form.getValue();
		console.log(form.getValue());
		if (location.length < 6 || description.length < 10) {
			form.clear();
			notificationHandler('error', notificationMessages.error.invalid.input);
			return;
		}
		const token = sessionStorage.getItem('token');

		fireBaseRequestFactory('treks', token).createEntity({
			organizer: sessionStorage.getItem('email'),
			likes: 0,
			location,
			dateTime,
			description,
			imageURL
		});
		notificationHandler('success', notificationMessages.successfull.createdTrek);
		form.clear();
		this.redirect([ '#/home' ]);
	});
}
