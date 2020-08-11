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
    public partial class UserControlCentreAjouter : UserControl
    {
        Globale G = new Globale();
        public UserControlCentreAjouter()
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
                    G.Commande.CommandText = "insert into Centre  values ('"+bunifuMetroTextbox1.Text+"')";
                    G.Commande.ExecuteNonQuery();
                    MessageBox.Show("vous avez ajouter un centre de formation");
                    bunifuMetroTextbox1.Text = "";
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
            else {
                MessageBox.Show("Vous devez remplir tout les champs ");
            }
            
        }
    }
}
