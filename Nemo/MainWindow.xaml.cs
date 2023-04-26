using MySqlX.XDevAPI;
using Nemo.classe;
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
        double sexe;
        List<clients> LesClients = bdd.SelectClient();
        public MainWindow()
        {
            InitializeComponent();


            dtgClients.ItemsSource = LesClients;

            if( BoxHomme.IsChecked == true)
            {
                sexe = 1;
            }
            if (BoxHomme.IsChecked == true)
            {
                sexe = 0;
            }


            //clients unclient = new clients (1 , "smith" , "zeub", "4");
            //clients deuxclient = new clients(2, "grrrr", "que", "2");
            //clients troisclient = new clients(5, "gne", "zeub", "3");
            //clients quatreclient = new clients(3, "quoicoube", "suuuuui", "1");

                //lesClients.Add(unclient);
                //lesClients.Add(deuxclient);
                //lesClients.Add(quatreclient);
                //lesClients.Add(troisclient);


                //Console.WriteLine("Client 1 :" + unclient.Id + " ; " + unclient.Nom + " ; " + unclient.Prenom
                //    + " ; " + unclient.Niveau);
                //Console.WriteLine("Client 1 :" + deuxclient.Id + " ; " + deuxclient.Nom + " ; " + deuxclient.Prenom
                // + " ; " + deuxclient.Niveau);
                //Console.WriteLine("Client 1 :" + troisclient.Id + " ; " + troisclient.Nom + " ; " + troisclient.Prenom
                //+ " ; " + troisclient.Niveau);
                //Console.WriteLine("Client 1 :" + quatreclient.Id + " ; " + quatreclient.Nom + " ; " + quatreclient.Prenom
                // + " ; " + quatreclient.Niveau);

                // dtgClients.ItemsSource= lesClients;
        }

        private void dtgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clients SelectClient = dtgClients.SelectedItem as clients;

            //txtNomCli.Text = Convert.ToString(SelectClient.NomCli);
            //dpDateBouclageMagazine.Text = Convert.ToString(selectedMagazine.DateBouclageMagazine);
            //dpDateSortieMagazine.Text = Convert.ToString(selectedMagazine.DateSortieMagazine);
            //dpDatePaimentMagazine.Text = Convert.ToString(selectedMagazine.DatePaimentMagazine);

        }

        private void BoxHomme_Checked(object sender, RoutedEventArgs e)
        {
            sexe = 1;

            if (BoxFemme.IsChecked == true)
            {
                BoxHomme.IsChecked = false; // Décoche la deuxième case à cocher si la première est cochée
            }
            else
            {
                BoxHomme.IsChecked = true;
            }
        }

        private void BoxFemme_Checked(object sender, RoutedEventArgs e)
        {
            sexe = 0;

            if (BoxHomme.IsChecked == true)
            {
                BoxFemme.IsChecked = false; // Décoche la deuxième case à cocher si la première est cochée
            }
            else
            {
                BoxFemme.IsChecked = true;
            }
        }

        private void BtnEnvoyerID_Click(object sender, RoutedEventArgs e)
        {
            bdd.InsertClient(TextNom.Text, TextPrenom.Text, Convert.ToString(cboNiveau.SelectionBoxItem), sexe );
            this.Close();
        }

    } 
}
