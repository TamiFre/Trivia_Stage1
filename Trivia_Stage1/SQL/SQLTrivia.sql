CREATE DATABASE TriviaDB;


CREATE TABLE Players(
PlayerID int identity(1,1)  Primary Key NOT NULL,
Mail varchar (50),
Pass nvarchar(20),
Points int,
PlayerName nvarchar (70),
DargaId int FOREIGN KEY REFERENCES Darga(DargaID) ,
)

CREATE TABLE Darga(
DargaID int identity (1,1) PRIMARY KEY NOT NULL,
DargaName varchar (30),
)

CREATE TABLE Qs(
QID int identity (1,1) PRIMARY KEY NOT NULL,
Title varchar (100),
AnsCorrect varchar (30),
A1 varchar (30),
A2 varchar (30),
A3 varchar (30),
PlayerID int FOREIGN KEY REFERENCES Players(PlayerID),
SubjectID int FOREIGN KEY REFERENCES Subjects(SubjectID),
)

CREATE TABLE Subjects(
SubjectID int identity (1,1) PRIMARY KEY NOT NULL,
SubjectName varchar (20),
)

CREATE TABLE StatusQs(
StatusID int identity (1,1) PRIMARY KEY NOT NULL,
StatusName varchar (30),
)


