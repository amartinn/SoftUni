function solve(worker) {
	let { weight, experience, levelOfHydrated, dizziness } = worker;
	if (dizziness) {
		if (dizziness === true) {
			let amountWaterNeeded = 0.1 * weight * experience;
			levelOfHydrated += amountWaterNeeded;
			dizziness = false;
			return {
				weight,
				experience,
				levelOfHydrated,
				dizziness
			};
		}
	} else {
		return worker;
	}
}
console.log(
	solve({
		weight: 120,
		experience: 20,
		levelOfHydrated: 200,
		dizziness: false
	})
);
