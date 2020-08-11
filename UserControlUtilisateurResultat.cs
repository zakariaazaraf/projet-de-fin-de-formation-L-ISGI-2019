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
    public partial class UserControlUtilisateurResultat : UserControl
    {
        Globale G = new Globale();
        public UserControlUtilisateurResultat()
        {
            InitializeComponent();
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown4_onItemSelected(object sender, EventArgs e)
        {
            
        }

        private void UserControlUtilisateurResultat_Load(object sender, EventArgs e)
        {
            try { 
                G.Connecter();
                G.Commande.CommandText = "select distinct IdFormation from Avoir";
                G.ObjetReader=G.Commande.ExecuteReader();
                while(G.ObjetReader.Read()){
                    bunifuDropdown1.Items.Add(G.ObjetReader[0]);
                }
            }catch(Exception Ex){
                MessageBox.Show("L'erreur suivante a été rencontré 111 "+Ex.Message);
            }finally{
                G.Déconnecter();
            }
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            bunifuDropdown3.Clear();
            bunifuDropdown2.Enabled = false;
            bunifuDropdown3.Enabled = false;
            bunifuDropdown4.Enabled = false;
            bunifuDropdown2.Clear();
            bunifuMetroTextbox1.Text = "";
            //bunifuDropdown2.selectedText = "";
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
                MessageBox.Show("L'erreur suivante à été rencontré 222 " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }

            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdModule from Avoir where IdFormation ="+bunifuDropdown1.selectedValue;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuDropdown2.Items.Add(G.ObjetReader[0]);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante a été rencontré 333 " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }
            bunifuDropdown2.Enabled = true;
        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            bunifuDropdown3.Clear();
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomModule from Module where IdModule =" + bunifuDropdown2.selectedValue;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuMetroTextbox1.Text = G.ObjetReader[0].ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante a été rencontré 444  " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }

            try
            {
                G.Connecter();
                G.Commande.CommandText = "select PPR from Effectuer where IdFormation = "+bunifuDropdown1.selectedValue+"and IdModule =" + bunifuDropdown2.selectedValue;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuDropdown3.Items.Add(G.ObjetReader[0]);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante a été rencontré 555 " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }

            bunifuDropdown3.Enabled = true;
        }

        private void bunifuDropdown3_onItemSelected(object sender, EventArgs e)
        {
            bunifuDropdown4.Clear();
            bunifuDropdown4.Enabled = true;
            bunifuDropdown4.Items.Add("Validé");
            bunifuDropdown4.Items.Add("Non Validé");
            bunifuDropdown4.Items.Add("Absente");
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.selectedValue != "" && bunifuDropdown2.selectedValue != "" && bunifuDropdown3.selectedValue != "" && bunifuDropdown4.selectedValue != "")
            {
                try
                {
                    G.Connecter();
                    G.Commande.CommandText = "update Effectuer set Resultat = '" + bunifuDropdown4.selectedValue + "' where PPR ='" + bunifuDropdown3.selectedValue + "' and IdFormation ='" + bunifuDropdown1.selectedValue + "' and IdModule =" + bunifuDropdown2.selectedValue;
                    G.Commande.ExecuteNonQuery();
                    MessageBox.Show("vous avez effectuer cet résultat !");
                    bunifuDropdown3.Clear();
                    bunifuDropdown2.Enabled = false;
                    bunifuDropdown3.Enabled = false;
                    bunifuDropdown4.Enabled = false;
                    bunifuDropdown2.Clear();
                    bunifuMetroTextbox1.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("L'erreur suivante à été rencontré 666" + Ex.Message);
                }
                finally
                {
                    G.Déconnecter();
                }
            }
            else {
                MessageBox.Show("vous devez sélectionné tout les champs nécessaires ");
            }
        }
    }
}
