Use Master
Go
if exists(Select * From sys.databases Where Name = 'Examination')
Drop DataBase Examination
Go
Create Database Examination
On
(
	name = 'Examination_data',
	filename = 'C:\SQL\Examination_data.mdf'
)
Log on
(
	name = 'Examination_log',
	filename = 'C:\SQL\Examination_log.ldf'
)
Go
Use Examination
Go
If Exists(Select * From sys.tables Where Name = 'Grade')
Drop Table Grade
Go
Create Table Grade
(
	Id Int Primary Key Identity(1,1) Not Null,
	GradeName Varchar(50) Not Null
)
Go
If Exists(Select * From sys.tables Where Name = 'Book')
Drop Table Book
Go
Create Table book
(
	Id int Primary Key Identity(1,1) Not Null,
	BookName Varchar(50) Unique Not Null,
	Grade_Id Int References Grade(Id) Not Null
)
Go
Insert Into Grade Values('S1'),('S2'),('Y2')
Insert Into Book Values('C#',1),('.Net',2),('HTML',3)
Go
Select * From Grade
Select * From Book
Select * From Grade Inner Join Book on Grade.Id = Book.Id
-- Delete From book where Grade_Id = 2

-- insert into Book values('C++',1)
