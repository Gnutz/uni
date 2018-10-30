--
-- Create Table    : 'Note'   
-- NoteID          :  
-- Note            :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE Note (
    NoteID         BIGINT IDENTITY(1,1) NOT NULL UNIQUE,
    NoteText       VARCHAR(255) NOT NULL,
    PersonID       BIGINT NOT NULL,
CONSTRAINT pk_Note PRIMARY KEY CLUSTERED (NoteID),
CONSTRAINT fk_Note FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)