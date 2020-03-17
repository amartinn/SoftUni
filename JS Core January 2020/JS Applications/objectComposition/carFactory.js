function factory(orderedCar) {
	const engines = [
		{ type: 'Small engine', power: 90, volume: 1800 },
		{ type: 'Normal engine', power: 120, volume: 2400 },
		{ type: 'Monster engine', power: 200, volume: 3500 }
	];
	let requiredEngine = engines.find((x) => x.power >= orderedCar.power);
	let wheelSize = orderedCar.wheelsize % 2 === 0 ? Math.floor(orderedCar.wheelsize - 1) : orderedCar.wheelsize;

	return {
		model: orderedCar.model,
		engine: {
			power: requiredEngine.power,
			volume: requiredEngine.volume
		},
		carriage: {
			type: orderedCar.carriage,
			color: orderedCar.color
		},
		wheels: Array(4).fill(wheelSize)
	};
}

console.log(
	factory({
		model: 'VW Golf II',
		power: 90,
		color: 'blue',
		carriage: 'hatchback',
		wheelsize: 17
	})
);
