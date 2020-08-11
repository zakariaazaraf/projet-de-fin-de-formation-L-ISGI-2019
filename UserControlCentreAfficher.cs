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
    public partial class UserControlCentreAfficher : UserControl
    {
        Globale G = new Globale();
        public UserControlCentreAfficher()
        {
            InitializeComponent();
        }

        private void UserControlCentreAfficher_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdCentreFormation,NomCentreFormation from Centre";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add(G.ObjetReader[0], G.ObjetReader[1]);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }
        }
    }
}
