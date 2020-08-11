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
    public partial class UserControlFormateurSpp : UserControl
    {
        Globale G = new Globale();
        public UserControlFormateurSpp()
        {
            InitializeComponent();
        }

        private void UserControlFormateurSpp_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdFormateur from Formateur";
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
                G.Commande.CommandText = "select NomFormateur,PrénomFormateur,TéléFormateur,NomModule from Formateur F join Module M on M.IdModule=F.IdFormateur where IdFormateur=" + bunifuDropdown2.selectedValue;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuMetroTextbox1.Text = G.ObjetReader[0].ToString();
                    bunifuMetroTextbox2.Text = G.ObjetReader[1].ToString();
                    bunifuMetroTextbox3.Text = G.ObjetReader[2].ToString();
                    bunifuMetroTextbox4.Text = G.ObjetReader[3].ToString();
                    
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
                G.Commande.CommandText = "delete Formateur where IdFormateur =" + bunifuDropdown2.selectedValue;
                G.Commande.ExecuteNonQuery();
                MessageBox.Show("Vous avez Supprimer un formateur");
                bunifuMetroTextbox1.Text = "";
                bunifuMetroTextbox2.Text = "";
                bunifuMetroTextbox3.Text = "";
                bunifuMetroTextbox4.Text = "";
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
