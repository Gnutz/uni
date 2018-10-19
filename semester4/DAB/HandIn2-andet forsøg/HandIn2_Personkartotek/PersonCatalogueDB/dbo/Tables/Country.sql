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