# ChemiClean

## Background

The company ChemiClean, uses a large number of chemicals in their production. EU law requires that companies that uses any kind of chemicals obtain an updated safety data sheet from the manufacture. If the newest version of a safety data sheet is not accessible to the employees of the company, it will be held accountable, in case of accidents.
An employee have made a database of all the chemicals used by the company, containing links to where on the supplies homepage the safety data sheet can be found. Currently this database holds 100 entries. The safety data sheets are for the most part PDF documents, but they can also be in word or plain text format.

## Required

* Create a web interface where users can view the safety data sheets.
* Save a local copy of the document in the database, and signal the availability to the user.
* On the web interface signal to the user if binary content of the document has changed recently, within 3 days.

## Environment

* Docker
* MSSQL
* Asp.net Core MVC

## Infrastructure

![architecture](https://user-images.githubusercontent.com/42180346/88541660-70962480-d015-11ea-8ad0-b3cf8da2fc80.jpg)

* **Storage Server**
  * Responsible for storing/fetching backup files, implemented using a dockerized node.js express container.
* **Database Server**
  * Responsible for storing/fetching records of chemical products.

## Startup Instructions

* Change Values of ./SQLServer.ServerConfig.cs fields to be able to connect to database.
* Run ./db-init-script.sql to initialize database.
* Run _`docker-compose up`_ command.
* Run the Asp.net Core Project.

## Screenshots

![1](https://user-images.githubusercontent.com/42180346/88540485-52c7c000-d013-11ea-8d56-728b2c9699c7.png)

![2](https://user-images.githubusercontent.com/42180346/88540893-1fd1fc00-d014-11ea-99ba-d8157edd27a0.png)

![3](https://user-images.githubusercontent.com/42180346/88540896-21032900-d014-11ea-9741-89b783ea0430.png)

![4](https://user-images.githubusercontent.com/42180346/88540891-1f396580-d014-11ea-9f71-7a5d6fd1613c.png)
