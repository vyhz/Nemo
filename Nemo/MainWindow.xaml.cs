using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Nemo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<clients> lesClients = new List<clients>();
        public MainWindow()
        {
            InitializeComponent();

            clients unclient = new clients (1 , "smith" , "zeub", "4");
            clients deuxclient = new clients(2, "grrrr", "que", "2");
            clients troisclient = new clients(5, "gne", "zeub", "3");
            clients quatreclient = new clients(3, "quoicoube", "suuuuui", "1");

            lesClients.Add(unclient);
            lesClients.Add(deuxclient);
            lesClients.Add(quatreclient);
            lesClients.Add(troisclient);


            //Console.WriteLine("Client 1 :" + unclient.Id + " ; " + unclient.Nom + " ; " + unclient.Prenom
            //    + " ; " + unclient.Niveau);
            //Console.WriteLine("Client 1 :" + deuxclient.Id + " ; " + deuxclient.Nom + " ; " + deuxclient.Prenom
            // + " ; " + deuxclient.Niveau);
            //Console.WriteLine("Client 1 :" + troisclient.Id + " ; " + troisclient.Nom + " ; " + troisclient.Prenom
            //+ " ; " + troisclient.Niveau);
            //Console.WriteLine("Client 1 :" + quatreclient.Id + " ; " + quatreclient.Nom + " ; " + quatreclient.Prenom
            // + " ; " + quatreclient.Niveau);

            dtgClients.ItemsSource= lesClients;
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clients selectClients = dtgClients.SelectedItem as clients;


        }
    } 
}
