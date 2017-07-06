// function People(firstName) {
	// this.getFirstName = function() {
		// return firstName;
	// }
	// this.setFirstName = function(fName) {
		// firstName = fName;
	// }
	// this.sayHello = function() {
		// return "Hi " + firstName;
	// }
// }

var People = (function (firstName) {
	var PeopleFactory = function() {
		this.getFirstName = function() {
			return firstName;
		}
		this.setFirstName = function(fName) {
			firstName = fName;
		}
		this.sayHello = function() {
			return "Hi " + firstName;
		}
	}
	return PeopleFactory;
})("Jim");
var people = new People();
document.write(people.firstName + "<br>");
document.write(people.getFirstName() + "<br>");
document.write(people.sayHello() + "<br>");
people.setFirstName("Bob");
document.write(people.getFirstName() + "<br>");
document.write(people.sayHello() + "<br>");