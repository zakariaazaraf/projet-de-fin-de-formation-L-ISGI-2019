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
    public partial class UtilisateurSuppModuleFormation : UserControl
    {
        Globale G = new Globale();
        public UtilisateurSuppModuleFormation()
        {
            InitializeComponent();
        }

        private void UtilisateurSuppModuleFormation_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdFormation from [S'inscrire] where PPR='" + VariableGlobale.PPR + "'";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    comboBox1.Items.Add(G.ObjetReader[0]);
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante a été rencontré" + Ex.Message);
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
                    dateTimePicker2.Value = DateTime.Parse(G.ObjetReader[1].ToString());
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
                //G.Commande.CommandText = "select NomCentreFormation from [S'inscrire] S join Centre C on S.IdCentreFormation=C.IdCentreFormation where S.IdCentreFormation =" + comboBox1.Text + " and PPR=" + VariableGlobale.PPR;
                G.Commande.CommandText = "select NomCentreFormation from Centre C join [S'inscrire] S on S.IdCentreFormation=C.IdCentreFormation where  S.IdFormation =" + comboBox1.Text + " and PPR=" + VariableGlobale.PPR;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    textBox1.Text = G.ObjetReader[0].ToString(); ;

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
                G.Commande.CommandText = "select IdModule from Effectuer  where PPR=" + VariableGlobale.PPR + "and IdFormation=" + comboBox1.Text;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    comboBox2.Items.Add(G.ObjetReader[0].ToString());

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomModule from Module M join Effectuer E on E.IdModule = M.IdMOdule where PPR =" + VariableGlobale.PPR + "and IdFormation=" + comboBox1.Text + " and E.IdModule =" + comboBox2.Text;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    textBox4.Text = G.ObjetReader[0].ToString();
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
            try {
                G.Connecter();
                G.Commande.CommandText = "delete Effectuer where PPR ='"+VariableGlobale.PPR+"' and IdFormation ="+comboBox1.Text+" and IdModule ="+comboBox2.Text;
                G.Commande.ExecuteNonQuery();
                MessageBox.Show("vous avez supprimer un module depuis cette formation ");
                textBox4.Text = "";
                comboBox2.Text = "";
                comboBox2.Items.Clear();
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
                G.Commande.CommandText = "select IdModule from Effectuer  where PPR=" + VariableGlobale.PPR + "and IdFormation=" + comboBox1.Text;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    comboBox2.Items.Add(G.ObjetReader[0].ToString());

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
