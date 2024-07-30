# StringCalculator

## Overview

The `StringCalculator` project is a .NET solution (.Net 6) consisting of a class library and an xUnit test project. The class library implements a simple calculator that performs addition operations on a string input with various delimiter options, and the test project verifies the functionality of the calculator.

## Test-Driven Development (TDD) Approach

This project was developed using a Test-Driven Development (TDD) approach. Each feature was first written as a test case before the actual implementation was developed. This incremental approach ensures that the solution meets the desired functionality and allows for continuous improvement. You can review the commit history to see how the code evolved and improved over time to achieve the final functionality.

## Use of Fluent Assertions

Unit tests in this project utilize [Fluent Assertions](https://fluentassertions.com/), which enhances the readability of the tests. Fluent Assertions allows for writing assertions in a natural, human-readable format that reflects the expected behavior of the code. This makes the unit tests not only more expressive but also serves as live documentation for the system.

## Features and Functionality

The `StringCalculator` class supports the following functionalities and scenarios, as described in [this blog post](https://osherove.com/tdd-kata-1/):

1. **Sum of Two Numbers**: The `Add` method can take up to two numbers separated by commas and return their sum. Examples include:
   - `""` (empty string) returns `0`
   - `"1"` returns `1`
   - `"1,2"` returns `3`

2. **Unknown Amount of Numbers**: The `Add` method can handle an unknown number of numbers separated by commas or new lines. Examples include:
   - `"1,2,3,4,5,6,7,8,9"` returns `45`

3. **New Line Delimiters**: The `Add` method supports new lines as delimiters between numbers. Examples include:
   - `"1\n2,3"` returns `6`
   - Note: `"1,\n"` is not a valid input.

4. **Custom Delimiters**: The `Add` method supports custom delimiters specified at the beginning of the string. For example:
   - `"//;\n1;2"` returns `3`
   - The delimiter is `;` in this case.

5. **Handling Negative Numbers**: If the input contains negative numbers, the `Add` method throws an exception with the message `"negatives not allowed"` followed by the negative numbers. For example:
   - `"1,-2,-3"` returns error - `Negative numbers not allowed: -2, -3`

6. **Ignoring Numbers Greater Than 1000**: Numbers larger than 1000 are ignored in the sum. For example:
   - `"2,1001"` returns `2`

7. **Delimiters of Any Length**: The `Add` method supports delimiters of any length. For example:
   - `"//[***]\n1***2***3"` returns `6`

8. **Multiple Single-Character Delimiters**: The `Add` method supports multiple single-character delimiters. For example:
   - `"//[*][%]\n1*2%3"` returns `6`

9. **Multiple Delimiters of Any Length**: The `Add` method can handle multiple delimiters of varying lengths. For example:
   - `"//[foo][bar]\n1foo2bar3"` returns `6`
   - `"//[foo][**][^]\n1**2^3foo4"` returns `10`

## Solution Structure

The solution, named `StringCalculator`, includes the following projects:

1. **Class Library**: `StringCalculator`
2. **xUnit Test Project**: `StringCalculator.UnitTests`

### 1. StringCalculator (Class Library)

#### Folder Structure
```
StringCalculator
    |-- StringCalculator.cs
    |-- StringCalculator.csproj
```

#### Files

- **`StringCalculator.cs`**: Contains the implementation of the `StringCalculator` class.

#### Functionality

The `StringCalculator` class provides a method to add numbers from a string with various delimiters:

- **`Add(string numbers)`**: 
  - Takes a string containing numbers separated by delimiters.
  - Handles empty strings by returning 0.
  - Extracts delimiters if specified.
  - Converts the numbers to integers.
  - Checks for negative numbers and throws an exception if any are found.
  - Sums up all numbers that are less than or equal to 1000.

- **`ExtractDelimiters(ref string numbers)`**: 
  - Extracts and returns the delimiters from the input string if specified.

- **`CheckNegativeNumbers(List<int> numbers)`**: 
  - Checks if the list contains negative numbers and throws an exception if any are found.

### 2. StringCalculator.UnitTests (xUnit Test Project)

#### Folder Structure

```
StringCalculator.UnitTests
    |-- AddTests.cs
    |-- StringCalculator.UnitTests.csproj
```

#### Files

- **`AddTests.cs`**: Contains unit tests for the `StringCalculator` class using xUnit and FluentAssertions.

#### Functionality

The tests cover various scenarios for the `Add` method of the `StringCalculator` class:

- **`Add_EmptyString_ReturnsZero`**: Tests that an empty string returns 0.
- **`Add_SingleNumber_ReturnsSameNumber`**: Tests that a single number returns the same number.
- **`Add_MultipleNumbers_ReturnsSumOfAllNumbers`**: Tests that multiple comma-separated numbers return their sum.
- **`Add_NewLineDelimiter_ReturnsSumOfNumbers`**: Tests that newline-delimited numbers return their sum.
- **`Add_DifferentDelimiter_ReturnsCorrectSum`**: Tests the use of custom single-character delimiters.
- **`Add_NegativeNumbers_ThrowsExceptionWithNegativeNumbersInErrorMessage`**: Tests that negative numbers throw an exception with a correct error message.
- **`Add_BiggerThan1000_IgnoresNumber`**: Tests that numbers greater than 1000 are ignored in the sum.
- **`Add_AnyLengthDelimiter_ReturnsCorrectSum`**: Tests the use of custom delimiters of any length.
- **`Add_MultipleDifferentDelimitersOfSingleLength_ReturnsCorrectSum`**: Tests multiple single-character delimiters.
- **`Add_MultipleDifferentDelimitersOfAnyLength_ReturnsCorrectSum`**: Tests multiple delimiters of varying lengths.

## Packages Used
1. **StringCalculator** (Class Library):

        No external packages used in this class library project.

2. **StringCalculator.UnitTests** (xUnit Test Project):

    **`FluentAssertions`**: 6.12.0 - Provides a fluent interface for writing assertions.

    **`Microsoft.NET.Test.Sdk`**: 17.1.0 - Test SDK for .NET.

    **`xunit`**: 2.4.1 - Testing framework.

    **`xunit.runner.visualstudio`**: 2.4.3 - xUnit runner for Visual Studio.

    **`coverlet.collector`**: 3.1.2 - Collects code coverage for .NET projects.

## How to Run Tests

To run the tests, use the following command:

    dotnet test StringCalculator.UnitTests