# Road Trip Planner

An exercise in geolocation, csv parsing, and logging. The main logic is present from a previous assignment. Future plans are below.

![My App](./app.png)

## Overview

This project culminates the C# segment of the Software Engineering course at True Coders (https://truecoders.io). 
The challenge was to use a csv file of approximately 300 Taco Bell locations and determine which two are furthest
apart from one another. 

## Experiments

When the assignmet was complete, I imagined turning this into a web applicaiton and foresaw issues with the way the solution was implemented. The conversion to GeoCoordinate needed to be in a class and possibly parsed directly from the CSV file. 

I hesitated to make changes to the orignal program but as I progressed in optimizing the structure (as much as I could at this time), the Point struct and IPoint interface did not make sense to keep. 

## Plans

I will turn this challenge into a web application and utilize an API to perform other tasks with the gecoordinate data. 

## Road Trip Thoughts

I'm planning to build a "Road Trip Planner" where the user selects any two geographic coordinate points and have all the Taco Bell locations between the two points filtered and mapped. This can be applied to other items of interest but I'll work with the Taco Bell data currently at my disposal. 
