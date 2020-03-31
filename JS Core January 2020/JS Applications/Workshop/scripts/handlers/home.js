import { fireBaseRequestFactory } from '../helpers/firebaseRequests.js';
import { applyCommon } from './common.js';

export async function homeHandler() {
	const token = sessionStorage.getItem('token');
	if (token) {
		const treks = await fireBaseRequestFactory('treks', token).getAll();
		const sortedTreks = Object.entries(treks || {})
			.map(([ trekId, trek ]) => ({ ...trek, trekId }))
			.sort((a, b) => b.likes - a.likes);
		this.treks = sortedTreks;
	}

	await applyCommon.call(this);
	token
		? (this.partials.logged = await this.load('../templates/home/loggedInView.hbs'))
		: (this.partials.notLogged = await this.load('../templates/home/notLoggedView.hbs'));

	this.partials.treks = await this.load('../templates/trek/listTreks.hbs');

	await this.partial('../templates/home/home.hbs');
}
