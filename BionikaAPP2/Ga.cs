using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows;

namespace BionikaAPP2
{
    class Ga
    {
        public static bool elite = true;
       
        public static Population evolvePopulation(Population pop,double mutationRate,int TournamentSize)//ewolucja populacji - krzyżowaneie osobników z turnieju
        {
            Population newPopulation = new Population(pop.populationSize(), false);
            int elitismOffset = 0;
            if (elite)
            {
                newPopulation.saveTour(0, pop.getFittest());
                elitismOffset = 1;
            }

            for (int i = elitismOffset; i < newPopulation.populationSize(); i++) //
            {
                Tour parent1 = tournamentSelection(pop,TournamentSize);
                Tour parent2 = tournamentSelection(pop,TournamentSize);
                Tour child = crossover(parent1, parent2);
                newPopulation.saveTour(i, child);
            }

            for (int i = elitismOffset; i < newPopulation.populationSize(); i++)
            {
                mutate(newPopulation.getTour(i),mutationRate);
            }

            return newPopulation;
        }
        public static Tour crossover(Tour parent1, Tour parent2)
        {
            Tour child = new Tour();


            int startPos = (int)((Rng() * parent1.tourSize()));
            int endPos = (int)((Rng() * parent1.tourSize()));

            for (int i = 0; i < child.tourSize(); i++)
            {
                if (startPos < endPos && i > startPos && i < endPos)
                {
                    child.setCity(i, parent1.getCity(i));
                } 
                else if (startPos > endPos)
                {
                    if (!(i < startPos && i > endPos))
                    {
                        child.setCity(i, parent1.getCity(i));
                    }
                }
            }

            for (int i = 0; i < parent2.tourSize(); i++)
            {
                if (!child.containsCity(parent2.getCity(i)))
                {
                    for (int ii = 0; ii < child.tourSize(); ii++)
                    {
                        if (child.getCity(ii) == null)
                        {
                            child.setCity(ii, parent2.getCity(i));
                            break;
                        }
                    }
                }
            }
            return child;
        } //Krzyżowanie osobników 

        public static void mutate(Tour tour,double mutationRate)
        {

            for (int tourPos1 = 0; tourPos1 < tour.tourSize(); tourPos1++)
            {

                if ((Rng() < mutationRate))
                {
                    int tourPos2 = (int)(tour.tourSize() * Rng());

                    City city1 = tour.getCity(tourPos1);
                    City city2 = tour.getCity(tourPos2);

                    tour.setCity(tourPos2, city1);
                    tour.setCity(tourPos1, city2);
                }
            }
        }

        public static Tour tournamentSelection(Population pop,int TournamentSize)
        {
            Population tournament = new Population(TournamentSize, false);

            for (int i = 0; i < TournamentSize; i++)
            {

                int randomId = (int)(((Rng() * pop.populationSize())));
                tournament.saveTour(i, pop.getTour(randomId));
            }
            Tour fittest = tournament.getFittest();
            return fittest;
        } //Tworzenie turnieju  i wybieranie losowego osobnika

        public static double Rng()
        {
            Random r = new Random();
            double a = r.NextDouble();
            return a;
        }


    }
}
