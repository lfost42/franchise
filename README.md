# Franchise Analytics

Evaluates the coverage health of a franchise by determining which locations (in a provided csv file) are farthest apart. Suggests areas that may need expansion or more coverage.

https://lfost42-franchise.herokuapp.com 

![My App](./app.png)

## WALKTHROUGH

Minimal Viable Product:

A console application that parses through the provided csv file, calculates the locations that are farthest apart, and writes the result to the console. 

OTHER FEATURES:

Completed: 

- Build a Class Library and move methods into classes.
- Implement DAO (Data Access Object) to decouple the data access layer from the user interface.
- Swap the UI and develop an ASP.NET Core MVC web application. 
- Make algorithm onclick.
- Develop front-end
- Add mapping for all locations. 
- Display locations and analysis results on a map. 

Current Issue:
* Mapping the locations revealed our algorithm needs to exclude locations that can connect through other locations. To fix this we need the following:
-- Create a graph that connects all locations to each other. 
-- Exclude vectors that can connect through another location. 
-- Determine which of the remaining vectors have the greatest length.  

Future Updates:
- Option to view, add, delete, and modify locations. 
- Allow CRUD applications to modify map and statistics.
- Option to upload a new csv file and run analysis on it. 
- Improve time complexity?
- Option to export analysis
- Add a dashboard 

DASHBOARD

- Number locations in file.
- Average distance between each location.
- Mean distance between each location. 
- Heatmap of distance variations within dataset. 
- Top 5 pairs of locations that are farthest apart from each other. 
- Option to export dashboard results.

## OPEN REQUIREMENTS


DASHBOARD

- Number locations in file.
- Average distance between each location.
- Mean distance between each location.
- Top 5 pairs of locations that are farthest apart from each other. 
- Option to export dashboard results. 

## USER INTERFACE
- Landing page
- Options to run algorithm or modify list
- Options to run algorithm on full or filtered list (or both, different color indicators for map)
- Dashboard updates after csv file is uploaded, refreshes when algorithm is run

## LOGIC DESIGN
- csv parsing
- mapping API
- statistical charts

## DATA DESIGN
- location (object with latitude, longitude, name)
- locations --> list of locations
- distances - caching/csv output?

- data access - locates CSV
- parsing - parses through CSV list (or filtered list)

### Origins

The project's minimal viable product culminated the C# segment of the Software Engineering course at True Coders (https://truecoders.io). We were to parse a csv file of approximately 300 Taco Bell locations and determine which two were farthest apart from one another. 