using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetDuStage
{
    public partial class UserControlUtilisateurAff : UserControl
    {
        Globale G = new Globale();
        public UserControlUtilisateurAff()
        {
            InitializeComponent();
        }

        private void UserControlUtilisateurAff_Load(object sender, EventArgs e)
        {
            try {
                G.Connecter();
                G.Commande.CommandType = CommandType.Text;
                G.Commande.CommandText = "Select PPR,NomUtilisateur,PrénomUtilisateur,Matière,Etablissement,TéléUtilisateur,LoginUtilisateur,PasswordUtilisateur from Utilisateur";
                G.Commande.Connection = G.Connexion;
                G.ObjetReader=G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add(G.ObjetReader[0],G.ObjetReader[1],G.ObjetReader[2],G.ObjetReader[3],G.ObjetReader[4],G.ObjetReader[5],G.ObjetReader[6],G.ObjetReader[7]);
                }
            }catch(Exception Ex){
                MessageBox.Show("l'erreur suivante à éte rencontré AACC "+Ex.Message);

            }finally{
                G.Déconnecter();
            }

        }
    }
}
