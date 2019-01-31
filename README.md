# ShoppingBasketTest

Here are some comments about my solution
## How to run
The class library cannot be run directly, but the `MsTest` project should run in VS2017
using the `Test Explorer` window, or `Run Tests` if using `Resharper`
## Dependency Injection
Because the main project is just a class library, DI is not fully implemented. 
To use .NET core DI or a third party like `Autofac` I'd need an MVC project, or a WebAPI,
but the library is ready to support it.
## Project tests
I have added all the tests in the same project, to keep things simple for this exercise.
In a future refactoring I would remove the test scenarios from the test project and add
an Integration Tests project with them, leaving only method based unit tests in this one.

I chose a `MsTest` project with `NSubstitute` for mocking and `NFluent` for assertions,
just for personal preference as I am familiar with those framworks.
## TDD process
This is roughtly the process I followed to code the exercise following a TDD approach
* add the Test Scenarios from the requirements, which obviously fail as nothing is implemented yet
* Add tests for the 2 methods of the main class, mocking the `PriceCalculator` dependency,
as we are not testing or implementing that yet
* Implement the methods to pass the tests
* Add tests for the `PriceCalculator` class, making sure to include all the edge cases:
offers, multiple offers combined, etc
* Implement the class to pass the tests
* At this point the original Test Scenarios passed without any further change in the code
## Improvements
There are a few things can be implemented in future iterations that I decided not to do for
the exercise to keep things simple and focus on the given scenarios and the TDD process
* Add the funcionality to add products with quantity other than 1 to the basket
* Remove items / clear basket functionality
* Load the list of available products and prices from a Daabase table to be able to add new products
in the future with no change to the code
* Define a discount rule template outside the `PriceCalculator` to allow for future rules to be
created without having to change the `PriceCalculator` class
