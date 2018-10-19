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