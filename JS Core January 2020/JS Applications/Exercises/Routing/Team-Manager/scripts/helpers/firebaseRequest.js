import { apiKey } from '../../firebaseConfig.js';

export const fireBaseRequestFactory = (collectionName, token) => {
	if (!apiKey) {
		throw new Error('You must provide api key');
	}

	if (!apiKey.endsWith('/')) {
		throw new Error('The api key must end with "/"');
	}

	let collectionUrl = apiKey + collectionName;
	const getAll = () => {
		return fetch(collectionUrl + '.json' + (token ? `?auth=${token}` : '')).then((x) => x.json());
	};
	const getById = (id) => {
		return fetch(`${collectionUrl}/${id}.json` + (token ? `?auth=${token}` : '')).then((x) => x.json());
	};
	const createEntity = (entityBody) => {
		return fetch(collectionUrl + '.json' + (token ? `?auth=${token}` : ''), {
			method: 'POST',
			body: JSON.stringify(entityBody)
		}).then((x) => x.json());
	};

	const updateEntity = (entityBody, id) => {
		return fetch(`${collectionUrl}/${id}.json` + (token ? `?auth=${token}` : ''), {
			method: 'PUT',
			body: JSON.stringify(entityBody)
		}).then((x) => x.json());
	};

	const patchEntity = (entityBody, id) => {
		return fetch(`${collectionUrl}/${id}.json` + (token ? `?auth=${token}` : ''), {
			method: 'PATCH',
			body: JSON.stringify(entityBody)
		}).then((x) => x.json());
	};

	const deleteEntity = (id) => {
		return fetch(`${collectionUrl}/${id}.json` + (token ? `?auth=${token}` : ''), {
			method: 'DELETE'
		}).then((x) => x.json());
	};

	return {
		getAll,
		getById,
		createEntity,
		updateEntity,
		patchEntity,
		deleteEntity
	};
};
