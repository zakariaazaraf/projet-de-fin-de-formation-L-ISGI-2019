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
    public partial class UserControlFormationAjoutModule : UserControl
    {
        Globale G = new Globale();
        public UserControlFormationAjoutModule()
        {
            InitializeComponent();
        }

        private void UserControlFormationAjoutModule_Load(object sender, EventArgs e)
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
                G.Commande.CommandText = "select IdModule from Module where IdModule not in (select IdModule from Avoir where IdFormation =" + bunifuDropdown1.selectedValue + ")";
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

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
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "Insert into Avoir values ('" + bunifuMetroTextbox2.Text + "'," + bunifuDropdown1.selectedValue + "," + bunifuDropdown2.selectedValue + ")";
                G.Commande.ExecuteNonQuery();
                MessageBox.Show("vous avez ajouter un module à cette formation");
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
