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
    public partial class UserControlFormationSuppModule : UserControl
    {
        Globale G = new Globale();
        public UserControlFormationSuppModule()
        {
            InitializeComponent();
        }

        private void UserControlFormationSuppModule_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                //vous dever penser de developpé cette requette
                G.Commande.CommandText = "select IdFormation from Formation";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuDropdown1.Items.Add(G.ObjetReader[0]);
                    
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

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select DébutFormation,FinFormation from Formation where IdFormation = '" + bunifuDropdown1.selectedValue + "'";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuDatepicker1.Value = DateTime.Parse(G.ObjetReader[0].ToString());
                    bunifuDatepicker2.Value = DateTime.Parse(G.ObjetReader[1].ToString());

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
            bunifuDropdown2.Clear();
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdModule from Module where IdModule in (select IdModule from Avoir where IdFormation =" + bunifuDropdown1.selectedValue + ")";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    
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
                G.Commande.CommandText = "select NomModule from Module where IdModule = '" + bunifuDropdown2.selectedValue + "'";
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
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select Horaire from Avoir where IdModule ="+bunifuDropdown2.selectedValue+" and IdFormation =" + bunifuDropdown1.selectedValue ;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuMetroTextbox2.Text = G.ObjetReader[0].ToString();
                    
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "delete Avoir where IdFormation=" + bunifuDropdown1.selectedValue + "and IdModule=" + bunifuDropdown2.selectedValue ;
                G.Commande.ExecuteNonQuery();
                bunifuMetroTextbox1.Text = "";
                bunifuMetroTextbox2.Text = "";
                MessageBox.Show("vous avez Supprimer un module depuis cette formation ");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }
            bunifuDropdown2.Clear();
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdModule from Module where IdModule in (select IdModule from Avoir where IdFormation =" + bunifuDropdown1.selectedValue + ")";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {

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
    }
}
