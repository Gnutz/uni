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
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonCatalogueDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
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


        //--------------- Address CRUD OPS-----------------------------------------

        public void AddAlternativeAddress(ref AlternativeAddress aaddress)
        {


            string insertStringParam = @"INSERT INTO [Alternative] (type, PersonID, AddressID)
                                                    OUTPUT INSERTED.pk_Alternative_Address 
                                                    VALUES (@type, @PersonID, @AddressID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {

                cmd.Parameters.AddWithValue("@type", aaddress.Type);
                cmd.Parameters.AddWithValue("@PersonID", aaddress.Person.PersonId);
                cmd.Parameters.AddWithValue("@AddressID", aaddress.Address.AddressID);
             }
        }

        //--------------- Address CRUD OPS-----------------------------------------

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
                    currentAddress.AddressID = (long)rdr["PrimaryAddress"];


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
                        SET FirstName = @FirstName, MiddleName = @MiddleName, SurName = @Surname,
                        WHERE PersonId = @PersonId";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PersonId", person.PersonId);
                cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", person.MiddleName);
                cmd.Parameters.AddWithValue("@Surnmame", person.Surname);


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

        public void GetPhoneCompanyId(ref PhoneCompany company)
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

                cmd.Parameters.AddWithValue("@@PhoneNumber", number.PhoneNumber);
                cmd.Parameters.AddWithValue("@type", number.type);
                cmd.Parameters.AddWithValue("@PersonID", number.Person.PersonId);
                cmd.Parameters.AddWithValue("@PhnCompanyID", number.PhoneCompany.PhoneCompanyID);


                number.PhoneNumberID = (long)cmd.ExecuteScalar();
            }
        }

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

                    number.PhoneNumberID = (long)rdr["PhnNumberID"];
                    number.PhoneNumber = (string)rdr["PhoneNumber"];
                    number.type = (string)rdr["type"];
                    currentPerson.PersonId = (long)rdr["PersonID"];
                    currentPhoneCompany.PhoneCompanyID = (long)rdr["PhnCompanyID"];



                }

                GetPersonById(ref currentPerson);
                GetPhoneCompanyId(ref currentPhoneCompany);
                number.Person = currentPerson;
                number.PhoneCompany = currentPhoneCompany;
            }
        }

        /*
        public List<Phonenumber> GetAllOfAPersonsPhonenumbers(ref Person person)
        {
            string selectPhoneNumbersString = @"SELECT PhoneNumber.PhnNumberID, PhoneNumber.PhoneNumber, PhoneNumber.type, PhoneCompany.PhnCompanyID,
                                              PhoneCompany.CompanyName
                                                  FROM Person INNER JOIN PhoneNumber ON Person.PersonID = PhoneNumber.PersonID
                                                  INNER JOIN PhoneCompany ON PhoneNumber.PhnCompanyID = PhoneCompany.PhnCompanyID
                                                  WHERE (PersonID = @PersonId)";

            using (var cmd = new SqlCommand(selectPhoneNumbersString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@PersonID", person.PersonId);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                var prsncCunt = 0;
                var phnNoCount = 0;
                var phnCoCount = 0;
                long personID = 0;
                long phnNoID = 0;
                Person prsn = new Person();
                Phonenumber phonenum = null;
                prsn.PhoneNumbers = new List<Phonenumber> { };
                while (rdr.Read())
                {
                   

                    }
                }
            }

        } */

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

                    number.PhoneNumberID = (long)rdr["PhnNumberID"];
                    number.PhoneNumber = (string)rdr["PhoneNumber"];
                    number.type = (string)rdr["type"];
                    currentPerson.PersonId = (long)rdr["PersonID"];
                    currentPhoneCompany.PhoneCompanyID = (long)rdr["PhnCompanyID"];



                }

                GetPersonById(ref currentPerson);
                GetPhoneCompanyId(ref currentPhoneCompany);
                number.Person = currentPerson;
                number.PhoneCompany = currentPhoneCompany;


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

    }

}
