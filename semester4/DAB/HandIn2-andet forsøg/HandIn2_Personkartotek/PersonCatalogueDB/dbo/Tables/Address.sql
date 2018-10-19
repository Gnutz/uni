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