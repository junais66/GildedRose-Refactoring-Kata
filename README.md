##Gilded Rose Refactoring Kata
### Refactored By Junais

## Introduction

This project is a refactoring exercise based on the Gilded Rose Kata. The goal is to refactor and enhance the existing inventory management system while ensuring all functionalities remain intact.

## Approaches Taken

#### Test-Driven Development (TDD)

Test-Driven Development (TDD) was employed throughout the development process to ensure code quality and functionality.

1. **Red-Green-Refactor Cycle**: Each feature or bug fix was approached with writing failing tests first, then implementing the code to make the tests pass, and finally refactoring to improve the code quality without changing its behavior.

2. **Unit Testing**: Extensive unit tests were written using xUnit.NET to validate the behavior of individual components, ensuring that changes did not introduce unintended side effects.

### Design Principles

#### Single Responsibility Principle (SRP)

The Single Responsibility Principle (SRP) guided the design decisions to ensure each class and method has a single responsibility, making the codebase easier to understand, maintain, and extend.

## How to Run the Tests

### Prerequisites

- .NET 7 SDK or later installed on your machine.

### Steps to Run Tests

1. Clone the repository from GitHub: https://github.com/junais66/GildedRose-Refactoring-Kata.git

2. Navigate to the test project directory: cd GildedRose-Refactoring-Kata

3. Restore dependencies and build the solution: dotnet restore

4. Run the tests: dotnet test

This command will execute all unit tests in the solution and display the test results in the console.