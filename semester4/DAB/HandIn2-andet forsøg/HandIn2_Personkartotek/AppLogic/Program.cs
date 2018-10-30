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

        static void PressToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            DBUtility util = new DBUtility();

            Console.WriteLine("This is a test of the CRUD Operation of PersonCatalogueDB");

            //Test Add Country
            Country country1 = new Country();
            Country country2 = new Country();

            country1.CountryName = "Country 1";
            country1.CountryCode = "Code 1";
            country2.CountryName = "Country 2";
            country2.CountryCode = "Code 2";

            util.AddCountry(ref country1);
            util.AddCountry(ref country2);
            util.GetCountryByName(ref country1);
            util.GetCountryByName(ref country2);

            Console.WriteLine("Two Countries in database now");
            PressToContinue();

            //Test Add City
            City city1 = new City();
            City city2 = new City();
            City city3 = new City();

            city1.CityName = "City 1";
            city1.ZipCode = "Code 1";
            city1.Country = country2;
            city2.CityName = "City 2";
            city2.ZipCode = "Code 2";
            city2.Country = country2;
            city3.CityName = "City 3";
            city3.ZipCode = "Code 3";
            city3.Country = country2;


            util.AddCity(ref city1);
            util.AddCity(ref city2);
            util.AddCity(ref city3);
            util.GetCityByName(ref city1);
            util.GetCityByName(ref city2);
            util.GetCityByName(ref city3);

            Console.WriteLine("Three Cities in database now");
            PressToContinue();
            

            //Test Add Address
            Address addr1 = new Address();
            Address addr2 = new Address();
            Address addr3 = new Address();

            addr1.Street = "street 1";
            addr1.HouseNumber = " num 1";
            addr1.City = city2;
            addr2.Street = "steet 2";
            addr2.HouseNumber = " num 2";
            addr2.City = city2;
            addr3.Street = "steet 3";
            addr3.HouseNumber = " num 3";
            addr3.City = city2;

            
            util.AddAddress(ref addr1);
            util.AddAddress(ref addr2);
            util.AddAddress(ref addr3);

            Console.WriteLine("Three Addresses in the database now");
            PressToContinue();
           
            
            Person pers1 = new Person();
            pers1.FirstName = "FirstName1";
            pers1.MiddleName = "MiddleName1";
            pers1.Surname = "SurName1";
            pers1.PrimaryAddress = addr1;

            util.AddPerson(ref pers1);

            Console.WriteLine("A Person has been added to the database");
            PressToContinue();
            Console.Write("This is the person:"); 
            pers1.print();


            pers1.FirstName = " new FirstName";
            pers1.MiddleName = "new MiddleName";
            pers1.Surname = " new SurName";

            util.UpdatePerson(ref pers1);

            Console.WriteLine("Person has been updated:");
            pers1.print();

            pers1.PrimaryAddress = addr2;
            Address primAddr = pers1.PrimaryAddress;
            util.GetAddressById(ref primAddr);
            PressToContinue();
            primAddr.Street = "new street";
            primAddr.HouseNumber = "new number";
            util.UpdateAddress(ref primAddr);
            

            Console.WriteLine("pers1's Primary Address has been changed on the database");
            PressToContinue();


            AlternativeAddress altAddr1 = new AlternativeAddress();
            AlternativeAddress altAddr2 = new AlternativeAddress();

            altAddr1.Person = pers1;
            altAddr1.AddressID = addr1.AddressID;
            altAddr1.Type = "type1";
            altAddr2.Person = pers1;
            altAddr2.Type = "type2";
            altAddr2.AddressID = addr3.AddressID;

            util.AddAltAddress(ref altAddr1);
            util.AddAltAddress(ref altAddr2);

            Console.WriteLine("Two Alternative Adddresses are added to the database for pers1");
            Console.WriteLine("The Insert function doesnt work, plase manually insert two Alternative Addresses");
            PressToContinue();

            Person pers2 = new Person();
            pers2.PersonId = pers1.PersonId;
            pers2.AlternativeAddresses = util.GetAllOfAPersonsAltAddresses(ref pers2);
            PressToContinue();












        }
    }
}
