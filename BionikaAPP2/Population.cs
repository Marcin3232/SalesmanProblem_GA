using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BionikaAPP2
{
    class Population
    {
        Tour[] tours;
        Tour fittest;
        string miasta;
        List<string> cities;
        public Population(int size, bool initialise)
        {

            tours = new Tour[size];
            if (initialise)
            {
                for (int i = 0; i < populationSize(); i++)
                {
                    Tour newTour = new Tour();
                    newTour.generateIndividual();
                    saveTour(i, newTour);
                }
            }
        }
        public Tour getFittest()
        {
            fittest = tours[0];
            for (int i = 1; i < populationSize(); i++)
            {
                if (fittest.getFitness() <= getTour(i).getFitness())
                {
                    fittest = getTour(i);
                }
            }
            return fittest;
        }

        public Tour getTour(int index)
        {
          
            return tours[index];
        }

        public string getCities(Tour fittest)
        {
            City[] city = fittest.tour.ToArray();
             cities = new List<string>();
            for (int i = 0; i < city.Length; i++)
            {
                cities.Add(city[i].name);
            }
            miasta = string.Join("=>", cities);
            return miasta;
        }

        public void saveTour(int index, Tour tour)
        {
            tours[index] = tour;
        }
        public int populationSize()
        {
            return tours.Length;
        }
    }
}
