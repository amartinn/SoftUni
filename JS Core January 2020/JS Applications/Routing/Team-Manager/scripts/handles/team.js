import { applyCommon } from './common.js';
import { createFormEntity } from '../helpers/form-helper.js';
import { fireBaseRequestFactory } from '../helpers/firebaseRequest.js';
import { notificationHandler, notificationMessages } from './notification.js';

export async function createTeamHander() {
	await applyCommon.call(this);
	this.partials.createForm = await this.load('../../templates/create/createForm.hbs');
	await this.partial('../../templates/create/createPage.hbs');

	const formRef = document.querySelector('form');
	const username = sessionStorage.getItem('username');
	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'name', 'comment' ]);
		const { name, comment } = form.getValue();
		const body = {
			name,
			comment,
			createdBy: sessionStorage.getItem('userId'),
			teamMembers: [ username ]
		};
		const token = sessionStorage.getItem('token');
		const createdTeam = await fireBaseRequestFactory('teams', token).createEntity(body);
		notificationHandler(notificationMessages.team.created(name));
		this.redirect([ '#/catalog' ]);
	});
}
export async function editTeamHandler() {
	await applyCommon.call(this);

	this.partials.editForm = await this.load('../../templates/edit/editForm.hbs');
	await this.partial('../../templates/edit/editPage.hbs');

	const formRef = document.querySelector('form');
	const id = this.params.id;
	formRef.addEventListener('submit', async (e) => {
		e.preventDefault();
		const form = createFormEntity(formRef, [ 'name', 'comment' ]);
		const { name, comment } = form.getValue();
		const token = sessionStorage.getItem('token');
		const edittedTeam = await fireBaseRequestFactory('teams', token).patchEntity(
			{
				name,
				comment
			},
			id
		);
		notificationHandler(notificationMessages.team.editted(name));
		this.redirect([ '#/catalog' ]);
	});
}
export async function joinTeamHandler() {
	const id = this.params.id;
	const token = sessionStorage.getItem('token');
	const team = await fireBaseRequestFactory('teams', token).getById(id);
	const currentTeamMembers = team.teamMembers;
	let newMembers = [];
	const currentUserName = sessionStorage.getItem('username');
	if (this.hasTeam) {
		notificationHandler(notificationMessages.team.joined.error(team.name));
		return;
	} else if (currentTeamMembers) {
		// checks if the there is a team
		newMembers = [ ...Array.from(currentTeamMembers), currentUserName ];
	} else {
		newMembers = [ currentUserName ];
	}
	await fireBaseRequestFactory('teams', token).patchEntity(
		{
			teamMembers: [ ...newMembers ]
		},
		id
	);
	notificationHandler(notificationMessages.team.joined.sucess(team.name));
	this.redirect([ '#/catalog' ]);
}
export async function leaveTeamHandler() {
	const id = this.params.id;
	const token = sessionStorage.getItem('token');
	const team = await fireBaseRequestFactory('teams', token).getById(id);

	const newMembers = [ ...Array.from(team.teamMembers) ];

	const index = newMembers.indexOf(sessionStorage.getItem('username'));
	delete newMembers[index];
	await fireBaseRequestFactory('teams', token).patchEntity(
		{
			// because im using delete, im filtering because the
			// array at [index] is empty
			teamMembers: newMembers.filter((x) => x !== '')
		},
		id
	);
	notificationHandler(notificationMessages.team.leaved(team.name));
	this.redirect([ '#/catalog' ]);
}
