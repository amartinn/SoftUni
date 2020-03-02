class Hex {
	constructor(value) {
		this.value = value;
	}
	valueOf() {
		return this.value;
	}
	toString() {
		return `0x${this.value.toString(16).toUpperCase()}`;
	}
	plus(number) {
		let value = this.valueOf() + number;
		return new Hex(value);
	}
	minus(number) {
		let value = this.valueOf() - number;
		return new Hex(value);
	}
	parse(string) {
		return parseInt(string, 10);
	}
}
