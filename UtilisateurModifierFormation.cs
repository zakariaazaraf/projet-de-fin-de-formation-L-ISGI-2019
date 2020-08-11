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
    public partial class UtilisateurModifierFormation : UserControl
    {
        Globale G = new Globale();
        public UtilisateurModifierFormation()
        {
            InitializeComponent();
        }

        private void UtilisateurModifierFormation_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdFormation from [S'inscrire] where PPR = '"+VariableGlobale.PPR+"'";
                G.ObjetReader = G.Commande.ExecuteReader();
                while(G.ObjetReader.Read()){
                    comboBox1.Items.Add(G.ObjetReader[0]);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("l'erreur suivante à été rencontré " + Ex.Message);
            }
            finally {
                G.Déconnecter();
            }

            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdCentreFormation from Centre ";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    comboBox2.Items.Add(G.ObjetReader[0]);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("l'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select DébutFormation,FinFormation from Formation where IdFormation =" + comboBox1.Text;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    dateTimePicker1.Value = DateTime.Parse(G.ObjetReader[0].ToString());
                    dateTimePicker3.Value = DateTime.Parse(G.ObjetReader[1].ToString());
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("l'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomCentreFormation from Centre where IdCentreFormation =" + comboBox2.Text;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    textBox1.Text = G.ObjetReader[0].ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("l'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                try
                {
                    G.Connecter();
                    G.Commande.CommandText = "update [S'inscrire] set IdCentreFormation="+comboBox2.Text+" where PPR='"+VariableGlobale.PPR+"' and IdFormation ="+comboBox1.Text;
                    G.Commande.ExecuteNonQuery();
                    MessageBox.Show("vous avez modifier le centre de formation ");
                    textBox1.Text = "";
                    comboBox2.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("l'erreur suivante à été rencontré " + Ex.Message);
                }
                finally
                {
                    G.Déconnecter();

                }
            }
            else {
                MessageBox.Show("vous devez sélectionné les champs nécessaire ");
            }
        }
    }
}
