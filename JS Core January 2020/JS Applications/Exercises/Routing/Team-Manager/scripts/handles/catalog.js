import { applyCommon } from './common.js';
import { fireBaseRequestFactory } from '../helpers/firebaseRequest.js';
import { notificationHandler } from './notification.js';
export async function catalogHandler() {
	const token = sessionStorage.getItem('token');
	// in case a user is typing the url himself.
	if (!token) {
		this.redirect([ '#/register' ]);
		return;
	}
	const teams = await fireBaseRequestFactory('teams', token).getAll();
	this.teams = Object.entries(teams || {}).map(([ teamId, team ]) => ({ ...team, teamId }));

	await applyCommon.call(this);
	this.partials.team = await this.load('../../templates/catalog/team.hbs');
	await this.partial('../../templates/catalog/teamCatalog.hbs');
}
export async function catalogDetailsHandler() {
	this.teamId = this.params.id;
	const token = sessionStorage.getItem('token');
	if (!token) {
		this.redirect([ '#/register' ]);
		return;
	}
	let { name, comment, teamMembers, createdBy } = await fireBaseRequestFactory('teams', token).getById(
		this.params.id
	);
	this.name = name;
	this.comment = comment;
	this.members = teamMembers || [];
	this.isAuthor = createdBy === sessionStorage.getItem('userId');
	this.isOnTeam = (teamMembers || []).find((x) => x === sessionStorage.getItem('username'));
	await applyCommon.call(this);
	this.partials.teamMember = await this.load('../../templates/catalog/teamMember.hbs');
	this.partials.teamControls = await this.load('../../templates/catalog/teamControls.hbs');
	this.partial('../../templates/catalog/details.hbs');
}
