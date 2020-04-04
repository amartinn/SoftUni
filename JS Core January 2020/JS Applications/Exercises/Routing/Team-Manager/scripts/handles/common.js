import { fireBaseRequestFactory } from '../helpers/firebaseRequest.js';
export async function applyCommon() {
	this.username = sessionStorage.getItem('username');
	this.loggedIn = !!sessionStorage.getItem('token');
	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs')
	};
	const userId = sessionStorage.getItem('userId');
	const token = sessionStorage.getItem('token');
	if (userId) {
		this.hasTeam = await fireBaseRequestFactory('teams', token).getAll().then((data) => {
			if (!data) {
				this.hasNoTeam = true;
				return false;
			}
			for (let key of Object.keys(data)) {
				const teamMembers = data[key].teamMembers;
				if (!teamMembers) continue;
				const hasTeam = teamMembers.find((x) => x === sessionStorage.getItem('username'));
				if (hasTeam) {
					this.teamId = key;

					this.hasNoTeam = false;
					return true;
				}
			}
			this.hasNoTeam = true;
			return false;
		});
	}
}
