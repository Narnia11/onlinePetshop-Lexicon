using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class DatabaseCountryRepo: ICountryRepo
    {
        private ExDBContext _DBContext;
        public DatabaseCountryRepo(ExDBContext myDBContext)
        {
            _DBContext = myDBContext;
        }

        public Country CreateCountry(Country country)
        {
            Country p = new Country()
            {

                Name = country.Name,
            };
            _DBContext.Countries.Add(country);
            _DBContext.SaveChanges();
            return country;
        }

        public bool DeleteCountry(Country country)
        {


            var result = _DBContext.Countries.FirstOrDefault(x => x.Id == country.Id);
            if (result != null)
            {
                _DBContext.Countries.Remove(result);
                _DBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Country FindCountry(int id)
        {
            return _DBContext.Countries.FirstOrDefault(x => x.Id == id);

        }

        public List<Country> GetCountries()
        {
            return _DBContext.Countries.ToList();

        }

        public Country SearchCountry(string search)
        {
            return _DBContext.Countries.FirstOrDefault(x => x.Name.ToLower().Contains(search.ToLower()) ||x.Name.Contains(search.ToLower()));

        }
    }
}
