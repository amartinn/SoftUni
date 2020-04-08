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
	articles: {
		created: (name) => `Successfully created article : ${name}!`,
		editted: (name) => `Successfully editted article : ${name}!`,
		deleted: `Successfully deleted article!`,
		error: {
			category: (category) =>
				`${category} isnt available category.\n Available categories are : C#, Javascript, Java,Pyton`
		}
	}
};
