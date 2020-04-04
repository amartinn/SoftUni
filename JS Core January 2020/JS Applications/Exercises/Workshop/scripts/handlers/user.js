import { fireBaseRequestFactory } from '../helpers/firebaseRequests.js';
import { applyCommon } from './common.js';
export async function showUserHandler() {
	await applyCommon.call(this);
	const id = sessionStorage.getItem('userId');
	const loggedUser = sessionStorage.getItem('email');
	const token = sessionStorage.getItem('token');
	const treks = await fireBaseRequestFactory('treks', token).getAll();
	this.wishedTreks = Object.entries(treks).filter((x) => x[1].organizer === loggedUser).map((x) => x[1].location);
	this.treksCount = this.wishedTreks.length;
	this.hasTreks = this.treksCount > 0;
	await this.partial('../templates/user.hbs');
}
