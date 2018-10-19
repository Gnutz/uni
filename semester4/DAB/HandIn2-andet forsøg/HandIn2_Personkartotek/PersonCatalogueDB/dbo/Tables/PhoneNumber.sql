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