const apiKey = ``;

export const getAllPlayers = () => {
	fetch((apiKey = 'players.json')).then((r) => r.json());
};
