# Jigsaw Demo

The project comprises of a Vue/Typescript based client backed with a .NET Core WebAPI.

To run the client:

 - npm install
 - npm run serve

The default API URL is http://localhost:56559/tree. If this is changed, then the API_URL value in the client's constants.ts file needs to be changed too.

To run the API: 

- Create an SQL Server DB called 'JigsawDemo' at localhost.
- Run the migrations ('update-database'). This should create 4 records representing the tree hierarchy
- Launch the API

The application does two things:

- Retrieves tree data from the API and displays it as a graph
- Double clicking on any of the nodes creates a child for that node and saves the data via the API 


 
 
