using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModelPersonCatalogue;
using Infrastructure;

namespace AppLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            DBUtility util = new DBUtility();

            


            //Test Add Country
            Country country1 = new Country();
            Country country2 = new Country();

            country1.CountryName = "Country 1";
            country1.CountryCode = "Code 1";
            country2.CountryName = "Country 2";
            country2.CountryCode = "Code 2";
            
            util.AddCountry(ref country1);
            util.AddCountry(ref country2);

            // Two Countries in database now

            // Test getCountryByName
            util.GetCountryByName(ref country1);
            //Test Delete Country
            util.DeleteCountry(ref country1);

            //One Country in database now

            //test update Country
            util.GetCountryByName(ref country2); // set ID
            country2.CountryName = "Country1";
            country2.CountryCode = "Code 1";
            util.UpdateCountry(ref country2);

            //Country Updated

            //Test Add City
            City city1 = new City();
            City city2 = new City();

            city1.CityName = "City 1";
            city1.ZipCode = "Code 1";
            city1.Country = country2;
            city2.CityName = "City 2";
            city2.ZipCode = "Code 2";
            city2.Country = country2;

            util.AddCity(ref city1);
            util.AddCity(ref city2);

            // Two Cities in database now

            // Test getCityByName
            util.GetCityByName(ref city1);
            //Test Delete City
            util.DeleteCity(ref city1);

            //One City in database now

            //test update City
            util.GetCityByName(ref city2);
            city2.CityName = "City1";
            city2.ZipCode = "Code 1";
            util.UpdateCity(ref city2);

            //City Updated

            //Test Add Address
            Address addr1 = new Address();
            Address addr2 = new Address();

            addr1.Street = "street 1";
            addr1.HouseNumber = " num 1";
            addr1.City = city2;
            addr2.Street = "steet 2";
            addr2.HouseNumber = " num 2";
            addr2.City = city2;

            util.AddAddress(ref addr1);
            util.AddAddress(ref addr2);

            // Two Addresses in database now

           
          
            //Test Delete Address
            util.DeleteAddress(ref addr1);

            //One address in database now

            //test update Address
            addr2.Street = "Street 1";
            addr2.HouseNumber = "num";
            util.UpdateAddress(ref addr2);

            //Address Updated

            //Test Add Person
            Person pers1 = new Person();
            Person pers2 = new Person();

            pers1.FirstName = "Firstname 1";
            pers1.MiddleName = "MiddleName 1";
            pers1.Surname = "Surname 1";
            pers1.PrimaryAddress = addr2;
            pers2.FirstName = "Firstname 2";
            pers2.MiddleName = "MiddleName 2";
            pers2.Surname = "Surname 2";
            pers2.PrimaryAddress = addr2;

            util.AddPerson(ref pers1);
            util.AddPerson(ref pers2);

            // Two Persons in database now



            //Test Delete Person
            util.DeletePerson(ref pers1);

            //One Person in database now

            //test update Person
            pers2.FirstName = "Firstname 1";
            pers2.MiddleName = "MiddleName 1";
            pers2.Surname = "Surname 1";
            util.UpdatePerson(ref pers2);

            //Address Updated

            Console.ReadLine();







        }
    }
}
