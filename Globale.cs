using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;



namespace ProjetDuStage
{
    class Globale
    {
        public SqlConnection Connexion = new SqlConnection();
        public SqlConnection Connexion1 = new SqlConnection();
        public SqlCommand Commande = new SqlCommand();
        public SqlCommand Commande1 = new SqlCommand(); 
        public SqlDataReader ObjetReader;
        //public SqlDataReader ObjetReader1;
             
        public void Connecter()
        {
            if (Connexion.State == ConnectionState.Closed || Connexion.State == ConnectionState.Broken)
            {
                Connexion.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog='DBFormationMos';Integrated Security=True";
                Connexion.Open();
                Commande.CommandType = CommandType.Text;
                Commande.Connection = Connexion;
            }
        }
        
        public void Déconnecter()
        {
            if (Connexion.State == ConnectionState.Open)
            {
                Connexion.Close();
            }
        }
        public void ConnecterAux()
        {
            if (Connexion1.State == ConnectionState.Closed || Connexion1.State == ConnectionState.Broken)
            {
                Connexion1.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog='DBFormationMos';Integrated Security=True";
                Connexion1.Open();
                Commande1.CommandType = CommandType.Text;
                Commande1.Connection = Connexion1;
            }
        }

        public void DéconnecterAux()
        {
            if (Connexion1.State == ConnectionState.Open)
            {
                Connexion1.Close();
            }
        }
        

        
    }
}
