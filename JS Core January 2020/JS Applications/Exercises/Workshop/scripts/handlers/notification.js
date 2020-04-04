export async function notificationHandler(type, text, time = 2000) {
	const notification = document.querySelector(`#${type}Box`);
	notification.textContent = text;
	notification.style.display = 'block';
	setTimeout(() => {
		notification.textContent = '';
		notification.style.display = 'none';
	}, time);
}
export function HideLoadingShowCheck() {
	$(document).ajaxStart(function() {
		$('#loadingBox').show();
	});
	$(document).ajaxStop(function() {
		$('#loadingBox').hide();
	});
}
export const notificationMessages = {
	successfull: {
		register: 'Successfully registered user.',
		login: 'successfully logged user.',
		logout: 'Logout successful.',
		createdTrek: 'Trek created successfully.',
		edit: 'Trek edited successfully.',
		delete: 'You closed the trek successfully',
		like: 'You liked the trek successfully.'
	},
	error: {
		register: {
			email: 'Email must be at least 3 characters long !',
			password: 'Password must be at least 6 characters long!',
			passwordMatch: 'Passwords must match!',
			emailInUse: 'This email is already in use!'
		},
		login: {
			both: 'Invalid credentials.Please retry your request with correct credentials!'
		},
		invalid: {
			input: 'Invalid Input!'
		}
	}
};
