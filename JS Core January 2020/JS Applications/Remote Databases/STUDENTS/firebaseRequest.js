const apiKey = `https://softuni-students.firebaseio.com/`;

export const listAll = () => {
	return fetch(apiKey + 'students.json').then((r) => r.json());
};
