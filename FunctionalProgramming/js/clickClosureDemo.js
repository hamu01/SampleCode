var add_the_handlers = function (nodes) {
var i;
for (i = 0; i < nodes.length; i += 1) {
	nodes[i].onclick = (function (index) {
		return function(e){							
			alert(index);
		}
	})(i)
}