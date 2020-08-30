using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using LiveCharts.Defaults;

namespace BionikaAPP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point[] points;
        List<double> besttour = new List<double>();
        double mutrate;
        int tournamentsize;
        int generation;
        int populationsize;


        public MainWindow()
        {
            InitializeComponent();
        }


        #region Zmienne texbox
        public double mut()
        {
            double mut = Convert.ToDouble(mutationrate.Text);
            return mut;
        }
        public int Sizetour()
        {
            int siz = Convert.ToInt16(toursize.Text);
            return siz;
        }
        public int GetGeneration()
        {
            int g = Convert.ToInt32(generationBox.Text);
            return g;
        }
        public int PopulationSize()
        {
            int s = Convert.ToInt32(populationBox.Text);
            return s;
        }
        #endregion
        #region plot
        public SeriesCollection series { get; set; }

        public string[] Labels { get; set; }
        ChartValues<double> val1 = new ChartValues<double>();
        public Func<double, string> YFormatter { get; set; }
         public void GeneratePlot(List<double> list,int generation)
        {
            series = new SeriesCollection
            {
                new LineSeries
                {
                    Title="Distance",
                    LineSmoothness=0,
                    StrokeThickness=3,
                    Stroke=new SolidColorBrush(Color.FromRgb(13,38,198)),
                    Fill=new SolidColorBrush(Color.FromArgb(25,0,0,204)),
                    PointForeground=new SolidColorBrush(Color.FromRgb(102,255,255)),  
                    Values=val1
                }

            };
            chart.DataContext = this;
            val1.Clear();
            for(int i = 0; i < besttour.Count; i++)
            {
                double help = besttour[i];
                val1.Add(help);
            }

        }




        #endregion
        public void Drawing()
        {


            Dispatcher.Invoke(() => button.IsEnabled = false);

            Population pop = new Population(populationsize, true);

            List<Tour> lista = new List<Tour>();
            List<int> droga = new List<int>();
            pop = Ga.evolvePopulation(pop, mutrate, tournamentsize);
            firstResult.Dispatcher.Invoke(() => firstResult.Content = "Initial distance: " + pop.getFittest().getDistance());
            for (int i = 0; i < generation; i++)
            {
                pop = Ga.evolvePopulation(pop, mutrate, tournamentsize);
                string Ciag = pop.getFittest().ToString();
                string gene = ("Generation " + Convert.ToString(i) + ": ");
                resultList.Dispatcher.Invoke(() => resultList.Items.Add(gene + pop.getCities(pop.getFittest())));

                besttour.Add(pop.getFittest().getDistance());
                string[] Miasta = Ciag.Split('|');
                string[] MiastaPozycje = new string[Miasta.Length - 2];
                string[] WartosciXY = new string[2];
                int[] x = new int[Miasta.Length - 2];
                int[] y = new int[Miasta.Length - 2];
                points = new Point[Miasta.Length - 1];
                int zmienna = 0;

                for (int j = 1; j < Miasta.Length - 1; j++)
                {
                    MiastaPozycje[zmienna] = Miasta[j];
                    string xy = MiastaPozycje[zmienna];
                    WartosciXY = xy.Split('.');

                    x[zmienna] = Convert.ToInt32(WartosciXY[0]);
                    y[zmienna] = Convert.ToInt32(WartosciXY[1]);
                    points[zmienna] = new Point(x[zmienna], y[zmienna]);
                    zmienna++;
                }
                points[points.Length - 1] = points[0];
                Dispatcher.BeginInvoke(new Action(DrawLine), DispatcherPriority.ApplicationIdle);

                Thread.Sleep(100);
                Dispatcher.BeginInvoke(new Action(() => GeneratePlot(besttour, generation)), DispatcherPriority.ApplicationIdle);
            }

            bestResult.Dispatcher.Invoke(() => bestResult.Content = "Best distance: " + pop.getFittest().getDistance());
            lista = null;
            droga = null;

            Dispatcher.Invoke(() => button.IsEnabled = true);

        }

        public void DrawLine()
        {
            var actualLocation = points[1];
            canvas.Children.Clear();

            foreach (var destination in points)
            {
                var line = new Line();
                int red = 255;
                int blue = 60;
                var color = Color.FromRgb((byte)red, 0, (byte)blue);
                line.Stroke = new SolidColorBrush(color);
                line.X1 = actualLocation.X;
                line.Y1 = actualLocation.Y;
                line.X2 = destination.X;
                line.Y2 = destination.Y;
                canvas.Children.Add(line);
                actualLocation = destination;
                var circle = new Ellipse();
                circle.Name = "a";
                circle.Stroke = Brushes.Black;
                circle.Fill = Brushes.Red;
                circle.Width = 11;
                circle.Height = 11;
                Canvas.SetLeft(circle, destination.X - 5);
                Canvas.SetTop(circle, destination.Y - 5);
                Panel.SetZIndex(circle, 57);
                canvas.Children.Add(circle);
            }


        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            ClearVariable();
            mutrate = mut();
            tournamentsize = Sizetour();
            besttour.Clear();
            generation = GetGeneration();
            populationsize = PopulationSize();
            resultList.Items.Clear();
            try
            {
                if (checkBox.IsChecked == false && checkBox1.IsChecked==false && checkBox2.IsChecked==false && checkBox3.IsChecked == false)
                {
                checkBox.IsChecked = true;
                }
            GenerateCities();
            var thread = new Thread(Drawing);
            thread.Start();
            }
            catch
            {
                MessageBox.Show("Wait to end a programme");
            }
        }

        public void ClearVariable()
        {
            Dispatcher.Invoke(() => bestResult.Content = null);
            points = null;
            mutrate = 0;
            tournamentsize = 0;
            generation = 0;
            populationsize = 0;
            cityCollection.allCities.Clear();
            canvas.Children.Clear();
        }
        public void GenerateCities()
        {
            #region Miasta
            //City city = new City(60, 200);
            //cityCollection.addCity(city);
            //City city2 = new City(180, 200);
            //cityCollection.addCity(city2);
            //City city3 = new City(80, 180);
            //cityCollection.addCity(city3);
            //City city4 = new City(140, 180);
            //cityCollection.addCity(city4);
            //City city5 = new City(20, 160);
            //cityCollection.addCity(city5);
            //City city6 = new City(100, 160);
            //cityCollection.addCity(city6);
            //City city7 = new City(200, 160);
            //cityCollection.addCity(city7);
            //City city8 = new City(140, 140);
            //cityCollection.addCity(city8);
            //City city9 = new City(40, 120);
            //cityCollection.addCity(city9);
            //City city10 = new City(100, 120);
            //cityCollection.addCity(city10);
            //City city11 = new City(180, 100);
            //cityCollection.addCity(city11);
            //City city12 = new City(60, 80);
            //cityCollection.addCity(city12);
            //City city13 = new City(120, 80);
            //cityCollection.addCity(city13);
            //City city14 = new City(180, 60);
            //cityCollection.addCity(city14);
            //City city15 = new City(20, 40);
            //cityCollection.addCity(city15);
            //City city16 = new City(100, 40);
            //cityCollection.addCity(city16);
            //City city17 = new City(200, 40);
            //cityCollection.addCity(city17);
            //City city18 = new City(20, 20);
            //cityCollection.addCity(city18);
            //City city19 = new City(60, 20);
            //cityCollection.addCity(city19);
            //City city20 = new City(160, 20);
            //cityCollection.addCity(city20);
            #endregion

            //Poland
            //City Gdansk = new City(270, 159);
            //cityCollection.addCity(Gdansk);
            //City Warszawa = new City(389, 338);
            //cityCollection.addCity(Warszawa);
            //City Szczecin = new City(60, 226);
            //cityCollection.addCity(Szczecin);
            //City Bydgoszcz = new City(231, 260);
            //cityCollection.addCity(Bydgoszcz);
            //City Poznan = new City(173, 320);
            //cityCollection.addCity(Poznan);
            //City Wroclaw = new City(177, 432);
            //cityCollection.addCity(Wroclaw);
            //City Lodz = new City(310, 377);
            //cityCollection.addCity(Lodz);
            //City Bialystok = new City(500, 258);
            //cityCollection.addCity(Bialystok);
            //City Lublin = new City(475, 421);
            //cityCollection.addCity(Lublin);
            //City Krakow = new City(336, 527);
            //cityCollection.addCity(Krakow);
            //City Katowice = new City(284, 510);
            //cityCollection.addCity(Katowice);
            //City city12 = new City(228, 128);
            //cityCollection.addCity(city12);
            //City city13 = new City(480, 154);
            //cityCollection.addCity(city13);
            //City city14 = new City(460, 237);
            //cityCollection.addCity(city14);
            //City city15 = new City(108, 185);
            //cityCollection.addCity(city15);
            //City city16 = new City(76, 265);
            //cityCollection.addCity(city16);
            //City city17 = new City(153, 259);
            //cityCollection.addCity(city17);
            //City city18 = new City(417, 285);
            //cityCollection.addCity(city18);
            //City city19 = new City(166, 135);
            //cityCollection.addCity(city19);
            //City city20 = new City(542, 450);
            //cityCollection.addCity(city20);
            //City city21 = new City(501, 490);
            //cityCollection.addCity(city21);
            //City city22 = new City(481, 534);
            //cityCollection.addCity(city22);
            //City city23 = new City(143, 449);
            //cityCollection.addCity(city23);
            //City city24 = new City(95, 446);
            //cityCollection.addCity(city24);
            //City city25 = new City(153, 259);
            //cityCollection.addCity(city25);
            //City city26 = new City(65, 324);
            //cityCollection.addCity(city26);
            //City city27 = new City(135, 351);
            //cityCollection.addCity(city27);
            //City city28 = new City(113, 387);
            //cityCollection.addCity(city28);
            //City city29 = new City(62, 441);
            //cityCollection.addCity(city29);
            //City city30 = new City(496, 321);
            //cityCollection.addCity(city30);
            //City city31 = new City(444, 358);
            //cityCollection.addCity(city31);
            //City city32 = new City(516, 206);
            //cityCollection.addCity(city32);
            //City city33 = new City(396, 399);
            //cityCollection.addCity(city33);
            //City city34 = new City(503, 372);
            //cityCollection.addCity(city34);
            //City city35 = new City(472, 592);
            //cityCollection.addCity(city35);
            //City city36 = new City(425, 564);
            //cityCollection.addCity(city36);
            //City city37 = new City(396, 495);
            //cityCollection.addCity(city37);
            //City city38 = new City(346, 456);
            //cityCollection.addCity(city38);
            //City city39 = new City(240, 419);
            //cityCollection.addCity(city39);
            //City city40 = new City(338, 595);
            //cityCollection.addCity(city40);
            //City city41 = new City(329, 449);
            //cityCollection.addCity(city41);
            //City city42 = new City(137, 486);
            //cityCollection.addCity(city42);
            //City city43 = new City(154, 510);
            //cityCollection.addCity(city43);
            //City city44 = new City(168, 482);
            //cityCollection.addCity(city44);
            //City city45 = new City(199, 499);
            //cityCollection.addCity(city45);
            //City city46 = new City(256, 440);
            //cityCollection.addCity(city46);
            //City city47 = new City(232, 350);
            //cityCollection.addCity(city47);
            //City city48 = new City(301, 301);
            //cityCollection.addCity(city48);
            //City city49 = new City(330, 186);
            //cityCollection.addCity(city49);
            //City city50 = new City(403, 218);
            City Gdansk = new City(270, 159, "Gdansk");
            City Warszawa = new City(389, 338, "Warszawa");
            City Szczecin = new City(60, 226, "Szczecin");
            City Bydgoszcz = new City(231, 260, "Bydgoszcz");
            City Poznan = new City(173, 320, "Poznan");
            City Wroclaw = new City(177, 432, "Wroclaw");
            City Lodz = new City(310, 377, "Lodz");
            City Bialystok = new City(500, 258, "Bialystok");
            City Lublin = new City(475, 421, "Lublin");
            City Krakow = new City(336, 527, "Krakow");
            City Katowice = new City(284, 510, "Katowice");
            City city12 = new City(228, 128,"city12");
            City city13 = new City(480, 154, "city13");
            City city14 = new City(460, 237, "city14");
            City city15 = new City(108, 185, "city15");
            City city16 = new City(76, 265, "city16");
            City city17 = new City(153, 259, "city17");
            City city18 = new City(417, 285, "city18");
            City city19 = new City(166, 135, "city19");
            City city20 = new City(542, 450, "city20");
            City city21 = new City(501, 490, "city21");
            City city22 = new City(481, 534, "city22");
            City city23 = new City(143, 449, "city23");
            City city24 = new City(95, 446, "city24");
            City city25 = new City(153, 259, "city25");
            City city26 = new City(65, 324, "city26");
            City city27 = new City(135, 351, "city27");
            City city28 = new City(113, 387, "city28");
            City city29 = new City(62, 441, "city29");
            City city30 = new City(496, 321, "city30");
            City city31 = new City(444, 358, "city31");
            City city32 = new City(516, 206, "city32");
            City city33 = new City(396, 399, "city33");
            City city34 = new City(503, 372, "city34");
            City city35 = new City(472, 592, "city35");
            City city36 = new City(425, 564, "city36");
            City city37 = new City(396, 495, "city37");
            City city38 = new City(346, 456, "city38");
            City city39 = new City(240, 419, "city39");
            City city40 = new City(338, 595, "city40");
            City city41 = new City(329, 449, "city41");
            City city42 = new City(137, 486, "city42");
            City city43 = new City(154, 510, "city43");
            City city44 = new City(168, 482, "city44");
            City city45 = new City(199, 499, "city45");
            City city46 = new City(256, 440, "city46");
            City city47 = new City(232, 350, "city47");
            City city48 = new City(301, 301, "city48");
            City city49 = new City(330, 186, "city49");
            City city50 = new City(403, 218, "city50");

            if (checkBox.IsChecked==true)
            {
                cityCollection.addCity(Gdansk);
                cityCollection.addCity(Warszawa);
                cityCollection.addCity(Szczecin);
                cityCollection.addCity(Bydgoszcz);
                cityCollection.addCity(Poznan);
                cityCollection.addCity(Wroclaw);
                cityCollection.addCity(Lodz);
                cityCollection.addCity(Bialystok);
                cityCollection.addCity(Lublin);
                cityCollection.addCity(Krakow);
                cityCollection.addCity(Katowice);
            }
            if (checkBox1.IsChecked == true)
            {
                cityCollection.addCity(Gdansk);
                cityCollection.addCity(Warszawa);
                cityCollection.addCity(Szczecin);
                cityCollection.addCity(Bydgoszcz);
                cityCollection.addCity(Poznan);
                cityCollection.addCity(Wroclaw);
                cityCollection.addCity(Lodz);
                cityCollection.addCity(Bialystok);
                cityCollection.addCity(Lublin);
                cityCollection.addCity(Krakow);
                cityCollection.addCity(Katowice);
                cityCollection.addCity(city12);
                cityCollection.addCity(city13);
                cityCollection.addCity(city14);
                cityCollection.addCity(city15);
                cityCollection.addCity(city16);
                cityCollection.addCity(city17);
                cityCollection.addCity(city18);
                cityCollection.addCity(city19);
                cityCollection.addCity(city20);
                cityCollection.addCity(city21);
                cityCollection.addCity(city22);
                cityCollection.addCity(city23);
                cityCollection.addCity(city24);
                cityCollection.addCity(city25);
            }
            if (checkBox2.IsChecked == true)
            {
                cityCollection.addCity(Gdansk);
                cityCollection.addCity(Warszawa);
                cityCollection.addCity(Szczecin);
                cityCollection.addCity(Bydgoszcz);
                cityCollection.addCity(Poznan);
                cityCollection.addCity(Wroclaw);
                cityCollection.addCity(Lodz);
                cityCollection.addCity(Bialystok);
                cityCollection.addCity(Lublin);
                cityCollection.addCity(Krakow);
                cityCollection.addCity(Katowice);
                cityCollection.addCity(city12);
                cityCollection.addCity(city13);
                cityCollection.addCity(city14);
                cityCollection.addCity(city15);
                cityCollection.addCity(city16);
                cityCollection.addCity(city17);
                cityCollection.addCity(city18);
                cityCollection.addCity(city19);
                cityCollection.addCity(city20);
                cityCollection.addCity(city21);
                cityCollection.addCity(city22);
                cityCollection.addCity(city23);
                cityCollection.addCity(city24);
                cityCollection.addCity(city25);
                cityCollection.addCity(city26);
                cityCollection.addCity(city27);
                cityCollection.addCity(city28);
                cityCollection.addCity(city29);
                cityCollection.addCity(city30);
            }
            if (checkBox3.IsChecked == true)
            {
                cityCollection.addCity(Gdansk);
                cityCollection.addCity(Warszawa);
                cityCollection.addCity(Szczecin);
                cityCollection.addCity(Bydgoszcz);
                cityCollection.addCity(Poznan);
                cityCollection.addCity(Wroclaw);
                cityCollection.addCity(Lodz);
                cityCollection.addCity(Bialystok);
                cityCollection.addCity(Lublin);
                cityCollection.addCity(Krakow);
                cityCollection.addCity(Katowice);
                cityCollection.addCity(city12);
                cityCollection.addCity(city13);
                cityCollection.addCity(city14);
                cityCollection.addCity(city15);
                cityCollection.addCity(city16);
                cityCollection.addCity(city17);
                cityCollection.addCity(city18);
                cityCollection.addCity(city19);
                cityCollection.addCity(city20);
                cityCollection.addCity(city21);
                cityCollection.addCity(city22);
                cityCollection.addCity(city23);
                cityCollection.addCity(city24);
                cityCollection.addCity(city25);
                cityCollection.addCity(city26);
                cityCollection.addCity(city27);
                cityCollection.addCity(city28);
                cityCollection.addCity(city29);
                cityCollection.addCity(city30);
                cityCollection.addCity(city31);
                cityCollection.addCity(city32);
                cityCollection.addCity(city33);
                cityCollection.addCity(city34);
                cityCollection.addCity(city35);
                cityCollection.addCity(city36);
                cityCollection.addCity(city37);
                cityCollection.addCity(city38);
                cityCollection.addCity(city39);
                cityCollection.addCity(city40);
                cityCollection.addCity(city41);
                cityCollection.addCity(city42);
                cityCollection.addCity(city43);
                cityCollection.addCity(city44);
                cityCollection.addCity(city45);
                cityCollection.addCity(city46);
                cityCollection.addCity(city47);
                cityCollection.addCity(city48);
                cityCollection.addCity(city49);
                cityCollection.addCity(city50);
            }
            //if(checkBox1)

        }

        #region Funkcje przycisków
        // mutation Rate function
        #region mutation Rate
        private void mutationrate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            mutationrate.Text = "0";
        }

        private void mutationrate_MouseEnter(object sender, MouseButtonEventArgs e)
        {
            mutationrate.Text = "";
        }

        private void mutationrate_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void mutationrate_TextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

        #region tournamentSize
        private void toursize_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            toursize.Text = "1";
        }
        private void toursize_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

        #region Generation size
        private void generationBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void generationBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            generationBox.Text = "100";
        }

        #endregion
        #region Population size
        private void populationBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        #endregion

        #region check boxy
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                checkBox1.IsChecked = false;
                checkBox2.IsChecked = false;
                checkBox3.IsChecked = false;
            }
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked == true)
            {
                checkBox.IsChecked = false;
                checkBox2.IsChecked = false;
                checkBox3.IsChecked = false;
            }
        }
        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox2.IsChecked == true)
            {
                checkBox.IsChecked = false;
                checkBox1.IsChecked = false;
                checkBox3.IsChecked = false;
            }
        }
        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox3.IsChecked == true)
            {
                checkBox.IsChecked = false;
                checkBox1.IsChecked = false;
                checkBox2.IsChecked = false;
            }
        }

        #endregion

        #endregion

    }



}
