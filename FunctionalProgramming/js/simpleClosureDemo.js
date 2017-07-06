function parentFunc() {
	var a = 1;
	var subFunc = function(b) {
		return a + b;
	};
	return subFunc;
}

var f = parentFunc();
var result = f(2);
document.write(result + "<br>");