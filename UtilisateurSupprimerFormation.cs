using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjetDuStage
{
    public partial class UtilisateurSupprimerFormation : UserControl
    {
        Globale G = new Globale();
        SqlTransaction Transaction;
        SqlCommand CommandeTransaction;
        public void TransactionFonction()
        {
            G.ConnecterAux();
            Transaction = G.Connexion1.BeginTransaction();
            CommandeTransaction = G.Connexion1.CreateCommand();
            CommandeTransaction.Transaction = Transaction;
        }
        public UtilisateurSupprimerFormation()
        {
            InitializeComponent();
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
                MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
            }
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select C.NomCentreFormation from Centre C join [S'inscrire] S on S.IdCentreFormation=C.IdCentreFormation where  IdFormation ="+comboBox1.Text+" and PPR=" + VariableGlobale.PPR;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    textBox1.Text = G.ObjetReader[0].ToString();
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

        private void UtilisateurSupprimerFormation_Load(object sender, EventArgs e)
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                TransactionFonction();
                CommandeTransaction.CommandText = "delete [S'inscrire] where PPR ='" + VariableGlobale.PPR + "' and IdFormation =" + comboBox1.Text;
                CommandeTransaction.ExecuteNonQuery();
                CommandeTransaction.CommandText = "delete Effectuer where PPR ='" + VariableGlobale.PPR+"' and IdFormation =" + comboBox1.Text;
                CommandeTransaction.ExecuteNonQuery();
                Transaction.Commit();
                MessageBox.Show("vous avez supprimer cette formaation");
                textBox1.Text = "";
                comboBox1.Text = "";
                comboBox1.Items.Clear();
            }
            catch (Exception Ex) {
                MessageBox.Show("l'erreur suivante à été rencontré "+Ex.Message);
            }
            finally {
                G.Déconnecter();
            }


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
    }
}
