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
    public partial class UserControlFormateurModif : UserControl
    {
        Globale G = new Globale();
        public UserControlFormateurModif()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void UserControlFormateurModif_Load(object sender, EventArgs e)
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

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomFormateur,PrénomFormateur,TéléFormateur,NomModule from Formateur F join Module M on M.IdModule=F.IdFormateur where IdFormateur="+bunifuDropdown2.selectedValue;
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
                G.Commande.CommandText = "update Formateur set NomFormateur='" + bunifuMetroTextbox1.Text + "',PrénomFormateur='" + bunifuMetroTextbox2.Text + "',TéléFormateur='" + bunifuMetroTextbox3.Text + "',IdModule=" + bunifuDropdown2.selectedValue +" where IdFormateur ="+bunifuDropdown1.selectedValue;
                G.Commande.ExecuteNonQuery();
                MessageBox.Show("Vous avez Modifier un formateur");
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

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomModule from Module where IdModule="+bunifuDropdown1.selectedValue;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuMetroTextbox4.Text = G.ObjetReader[0].ToString();
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
