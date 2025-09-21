CREATE DATABASE ZelisTrainingDB    
USE ZelisTrainingDB

CREATE TABLE Employee(
EmpId INT PRIMARY KEY,
EmpName VARCHAR(20),
EmpDesignation VARCHAR(50),
EmpEmail VARCHAR(20),
EmpPhone VARCHAR(10)
);

CREATE TABLE Technology (
    TechnologyId INT PRIMARY KEY,
    TechName VARCHAR(100),
    TechLevel CHAR(1) CHECK (TechLevel IN ('B', 'I', 'A')),
    Duration INT CHECK (Duration > 0)
);

CREATE TABLE Trainer (
    TrainerId INT PRIMARY KEY,
    TrainerName VARCHAR(100),
    TrainerType CHAR(1) CHECK (TrainerType IN ('I', 'E')),
    Email VARCHAR(20),
    Phone VARCHAR(10)
);

CREATE TABLE Training (
TrainingId INT PRIMARY KEY,
    TrainerId INT REFERENCES Trainer(TrainerId),
    TechnologyId INT REFERENCES Technology(TechnologyId),
    StartDate DATETIME,
    EndDate DATETIME,
    CHECK (EndDate >= StartDate)
);

CREATE TABLE Trainee (
    TrainingId INT REFERENCES Training(TrainingId),
    EmpId INT REFERENCES Employee(EmpId),
    PRIMARY KEY (TrainingId, EmpId),
    Status CHAR(1) CHECK(Status IN ('C','N')),
);

