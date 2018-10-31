using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using DomainModelPersonCatalogue;


namespace Infrastructure
{
    public class DBUtility
    {
        private Person currentPerson;
        private Address currentAddress;
        private AlternativeAddress currentAlternativeAddress;
        private City currentCity;
        private Country currentCountry;
        private Note currentNote;
        private EmailAddress currentEmail;
        private Phonenumber currentNumber;
        private PhoneCompany currentPhoneCompany;


        public DBUtility()
        {
            currentPerson = new Person();
            currentAddress = new Address();
            currentAlternativeAddress = new AlternativeAddress();
            currentCity = new City();
            currentCountry = new Country();
            currentEmail = new EmailAddress();
            currentNote = new Note();
            currentNumber = new Phonenumber();
            currentPhoneCompany = new PhoneCompany();
        }


        private SqlConnection OpenConnection
        {
            get
            {
                //var con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=CraftManDB;Integrated Security=True");
                var con = new SqlConnection(
                    @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PersonCatalogueDB; Integrated Security = True; Persist Security Info = False; Pooling = False; MultipleActiveResultSets = False; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = True");
                con.Open();
                return con;
            }
        }


        //--------------- COUNTRY CRUD OPS-----------------------------------------
        public void AddCountry(ref Country country)
        {
            string insertStringParam = @"INSERT INTO [Country] (CountryName, CountryCode)
                                                    OUTPUT INSERTED.CountryID  
                                                    VALUES (@CountryName, @CountryCode)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@CountryName", country.CountryName);
                cmd.Parameters.AddWithValue("@CountryCode", country.CountryCode);
                country.CountryID = (long) cmd.ExecuteScalar(); //Returns the identity of the new tuple/record
            }

        }

        public void GetCountryById(ref Country country)
        {
            string selectString = @"SELECT * FROM Country WHERE (CountryID = @CountryID)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@CountryID", country.CountryID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    country.CountryID = (long) rdr["CountryID"];
                    country.CountryName = (string) rdr["CountryName"];
                    country.CountryCode = (string) rdr["CountryCode"];
                }
            }
        }

        public void GetCountryByName(ref Country country)
        {
            string sqlcmd = @"SELECT  TOP 1 * FROM Country WHERE (CountryName = @cname)";
            using (var cmd = new SqlCommand(sqlcmd, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@cname", country.CountryName);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    currentCountry.CountryID = (long) rdr["CountryID"];
                    currentCountry.CountryName = (string) rdr["CountryName"];
                    currentCountry.CountryCode = (string) rdr["CountryCode"];
                    country = currentCountry;
                }
            }
        }

        public void DeleteCountry(ref Country country)
        {
            string deleteString = @"DELETE FROM Country WHERE (CountryID = @CountryID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@CountryID", country.CountryID);

                var id = (long) cmd.ExecuteNonQuery();
                country = null;
            }
        }

        public void UpdateCountry(ref Country country)
        {
            string updateString =
                @"UPDATE Country                 
                        SET CountryName= @CountryName, CountryCode = @CountryCode 
                        WHERE CountryID = @CountryID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@CountryName", country.CountryName);
                cmd.Parameters.AddWithValue("@CountryCode", country.CountryCode);
                cmd.Parameters.AddWithValue("@CountryID", country.CountryID);


                var id = (int) cmd.ExecuteNonQuery();
            }
        }

        //--------------- City CRUD OPS-----------------------------------------

        public void AddCity(ref City city)
        {

          
            string insertStringParam = @"INSERT INTO [City] (CityName, ZipCode, CountryID)
                                                    OUTPUT INSERTED.CityID  
                                                    VALUES (@CityName, @ZipCode, @CountryID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@CityName", city.CityName);
                cmd.Parameters.AddWithValue("@ZipCode", city.ZipCode);
                cmd.Parameters.AddWithValue("@CountryID", city.Country.CountryID);
                city.CityID = (long) cmd.ExecuteScalar();
            }
        }

        public void GetCityById(ref City city)
        {
            string selectString = @"SELECT * FROM City WHERE (CityID = @CityID)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@CityID", city.CityID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();


                if (rdr.Read())
                {

                    city.CityID = (long) rdr["CityID"];
                    city.CityName = (string) rdr["CityName"];
                    city.ZipCode = (string) rdr["ZipCode"];
                    currentCountry.CountryID = (long) rdr["CountryID"];


                }

                GetCountryById(ref currentCountry);
                city.Country = currentCountry;
            }
        }

        public void GetCityByName(ref City city)
        {
            string selectString = @"SELECT  TOP 1 * FROM City WHERE (CityName = @cname)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@cname", city.CityName);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    city.CityID = (long) rdr["CityID"];
                    city.CityName = (string) rdr["CityName"];
                    city.ZipCode = (string) rdr["ZipCode"];
                    currentCountry.CountryID = (long) rdr["CountryID"];


                }

                GetCountryById(ref currentCountry);
                city.Country = currentCountry;


            }

        }

        public void DeleteCity(ref City city)
        {
            string deleteString = @"DELETE FROM City WHERE (CityID = @CityID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@CityID", city.CityID);

                var id = (long) cmd.ExecuteNonQuery();
                city = null;
            }
        }

        public void UpdateCity(ref City city)
        {
            string updateString =
                @"UPDATE City                 
                        SET CityName= @CityName, ZipCode = @ZipCode 
                        WHERE CityID = @CityID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@CityID", city.CityID);
                cmd.Parameters.AddWithValue("@CityName", city.CityName);
                cmd.Parameters.AddWithValue("@ZipCode", city.ZipCode);
                

                var id = (int) cmd.ExecuteNonQuery();
            }

        }

        //--------------- AlternativeAddress CRUD OPS-----------------------------------------

        
        public void AddAltAddress(ref AlternativeAddress altAddress)
        {

            string insertStringParam = @"INSERT INTO [ALternative_Address] (PersonID, AddressID, type)
                                                  VALUES (@PersonID, @AddressID, type)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@PersonID", altAddress.Person.PersonId);
                cmd.Parameters.AddWithValue("@AddressID", altAddress.Address.AddressID);
            }
        }

        public List<AlternativeAddress> GetAllOfAPersonsAltAddresses(ref Person person)
        {

            string selectString =
                @"SELECT * FROM   Address INNER JOIN
             Alternative_Address ON Address.AddressID = Alternative_Address.AddressID LEFT OUTER JOIN
             Person ON Address.AddressID = Person.AddressID AND Alternative_Address.PersonID = Person.PersonID
             WHERE (Alternative_Address.PersonID = @PersonID)";

            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                SqlDataReader rdr = null;
                cmd.Parameters.AddWithValue("@PersonID", person.PersonId);
                rdr = cmd.ExecuteReader();

                List<AlternativeAddress> _alternativeAddresses = new List<AlternativeAddress>();
                AlternativeAddress altAddress = null;
                while (rdr.Read())
                {
                    altAddress = new AlternativeAddress();
                    Person person_ = new Person();
                    altAddress.Person = person_;
                    altAddress.Person.PersonId = (long)rdr["PersonID"];
                    altAddress.Address.AddressID = (long)rdr["AddressID"];
                    altAddress.Address.Street = (string)rdr["Street"];
                    altAddress.Address.HouseNumber = (string)rdr["HouseNumber"];
                    altAddress.Address.City.CityID = (long)rdr["CityID"];
                    altAddress.Type = (string)rdr["type"];

                    _alternativeAddresses.Add(altAddress);
                }

                return _alternativeAddresses;

            }

        }

        
        public void DeleteAltAddress(ref AlternativeAddress altAddress)
        {
            string deleteString = @"DELETE FROM Alternative_Address	WHERE (Alternative_Address.PersonID = @PersonID AND 
                                                                           Alternative_Address.AddressID = @AddressID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@AddressID", altAddress.Address.AddressID);
                cmd.Parameters.AddWithValue("@PersonID", altAddress.Person.PersonId);

                var id = (long)cmd.ExecuteNonQuery();
                altAddress = null;
            }
        }

       
        public void UpdateAltAddress(ref AlternativeAddress altAddress)
        {
            string updateString =
                @"UPDATE Alternative_Address                 
                        SET AddressID= @AddressID, type = @type, 
                        WHERE Alternative_Address.PersonID @PersonID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PersonID", altAddress.Person.PersonId);
                cmd.Parameters.AddWithValue("@type", altAddress.Type);

                var id = (int)cmd.ExecuteNonQuery();
            }


        }

        //--------------- Address CRUD OPS-----------------------------------------

        
        public void AddAddress(ref Address address)
        {


            string insertStringParam = @"INSERT INTO [Address] (Street, HouseNumber, CityID)
                                                    OUTPUT INSERTED.AddressID  
                                                    VALUES (@Street, @HouseNumber, @CityID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@Street", address.Street);
                cmd.Parameters.AddWithValue("@HouseNumber", address.HouseNumber);
                cmd.Parameters.AddWithValue("@CityID", address.City.CityID);
                address.AddressID = (long)cmd.ExecuteScalar();
            }
        }

        public void GetAddressById(ref Address address)
        {
            string selectString = @"SELECT * FROM Address WHERE (AddressID = @AddressID)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@AddressID", address.AddressID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();


                if (rdr.Read())
                {

                    address.AddressID = (long)rdr["AddressID"];
                    address.Street = (string)rdr["Street"];
                    address.HouseNumber = (string)rdr["HouseNumber"];
                    currentCity.CityID = (long)rdr["CityID"];


                }

                GetCityById(ref currentCity);
                address.City = currentCity;
            }
        }

        public void GetAddressByPerson(ref Person person)
        {
            string selectString = @"SELECT * FROM Address INNER JOIN
                           Person ON Person.AddressID = Address.AddressID
                           WHERE (Person.PersonID = @PersonID)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PersonID", person.PersonId);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                Address address = new Address();
                if (rdr.Read())
                {

                    address.AddressID = (long)rdr["AddressID"];
                    address.Street = (string)rdr["Street"];
                    address.HouseNumber = (string)rdr["HouseNumber"];
                    currentCity.CityID = (long)rdr["CityID"];

                }

                GetCityById(ref currentCity);
                address.City = currentCity;

                person.PrimaryAddress = address;
            }
        }


        public void DeleteAddress(ref Address address)
        {
            string deleteString = @"DELETE FROM Address WHERE (AddressID = @AddressID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@AddressID", address.AddressID);

                var id = (long)cmd.ExecuteNonQuery();
                address = null;
            }
        }

        
        public void UpdateAddress(ref Address address)
        {
            string updateString =
                @"UPDATE Address                 
                        SET Street= @Street, HouseNumber = @HouseNumber 
                        WHERE AddressID = @AddressID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@AddressID", address.AddressID);
                cmd.Parameters.AddWithValue("@Street", address.Street);
                cmd.Parameters.AddWithValue("@HouseNumber", address.HouseNumber);

                var id = (int)cmd.ExecuteNonQuery();
            }


        }

        //--------------- Person CRUD OPS-----------------------------------------

        
        public void AddPerson(ref Person person)
        {


            string insertStringParam = @"INSERT INTO [Person] (FirstName, MiddleName, Surname, AddressID)
                                                    OUTPUT INSERTED.PersonID 
                                                    VALUES (@FirstName, @MiddleName, @Surname, @AddressID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", person.MiddleName);
                cmd.Parameters.AddWithValue("@Surname", person.Surname);
                cmd.Parameters.AddWithValue("@AddressID", person.PrimaryAddress.AddressID);
                person.PersonId = (long)cmd.ExecuteScalar();
            }
        }
        
        
        public void GetPersonById(ref Person person)
        {
            string selectString = @"SELECT * FROM Person WHERE (PersonId = @PersonId)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PersonId", person.PersonId);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();


                if (rdr.Read())
                {

                    person.PersonId = (long)rdr["PersonID"];
                    person.FirstName = (string) rdr["FirstName"];
                    person.MiddleName = (string)rdr["MiddleName"];
                    currentAddress.AddressID = (long)rdr["AddressID"];


                }

                GetAddressById(ref currentAddress);
                person.PrimaryAddress = currentAddress;
            }
        }
        
        
        public void DeletePerson(ref Person person)
        {
            string deleteString = @"DELETE FROM Person WHERE (PersonId = @PersonId)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue(" @PersonId", person.PersonId);

                var id = (long)cmd.ExecuteNonQuery();
                person = null;
            }
        }


        
        public void UpdatePerson(ref Person person)
        {
            string updateString =
                @"UPDATE Person                 
                        SET FirstName = @FirstName, MiddleName = @MiddleName, SurName = @Surname
                        WHERE (PersonId = @PersonId)";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PersonId", person.PersonId);
                cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", person.MiddleName);
                cmd.Parameters.AddWithValue("@Surname", person.Surname);


                var id = (int)cmd.ExecuteNonQuery();
            }


        }


        //--------------- PHONECOMPANY CRUD OPS-----------------------------------------
        
        public void AddPhoneCompany(ref PhoneCompany company)
        {
            string insertStringParam = @"INSERT INTO [PhoneCompany] (CompanyName)
                                                    OUTPUT INSERTED.PhnCompanyID  
                                                    VALUES (@CompanyName)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                company.PhoneCompanyID = (long)cmd.ExecuteScalar(); //Returns the identity of the new tuple/record
            }

        }
        
        
        public void GetPhoneCompanyById(ref PhoneCompany company)
        {
            string selectString = @"SELECT * FROM PhoneCompany WHERE (PhnCompanyID = @PhnCompanyID)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PhnCompanyID", company.PhoneCompanyID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    company.PhoneCompanyID = (long)rdr["PhnCompanyID"];
                    company.CompanyName = (string)rdr["CompanyName"];
                }
            }
        }
        
        
        public void GetPhoneCompanyByName(ref PhoneCompany company)
        {
            string sqlcmd = @"SELECT  TOP 1 * FROM Company WHERE (CompanyName = @cname)";
            using (var cmd = new SqlCommand(sqlcmd, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@cname", company.CompanyName);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    currentPhoneCompany.PhoneCompanyID = (long)rdr["companyID"];
                    currentPhoneCompany.CompanyName = (string) rdr["companyName"];
                    company = currentPhoneCompany;
                }
            }
        }
        
        
        public void DeletePhoneCompany(ref PhoneCompany company)
        {
            string deleteString = @"DELETE FROM Company WHERE (PhnCompanyID = @PhnCompanyID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PhnCompanyID", company.PhoneCompanyID);

                var id = (long)cmd.ExecuteNonQuery();
                company = null;
            }
        }

        
        public void UpdatePhoneCompany(ref PhoneCompany company)
        {
            string updateString =
                @"UPDATE PhoneCompany                 
                        SET CompanyName= @CompanyName 
                        WHERE PhnCompanyID = @PhnCompanyID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                cmd.Parameters.AddWithValue("@PhnCompanyID", company.PhoneCompanyID);

                var id = (int)cmd.ExecuteNonQuery();
            }
        }

        //--------------- Phonenumber CRUD OPS-----------------------------------------

        
        public void AddPhonenumber(ref Phonenumber number)
        {

            
            string insertStringParam = @"INSERT INTO [PhoneNumber] (PhoneNumber, type, PersonID, PhnCompanyID)
                                                    OUTPUT INSERTED.PhnNumberID  
                                                    VALUES (@PhoneNumber, @type, @PersonID, @PhnCompanyID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@PhoneNumber", number.PhoneNumber);
                cmd.Parameters.AddWithValue("@type", number.type);
                cmd.Parameters.AddWithValue("@PersonID", number.Person.PersonId);
                cmd.Parameters.AddWithValue("@PhnCompanyID", number.PhoneCompany.PhoneCompanyID);


                number.PhoneNumberID = (long)cmd.ExecuteScalar();
            }
        }

        // All Get methods for phonenumbers are going to set the PhoneCompany ref to the right project.
        // The Person reference, will only consist of a default person object with a correct personID.

        

        public void GetPhonenumberById(ref Phonenumber number)
        {
            string selectString = @"SELECT  FROM PhoneNumber WHERE (PhnNumberID = @PhnNumberID)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PhneNumberID", number.PhoneNumberID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();


                if (rdr.Read())
                {

                    number.PhoneNumberID = (long) rdr["PhnNumberID"];
                    number.PhoneNumber = (string) rdr["PhoneNumber"];
                    number.type = (string) rdr["type"];
                    currentPerson.PersonId = (long) rdr["PersonID"];
                    currentPhoneCompany.PhoneCompanyID = (long) rdr["PhnCompanyID"];
                }

                GetPhoneCompanyById(ref currentPhoneCompany);
                number.Person = currentPerson;
                number.PhoneCompany = currentPhoneCompany;
            }
        }


        

        public void GetPhonnumberByNumber(ref Phonenumber number)
        {
            string selectString = @"SELECT  TOP 1 * FROM PhoneNumber WHERE (PhnNumber = @phnnumber)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@phnnumber", number.PhoneNumber);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    number.PhoneNumberID = (long) rdr["PhnNumberID"];

                    number.PhoneNumber = (string)rdr["PhoneNumber"];
                    number.type = (string)rdr["type"];
                    currentPerson.PersonId = (long)rdr["PersonID"];
                    currentPhoneCompany.PhoneCompanyID = (long)rdr["PhnCompanyID"];



                }

                GetPhoneCompanyById(ref currentPhoneCompany);
                number.Person = currentPerson;
                number.PhoneCompany = currentPhoneCompany;
            }   

        }


        
        public List<Phonenumber> GetAllOfAPersonsPhonenumbers(ref Person person)
        {

            string selectPhonenumbersString =
                @"SELECT * FROM   Person INNER JOIN
                           PhoneNumber ON Person.PersonID = PhoneNumber.PersonID LEFT OUTER JOIN
                           PhoneCompany ON PhoneNumber.PhnCompanyID = PhoneCompany.PhnCompanyID
                    WHERE (PhoneNumber.PersonID = @PersonID)";

            using (var cmd = new SqlCommand(selectPhonenumbersString, OpenConnection))
            {
                SqlDataReader rdr = null;
                cmd.Parameters.AddWithValue("@PersonID", person.PersonId);
                rdr = cmd.ExecuteReader();

                List<Phonenumber> numbers = new List<Phonenumber>();
                Phonenumber number = null;
                while (rdr.Read())
                {
                    number = new Phonenumber();
                    Person person_ = new Person();
                    number.Person = person_;
                    number.Person.PersonId = (long) rdr["PersonID"];
                    number.PhoneNumberID = (long) rdr["PhnNumberID"];
                    number.PhoneNumber = (string) rdr["PhoneNumber"];
                    number.type = (string) rdr["type"];
                    if (!rdr.IsDBNull(4))
                    {
                        PhoneCompany company = new PhoneCompany();
                        number.PhoneCompany = company;
                        company.PhoneCompanyID = (long) rdr["PhnCompanyID"];
                        company.CompanyName = (string) rdr["CompanyName"];
                        
                    }
                    else
                    {
                        number.PhoneCompany = null;
                    }

                    numbers.Add(number);
                }

                return numbers;

            }

        }

        
        public void DeletePhonenumber(ref Phonenumber number)
        {
            string deleteString = @"DELETE FROM PhoneNumber WHERE (PhnNumberID = @PhnNumberID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PhnNumberID", number.PhoneNumberID);

                var id = (long)cmd.ExecuteNonQuery();
                number = null;
            }
        }

        
        public void UpdatePhoneNumber(ref Phonenumber number)
        {
            string updateString =
                @"UPDATE PhoneNumber                 
                        SET PhoneNumber= @PhoneNumber, type = @type 
                        WHERE PhnNumberID = @PhnNumberID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PhnNumberID", number.PhoneNumberID);
                cmd.Parameters.AddWithValue("@PhoneNumber", number.PhoneNumber);
                cmd.Parameters.AddWithValue("@type", number.type);

                var id = (int)cmd.ExecuteNonQuery();
            }

        }

        //--------------- EmailAddress CRUD OPS-----------------------------------------


        public void AddEmailAddress(ref EmailAddress email)
        {


            string insertStringParam = @"INSERT INTO [EmailAddress] (Email, PersonID)
                                                    OUTPUT INSERTED.EmailID  
                                                    VALUES (@Email, @PersonID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@Email", email.Email);
                cmd.Parameters.AddWithValue("@PersonID", email.Person.PersonId);
                email.EmailAddressID = (long)cmd.ExecuteScalar();
            }
        }


        public void GetEmailAddressById(ref EmailAddress email)
        {
            string selectString = @"SELECT * FROM EmailAddress WHERE (EmailID = @EmailID)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@EmailID", email.EmailAddressID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();


                if (rdr.Read())
                {

                    email.EmailAddressID = (long)rdr["EmailID"];
                    email.Email = (string)rdr["Email"];
                    email.Person.PersonId = (long)rdr["PersonID"];


                }
            }
        }
        
        public void GetEmailAddressByAddress(ref EmailAddress email)
        {
            string selectString = @"SELECT  TOP 1 * FROM EmailAddress WHERE (Email = @email)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@email", email.Email);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    email.EmailAddressID = (long)rdr["EmailID"];
                    email.Email = (string)rdr["Email"];
                    email.Person.PersonId = (long)rdr["PersonID"];


                }
            }
        }

        
        public void DeleteEmailAddress(ref EmailAddress email)
        {
            string deleteString = @"DELETE FROM EmailAddress WHERE (EmailID = @EmailID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@EmailID", email.EmailAddressID);

                var id = (long)cmd.ExecuteNonQuery();
                email = null;
            }
        }

        
        public void UpdateEmailAddress(ref EmailAddress email)
        {
            string updateString =
                @"UPDATE EmailAddress                 
                        SET Email= @Email   
                        WHERE EmailID = @EmailID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@Email", email.Email);
                cmd.Parameters.AddWithValue("@EmailID", email.EmailAddressID);

                var id = (long)cmd.ExecuteNonQuery();
            }

        }

        
        public List<EmailAddress> GetAPersonsEmailList(ref Person person)
        {

            string selectString =
                @"SELECT * FROM   EmailAddress INNER JOIN
                        Person ON EmailAddress.PersonID = Person.PersonID
                  WHERE (EmailAddress.PersonID = @PersonID)";

            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                SqlDataReader rdr = null;
                cmd.Parameters.AddWithValue("@PersonID", person.PersonId);
                rdr = cmd.ExecuteReader();

                List<EmailAddress> emailsAddresses = new List<EmailAddress>();
                EmailAddress email = null;
                while (rdr.Read())
                {
                    email = new EmailAddress();
                    email.Person.PersonId = (long)rdr["PersonID"];
                    email.EmailAddressID= (long)rdr["EmailID"];
                    email.Email = (string) rdr["Email"];

                    emailsAddresses.Add(email);
                }

                return emailsAddresses;

            }

        }


        //--------------- Notes CRUD OPS-----------------------------------------


        
        public void AddNote(ref Note note)
            {


            string insertStringParam = @"INSERT INTO [Note] (NoteText, PersonID)
                                                    OUTPUT INSERTED.NoteID
                                                    VALUES (@NoteText, @PersonID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@NoteText", note.NoteText);
                cmd.Parameters.AddWithValue("@PersonID", note.Person.PersonId);
                note.NoteID = (long)cmd.ExecuteScalar();
            }
        }

        
        public void GeNoteById(ref Note note)
        {
            string selectString = @"SELECT * FROM Note WHERE (NoteID = @NoteID)";
            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@NoteID", note.NoteID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();


                if (rdr.Read())
                {

                    note.NoteID = (long) rdr["NoteID"];
                    note.NoteText = (string) rdr["NoteText"];
                    note.Person.PersonId = (long) rdr["PersonID"];


                }
            }
        }

       
        public void DeleteNote(ref Note note)
        {
            string deleteString = @"DELETE FROM Note WHERE (NoteID = @NoteID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@NoteID", note.NoteID);

                var id = (long)cmd.ExecuteNonQuery();
                note = null;
            }
        }

       
        public void UpdateNote(ref Note note)
        {
            string updateString =
                @"UPDATE Note                 
                        SET NoteText= @NoteText  
                        WHERE NoteID = @NoteID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@NoteText", note.NoteText);
                cmd.Parameters.AddWithValue("@NoteID", note.NoteID);

                var id = (long)cmd.ExecuteNonQuery();
            }

        }

        
        public List<Note> GetAllOfAPersonsNotes(ref Person person)
        {

            string selectString =
                @"SELECT * FROM   Note INNER JOIN
                        Person ON Note.PersonID = Person.PersonID
                  WHERE (Note.PersonID = @PersonID)";

            using (var cmd = new SqlCommand(selectString, OpenConnection))
            {
                SqlDataReader rdr = null;
                cmd.Parameters.AddWithValue("@PersonID", person.PersonId);
                rdr = cmd.ExecuteReader();

                List<Note> notes = new List<Note>();
                Note note  = null;
                while (rdr.Read())
                {
                    note = new Note();
                    note.Person.PersonId = (long)rdr["PersonID"];
                    note.NoteID= (long)rdr["NoteID"];
                    note.NoteText = (string) rdr["NoteText"];

                    notes.Add(note);
                }

                return notes;

            }

        }

        //--- ALL THE DELETE FULL TABLE COMMANDS ----
        public void DeleteALLDataFromCountry()
        {

            string sqlTrunc = "DELETE FROM Country";
            SqlCommand cmd = new SqlCommand(sqlTrunc, OpenConnection);
            cmd.ExecuteNonQuery();

        }

        public void DeleteALLDataFromCity()
        {

            string sqlTrunc = "DELETE FROM City";
            SqlCommand cmd = new SqlCommand(sqlTrunc, OpenConnection);
            cmd.ExecuteNonQuery();

        }

        public void DeleteALLDataFromAddress()
        {

            string sqlTrunc = "DELETE FROM Address";
            SqlCommand cmd = new SqlCommand(sqlTrunc, OpenConnection);
            cmd.ExecuteNonQuery();

        }

        public void DeleteALLDataFromAlternativeAddress()
        {

            string sqlTrunc = "DELETE FROM Alternative_Address";
            SqlCommand cmd = new SqlCommand(sqlTrunc, OpenConnection);
            cmd.ExecuteNonQuery();

        }

        public void DeleteALLDataFromPerson()
        {

            string sqlTrunc = "DELETE FROM Person";
            SqlCommand cmd = new SqlCommand(sqlTrunc, OpenConnection);
            cmd.ExecuteNonQuery();

        }

        public void DeleteALLDataFromPhoneNumber()
        {

            string sqlTrunc = "DELETE FROM PhoneNumber";
            SqlCommand cmd = new SqlCommand(sqlTrunc, OpenConnection);
            cmd.ExecuteNonQuery();

        }

        public void DeleteALLDataFromPhoneCompany()
        {

            string sqlTrunc = "DELETE FROM PhoneCompany";
            SqlCommand cmd = new SqlCommand(sqlTrunc, OpenConnection);
            cmd.ExecuteNonQuery();

        }

        public void DeleteALLDataFromEmailAddress()
        {

            string sqlTrunc = "DELETE FROM EmailAddress";
            SqlCommand cmd = new SqlCommand(sqlTrunc, OpenConnection);
            cmd.ExecuteNonQuery();

        }

        public void DeleteALLDataFromNote()
        {

            string sqlTrunc = "DELETE FROM Note";
            SqlCommand cmd = new SqlCommand(sqlTrunc, OpenConnection);
            cmd.ExecuteNonQuery();

        }

        public void CleanDatabase()
        {
            DeleteALLDataFromEmailAddress();
            DeleteALLDataFromNote();
            DeleteALLDataFromPhoneNumber();
            DeleteALLDataFromPhoneCompany();
            DeleteALLDataFromAlternativeAddress();
            DeleteALLDataFromPerson();
            DeleteALLDataFromAddress();
            DeleteALLDataFromCity();
            DeleteALLDataFromCountry();















































































































































































        }
    }
}
