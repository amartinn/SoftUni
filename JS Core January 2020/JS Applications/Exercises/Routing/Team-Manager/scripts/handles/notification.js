export async function notificationHandler(message, type, time = 3000) {
	const elementId = type ? `#${type}Box` : `#infoBox`;
	const notification = document.querySelector(elementId);
	notification.style.display = 'block';
	notification.textContent = message;
	setTimeout(() => {
		notification.style.display = 'none';
		notification.textContent = '';
	}, time);
}
export const notificationMessages = {
	register: {
		successfull: 'Sucessfully registered user!',
		emailInUse: 'This email is already in use!',
		passwordMatch: 'Passwords must match!',
		invalidEmail: 'Email is invalid!'
	},
	login: {
		successfull: 'Sucessfully logged in!',
		unsuccessfull: 'Please check your credentials!'
	},
	logout: {
		successfull: 'Successfully logged out!'
	},
	team: {
		created: (name) => `Successfully created team : ${name}!`,
		editted: (name) => `Successfully editted team : ${name}!`,
		joined: {
			sucess: (name) => `Successfully joined team : ${name}!`,
			error: `You are already in a team!`
		},
		leaved: (name) => `Successfully leaved team : ${name}!`
	}
};
