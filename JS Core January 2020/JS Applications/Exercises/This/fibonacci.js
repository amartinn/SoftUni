function getFibonator() {
	var arr = [ 0, 1 ];
	return function() {
		var num = arr[arr.length - 1],
			len = arr.length;
		arr.push(arr[len - 1] + arr[len - 2]);
		return num;
	};
}
