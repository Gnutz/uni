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
    ON DELETE NO ACTION
    ON UPDATE  NO ACTION,
CONSTRAINT fk_Alternative_Address2 FOREIGN KEY (AddressID)
    REFERENCES Address (AddressID)
    ON DELETE  NO ACTION
    ON UPDATE  NO ACTION)