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
    public partial class UserControlFormateurAjout : UserControl
    {
        Globale G = new Globale();
        public UserControlFormateurAjout()
        {
            InitializeComponent();
        }

        private void UserControlFormateurAjout_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdModule from Module";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuDropdown1.Items.Add(G.ObjetReader[0]);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("L'erreur suivante a été rencontré " + EX.Message);
            }
            finally
            {
                G.Déconnecter();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "insert into Formateur values('" + bunifuMetroTextbox1.Text + "','" + bunifuMetroTextbox2.Text + "','" + bunifuMetroTextbox3.Text + "',"+bunifuDropdown1.selectedValue+")";
                G.Commande.ExecuteNonQuery();
                MessageBox.Show("Vous avez ajouter un formateur");
            }
            catch (Exception EX)
            {
                MessageBox.Show("L'erreur suivante a été rencontré " + EX.Message);
            }
            finally
            {
                G.Déconnecter();
            }
        }
    }
}
