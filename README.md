# Franchise Planner

An exercise in geolocation, csv parsing, and logging. A franchise owner must determine the locations that are furthest apart so they may strategize which areas require more stores. 

![My App](./app.png)

## Overview

This project culminates the C# segment of the Software Engineering course at True Coders (https://truecoders.io). 

The coding challenge was to use a csv file of approximately 300 Taco Bell locations and determine which two are furthest apart from one another. 

## Experiments and Plans

I've since removed redundancies and created a Class Library to decouple the data access layer from the user interface, implementing DAO pattern. 

Tasks:

1. Swap the UI for an ASP.NET Core MVC web application. 
2. Locate an API for mapping purposes. 
3. Provide an option to exclude stores from the list of locations. 
4. Improve time complexity. 
5. Return the top 5 pairs of locations that are furthest apart from each other. 
