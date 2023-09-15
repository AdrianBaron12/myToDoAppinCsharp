CREATE DATABASE myToDoListDb

CREATE TABLE myToDos(
Id INT IDENTITY(1,1) PRIMARY KEY,
Title varchar(200),
IsDone BIT,
Date DateTime
);

--ALTER LOGIN sa WITH PASSWORD = 'ceb13579!@';  --> Nu am schimbat parola, este to aceeasi

--ALTER LOGIN sa ENABLE;