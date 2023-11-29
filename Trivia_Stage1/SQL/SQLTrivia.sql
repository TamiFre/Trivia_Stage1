CREATE DATABASE TriviaDB;
USE TriviaDB
CREATE TABLE Darga(
DargaID int identity (1,1) PRIMARY KEY NOT NULL,
DargaName varchar (30),
)

CREATE TABLE Subjects(
SubjectID int identity (1,1) PRIMARY KEY NOT NULL,
SubjectName varchar (20),
)
CREATE TABLE StatusQs(
StatusID int identity (1,1) PRIMARY KEY NOT NULL,
StatusName varchar (30),
)

CREATE TABLE Players(
PlayerID int identity(1,1)  Primary Key NOT NULL,
Mail varchar (50),
Pass nvarchar(20),
Points int,
PlayerName nvarchar (70),
DargaID int FOREIGN KEY REFERENCES Darga(DargaID) ,
)


--DROP TABLE Qs;
CREATE TABLE Qs(
QID int identity (1,1) PRIMARY KEY NOT NULL,
Title varchar (100),
AnsCorrect varchar (30),
A1 varchar (30),
A2 varchar (30),
A3 varchar (30),
PlayerID int FOREIGN KEY REFERENCES Players(PlayerID),
SubjectID int FOREIGN KEY REFERENCES Subjects(SubjectID),
StatusID int FOREIGN KEY REFERENCES StatusQs(StatusID),
)


INSERT INTO StatusQs (StatusName) VALUES ('Approved');
INSERT INTO StatusQs (StatusName) VALUES ('Declined');
INSERT INTO StatusQs (StatusName) VALUES ('Pending');


INSERT INTO Subjects ( SubjectName) VALUES ('Sports');
INSERT INTO Subjects ( SubjectName) VALUES ('Pop Culture');
INSERT INTO Subjects ( SubjectName) VALUES ('Geography');
INSERT INTO Subjects ( SubjectName) VALUES ('Books');
INSERT INTO Subjects ( SubjectName) VALUES ('History');



INSERT INTO Darga ( DargaName) VALUES ('Rookie');
INSERT INTO Darga ( DargaName) VALUES ('Master');
INSERT INTO Darga ( DargaName) VALUES ('Manager');


INSERT INTO Players (Mail,Pass,Points,PlayerName,DargaID) VALUES ( 'sh@gmail.com', 'password', 60,'TSSG',3 );

INSERT INTO Qs (Title, AnsCorrect, A1, A2, A3,PlayerID, SubjectID, StatusID) VALUES ( 'What year did the movie "Titanic" come out?', '1997', '1800', '1992','2003', 1, 2, 1);
INSERT INTO Qs (Title, AnsCorrect, A1, A2, A3,PlayerID, SubjectID, StatusID) VALUES ( 'How Many Minutes are in a basketball game?','48','43','50','60', 1, 1, 1);
INSERT INTO Qs (Title, AnsCorrect, A1, A2, A3,PlayerID, SubjectID, StatusID) VALUES ( 'Whats is the capital of China?', 'Beijing', 'Bangkok', 'Shanghai','Tokyo', 1, 3, 1);
INSERT INTO Qs (Title, AnsCorrect, A1, A2, A3,PlayerID, SubjectID, StatusID) VALUES ( 'How many Harry Potter books ae there?', '7', '5', '8','12', 1, 4, 1);
INSERT INTO Qs (Title, AnsCorrect, A1, A2, A3,PlayerID, SubjectID, StatusID) VALUES ( 'What year did Hitler come to power?', '1933', '1939', '1925','1942', 1, 5, 1);










