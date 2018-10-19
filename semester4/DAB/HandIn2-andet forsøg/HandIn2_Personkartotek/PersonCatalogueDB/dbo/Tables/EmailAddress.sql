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