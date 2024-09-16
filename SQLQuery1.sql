CREATE DATABASE TicketingSystem;
CREATE TABLE Tickets(
    TicketId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100),
    CustomerName NVARCHAR(100),
    Issue NVARCHAR(500),
    CompanyName NVARCHAR(100),
    IssueCategory NVARCHAR(100),
    Description NVARCHAR(MAX),
    Status NVARCHAR(50),
    AssignTo NVARCHAR(100)
);
SELECT *FROM Tickets;