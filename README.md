# Franchise Planner

Calculates which two locations among a list of franchises are furthest apart, used to determine which areas should be considered for expansion. An exercise in geolocation, csv parsing, and logging. 

![My App](./app.png)

## Experiments and Plans

When I first built this project, most of the program logic was in Main and I've been slowly moving that logic into classes as I progressed in my learning. 

Completed Updates:

1. Build a Class Library and move methods into classes.
2. Implement DAO (Data Access Object) to complete the decoupling of the data access layer from the user interface.

Future Updates:

3. Swap the UI for an ASP.NET Core MVC web application. 
4. Locate an API for mapping purposes. 
5. Provide an option to exclude stores from the list of locations. 
6. Improve time complexity. 
7. Return the top 5 pairs of locations that are furthest apart from each other. 

## Origins

This project culminated the C# segment of the Software Engineering course at True Coders (https://truecoders.io). The coding challenge was to parse a csv file of approximately 300 Taco Bell locations and determine which two are furthest apart from one another. 
