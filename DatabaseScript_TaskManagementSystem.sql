CREATE DATABASE TaskManagementSystem;
GO
USE TaskManagementSystem;

CREATE TABLE Users(
	UserId INT NOT NULL IDENTITY(1,1),
    Trashed BIT,
    UserRole INT,
    UserName NVARCHAR(128),
    UserPassword NVARCHAR(512),
    CONSTRAINT PK_User PRIMARY KEY (UserId)
 );
 
CREATE TABLE Contacts (
    ContactId INT NOT NULL IDENTITY(1,1),
    Trashed BIT,
    LastName NVARCHAR(64),
    FirstName NVARCHAR(64),
    Email NVARCHAR(64),
    UserId INT,
    CONSTRAINT PK_Contact PRIMARY KEY (ContactId),
    CONSTRAINT FK_ContactUser FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
  
 CREATE TABLE Tasks(
	TaskId INT NOT NULL IDENTITY(1,1),
    Trashed BIT,
    Title NVARCHAR(128),
    ShortDescription NVARCHAR(1024),
    TaskStatus INT,
    DueDate DATETIMEOFFSET,
    StartDate DATETIMEOFFSET,
    EndDate DATETIMEOFFSET,
    AssignedTo INT,
    CONSTRAINT PK_Task PRIMARY KEY (TaskId)
 );
 
 CREATE TABLE Logs(
	LogId INT NOT NULL IDENTITY(1,1),
    RequestUrl NVARCHAR(256),
    IsSuccess BIT,
    ErrorMessage NVARCHAR(MAX),
    ShortDescription NVARCHAR(1024),    
    SignedInContact INT,
    CreatedDateTime DATETIMEOFFSET,   
    CONSTRAINT PK_Log PRIMARY KEY (LogId)
 );

