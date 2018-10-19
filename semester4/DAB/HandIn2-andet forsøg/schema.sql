--
-- Create Table    : 'Country'   
-- CountryID       :  
-- Country         :  
-- CountryCode     :  
--
CREATE TABLE Country (
    CountryID      BIGINT IDENTITY(1,1) NOT NULL UNIQUE,
    CountryName    VARCHAR(255) NOT NULL UNIQUE,
    CountryCode    VARCHAR(255) NOT NULL UNIQUE,
CONSTRAINT pk_Country PRIMARY KEY CLUSTERED (CountryID))
GO

--
-- Create Table    : 'PhoneCompany'   
-- PhnCompanyID    :  
-- Company         :  
--
CREATE TABLE PhoneCompany (
    PhnCompanyID   BIGINT IDENTITY(1,1) NOT NULL UNIQUE,
    CompanyName    NVARCHAR(255) NOT NULL UNIQUE,
CONSTRAINT pk_PhoneCompany PRIMARY KEY CLUSTERED (PhnCompanyID))
GO

--
-- Create Table    : 'City'   
-- CityID          :  
-- City            :  
-- ZipCode         :  
-- CountryID       :  (references Country.CountryID)
--
CREATE TABLE City (
    CityID         BIGINT IDENTITY(1,1) NOT NULL UNIQUE,
    CityName       VARCHAR(255) NOT NULL,
    ZipCode        VARCHAR(255) NOT NULL,
    CountryID      BIGINT NULL,
CONSTRAINT pk_City PRIMARY KEY CLUSTERED (CityID),
CONSTRAINT fk_City FOREIGN KEY (CountryID)
    REFERENCES Country (CountryID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Address'   
-- AddressID       :  
-- Street          :  
-- HouseNumber     :  
-- CityID          :  (references City.CityID)
--
CREATE TABLE Address (
    AddressID      BIGINT IDENTITY(1,1) NOT NULL UNIQUE,
    Street         VARCHAR(255) NOT NULL,
    HouseNumber    VARCHAR(255) NOT NULL,
    CityID         BIGINT NOT NULL,
CONSTRAINT pk_Address PRIMARY KEY CLUSTERED (AddressID),
CONSTRAINT fk_Address FOREIGN KEY (CityID)
    REFERENCES City (CityID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Person'   
-- PersonID        :  
-- AddressID       :  (references Address.AddressID)
-- Firstname       :  
-- Middlename      :  
-- Surname         :  
--
CREATE TABLE Person (
    PersonID       BIGINT IDENTITY(1,1) NOT NULL UNIQUE,
    AddressID      BIGINT NOT NULL,
    Firstname      VARCHAR(255) NOT NULL,
    Middlename     VARCHAR(255) NULL,
    Surname        VARCHAR(255) NOT NULL,
CONSTRAINT pk_Person PRIMARY KEY CLUSTERED (PersonID),
CONSTRAINT fk_Person FOREIGN KEY (AddressID)
    REFERENCES Address (AddressID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Alternative_Address'   
-- PersonID        :  (references Person.PersonID)
-- AddressID       :  (references Address.AddressID)
-- type            :  
--
CREATE TABLE Alternative_Address (
    PersonID       BIGINT NOT NULL,
    AddressID      BIGINT NOT NULL,
    type           VARCHAR(255) NOT NULL,
CONSTRAINT pk_Alternative_Address PRIMARY KEY CLUSTERED (PersonID,AddressID),
CONSTRAINT fk_Alternative_Address FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_Alternative_Address2 FOREIGN KEY (AddressID)
    REFERENCES Address (AddressID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'EmailAddress'   
-- EmailID         :  
-- EmailAdress     :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE EmailAddress (
    EmailID        BIGINT IDENTITY(1,1) NOT NULL UNIQUE,
    Email    	   VARCHAR(255) NOT NULL UNIQUE,
    PersonID       BIGINT NOT NULL,
CONSTRAINT pk_EmailAddress PRIMARY KEY CLUSTERED (EmailID),
CONSTRAINT fk_EmailAddress FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Note'   
-- NoteID          :  
-- Note            :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE Note (
    NoteID         BIGINT IDENTITY(1,1) NOT NULL UNIQUE,
    NoteText       VARCHAR NOT NULL,
    PersonID       BIGINT NOT NULL,
CONSTRAINT pk_Note PRIMARY KEY CLUSTERED (NoteID),
CONSTRAINT fk_Note FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'PhoneNumber'   
-- PhnNumberID     :  
-- PhoneNumber     :  
-- type            :  
-- PersonID        :  (references Person.PersonID)
-- PhnCompanyID    :  (references PhoneCompany.PhnCompanyID)
--
CREATE TABLE PhoneNumber (
    PhnNumberID    BIGINT IDENTITY(1,1) NOT NULL UNIQUE,
    PhoneNumber    NVARCHAR(255) NOT NULL UNIQUE,
    type           NVARCHAR(255) NULL,
    PersonID       BIGINT NULL,
    PhnCompanyID   BIGINT NULL,
CONSTRAINT pk_PhoneNumber PRIMARY KEY CLUSTERED (PhnNumberID),
CONSTRAINT fk_PhoneNumber FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON UPDATE CASCADE,
CONSTRAINT fk_PhoneNumber2 FOREIGN KEY (PhnCompanyID)
    REFERENCES PhoneCompany (PhnCompanyID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

