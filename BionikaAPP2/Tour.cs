using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BionikaAPP2
{
    class Tour
    {
        public static Random rng = new Random();
        public List<City> tour = new List<City>();
        public Tour[] miasta;
        double fitness = 0;
        int distance = 0;
        public Tour() //inicjalizacja przestrzeni
        {
            for (int i = 0; i < cityCollection.numberofCities(); i++)
            {
                tour.Add(null);
            }
        }
        public Tour(List<City> tour)
        {
            this.tour = tour;

        }
        public City getCity(int position)
        {
          
            return tour[position];
        }
        public void setCity(int position, City city)
        {
            this.tour[position] = city;
            this.fitness = 0;
            this.distance = 0;
        }
        public void generateIndividual()//Tworzenie miast
        {
            for (int cityIndex = 0; cityIndex < cityCollection.numberofCities(); cityIndex++)
            {
                setCity(cityIndex, cityCollection.getCity(cityIndex));

            }
            tour = tour.OrderBy(item => rng.Next()).ToList();
        }
        public int getDistance()
        {
            if (distance == 0)
            {
                int tourDistance = 0;
                for (int i = 0; i < tourSize(); i++)
                {
                    City fromCity = getCity(i);
                    City destinationCity;
                    if (i + 1 < tourSize())
                    {
                        destinationCity = getCity(i + 1);
                    }
                    else
                    {
                        destinationCity = getCity(0);
                    }
                    tourDistance += fromCity.distance(destinationCity);
                }
                distance = tourDistance;
            }
            return distance;
        }
        public int tourSize()
        {
            return tour.Count;
        }
        public double getFitness()
        {
            if (fitness == 0)
            {
                fitness = 1 / (double)getDistance();
            }
            return fitness;
        }
        public bool containsCity(City city)
        {
            return tour.Contains(city);
        }
        public override string ToString()
        {
            string geneString = "|";
            for (int i = 0; i < tourSize(); i++)
            {
                geneString += getCity(i) + "|";
            }
            return geneString;
        }
      
    }
}
