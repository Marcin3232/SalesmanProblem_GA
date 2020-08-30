using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BionikaAPP2
{
    class cityCollection
    {

        public static List<City> allCities = new List<City>();
        // Dodawanie miasta

        public static void addCity(City city)
        {
            allCities.Add(city);
        }

        public static City getCity(int index)
        {

            return allCities[index];
        }
        public static int numberofCities()
        {
            return allCities.Count;
        }

        public void ClearList()
        {
            allCities.Clear();
        }
    }
}
