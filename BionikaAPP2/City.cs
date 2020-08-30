using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BionikaAPP2
{
    class City
    {
        int x;
        int y;
        public string name;
        public City()
        {
        }
        public City(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;

        }
        // Współrzedne punktów
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public string gCity()
        {
            return this.name;
        }
        //Zliczanie dlugosci drogi
        public int distance(City miasteczko)
        {
            int xDistance = Math.Abs(getX() - miasteczko.getX());
            int yDistance = Math.Abs(getY() - miasteczko.getY());
            double distance = Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
            return Convert.ToInt32(distance);
        }
        public override string ToString()
        {
            return getX() + "." + getY();
        }

     

    }
}
