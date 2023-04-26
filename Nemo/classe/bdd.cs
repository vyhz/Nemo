using InfoToolsV2.Classe;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemo.classe
{
    public abstract class bdd
    {
        private static MySqlConnection conn = DBUtils.GetDBConnection();
        //private static string server;
        //private static string database;
        //private static string uid;
        //private static string password;



        private static bool OpenConnection()
        {
            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

                return false;
            }
        }
        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public static void InsertClient(string nomC, string prenomC, string niveauC, double sexeC)
        {
            //Requête Insertion Magazine
            string query = "INSERT INTO Client (nomCli, prenomCli, niveauCli, sexeCli) VALUES('" + nomC + "','" + prenomC + "','" + niveauC + "'," + sexeC + ")";
            Console.WriteLine(query);

            //open connection
            if (bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                bdd.CloseConnection();
            }
        }

        public static void UpdateClient(int id, string nomC, string prenomC, string niveauC, double sexeC)
        {
            //Update Magazine
            string query = "UPDATE Magazine SET nomCli='" + nomC + "', prenomCli='" + prenomC + "', niveauCli='" + niveauC + "', sexeCli = " + sexeC + " WHERE idCli=" + id;
            Console.WriteLine(query);
            //Open connection
            if (bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = conn;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                bdd.CloseConnection();
            }
        }

        public static void DeleteClient(int IdCli)
        {
            //Delete Magazine
            string query = "DELETE FROM Magazine WHERE NumMagazine=" + IdCli;

            if (bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                bdd.CloseConnection();
            }
        }

        public static List<clients> SelectClient()
        {
            //Select statement
            string query = "SELECT * FROM client";

            //Create a list to store the result
            List<clients> dbClient = new List<clients>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    clients leClient = new clients(Convert.ToInt16(dataReader["IdCli"]), Convert.ToString(dataReader["NomCli"]), Convert.ToString(dataReader["PrenomCli"]), Convert.ToString(dataReader["NiveauCli"]), Convert.ToString(dataReader["sexeCli"]));
                    dbClient.Add(leClient);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
            }
            return dbClient;
        }
    }
}
