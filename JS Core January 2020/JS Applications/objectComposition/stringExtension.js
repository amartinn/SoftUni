(function() {
	String.prototype.ensureStart = function(str) {
		return this.startsWith(str) ? this : str + this;
	};
	String.prototype.ensureEnd = function(str) {
		return this.endsWith(str) ? this : this + str;
	};
	String.prototype.isEmpty = function() {
		return this.length === 0 ? true : false;
	};
	String.prototype.truncate = function(n) {
		return this.substring(0, n) + '...';
	};
	let str = 'my string';
	str = str.ensureStart('my');
	str = str.ensureStart('hello ');
	str = str.truncate(16);
	console.log(str);
})();
