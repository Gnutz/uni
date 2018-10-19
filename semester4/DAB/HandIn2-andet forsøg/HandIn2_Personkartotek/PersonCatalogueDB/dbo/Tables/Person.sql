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