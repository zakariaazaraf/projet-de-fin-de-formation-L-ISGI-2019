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
    public partial class UserControlCentreModifier : UserControl
    {
        Globale G = new Globale();
        public UserControlCentreModifier()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text != "")
            {
                try
                {
                    G.Connecter();
                    G.Commande.CommandText = "Update Centre set NomCentreFormation =" + bunifuDropdown2.selectedValue;
                    G.Commande.ExecuteNonQuery();
                    MessageBox.Show("vous avez Modifier un centre de formation");
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
            else
            {
                MessageBox.Show("Vous devez remplir tout les champs ");
            }
        }

        private void UserControlCentreModifier_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdCentreFormation from Centre";
                G.ObjetReader = G.Commande.ExecuteReader();
                while(G.ObjetReader.Read()){
                    bunifuDropdown2.Items.Add(G.ObjetReader[0]);
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

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomCentreFormation from Centre where IdCentreFormation ="+bunifuDropdown2.selectedValue;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuMetroTextbox1.Text = G.ObjetReader[0].ToString();
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
