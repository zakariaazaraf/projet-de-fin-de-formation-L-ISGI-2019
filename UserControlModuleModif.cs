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
    public partial class UserControlModuleModif : UserControl
    {
        Globale G = new Globale();
        public UserControlModuleModif()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "update Module set NomModule='"+bunifuMetroTextbox1.Text+"' where IdModule ="+bunifuDropdown2.selectedValue;
                G.Commande.ExecuteNonQuery();
                MessageBox.Show("vous avez modifier ce module ");
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

        private void UserControlModuleModif_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdModule from Module";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuDropdown2.Items.Add(G.ObjetReader[0]);
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

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomModule from Module where IdModule ="+bunifuDropdown2.selectedValue;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuMetroTextbox1.Text = G.ObjetReader[0].ToString();
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
    }
}
