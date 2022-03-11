# Franchise Calculator

Coding Challenge: Calculate which two locations (among a list in the provided csv file) that are furthest apart. An exercise in geolocation, csv parsing, and logging. 

Application: This algorithm helps franchise owners determine which areas are in need of expansion or more coverage. 

![My App](./app.png)

## Experiments and Plans

MVP:

A console application that parses through the provided csv file, calculates the locations that are furthest apart, and writes the result to the console. 

Completed Items:

1. Build a Class Library and move methods into classes.
2. Implement DAO (Data Access Object) to decouple the data access layer from the user interface.

Future Updates:

3. Swap the UI and develop an ASP.NET Core MVC web application. 
4. Locate and integrate an API for mapping purposes. 
5. Option to display locations on a map. 
6. Option to display the results of the calculator on a map. 
7. Provide an option to exclude stores from the list of locations. 
8. Improve time complexity. 
9. Return the top 5 pairs of locations that are furthest apart from each other. 

## Origins

The project's minimal viable product culminated the C# segment of the Software Engineering course at True Coders (https://truecoders.io). The coding challenge was to parse a csv file of approximately 300 Taco Bell locations and determine which two are furthest apart from one another with logging and unit tests. 