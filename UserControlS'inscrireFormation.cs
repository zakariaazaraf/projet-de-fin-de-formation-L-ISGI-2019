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
    public partial class UserControlS_inscrireFormation : UserControl
    {
        Globale G = new Globale();
        SqlTransaction Transaction;
        SqlCommand CommandeTransaction;
        public UserControlS_inscrireFormation()
        {
            InitializeComponent();
        }
        public void TransactionFonction()
        {
            G.ConnecterAux();
            Transaction = G.Connexion1.BeginTransaction();
            CommandeTransaction = G.Connexion1.CreateCommand();
            CommandeTransaction.Transaction = Transaction;
        }

        public void VideChamps() {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            
        }

        //cette fonction permettre de faire les opération néssaire pour le changement des valuers de comboBox1
        public void comboBox1IndexChange() {

            //Vidé le combobox car chaque fois il se remplit avec des neavaux données 
            comboBox3.Items.Clear();
            VideChamps();
            //les dates de la formation sélectioné
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
                G.ObjetReader.Close();
                G.Déconnecter();


            }

            //Sélectionné les modules qui ne sont pas Effectuer par le client dans la formation sélectionné
            try
            {
                G.ObjetReader.Close();
                G.Connecter();
                G.Commande.CommandText = "select M.IdModule,M.NomModule from Module M join Avoir A on M.IdModule = A.IdModule where IdFormation = " + comboBox1.Text + " and A.IdModule not in (select E.IdModule from Effectuer E where PPR =" + VariableGlobale.PPR + " and E.IdFormation=" + comboBox1.Text + ")";
                G.ObjetReader = G.Commande.ExecuteReader();
                if (G.ObjetReader.HasRows)
                {
                    comboBox3.Enabled = true;
                    comboBox4.Enabled = true;
                    while (G.ObjetReader.Read())
                    {
                        comboBox3.Items.Add(G.ObjetReader[0]);
                        //textBox2.Text = G.ObjetReader[1].ToString();
                        //comboBox3.Text = G.ObjetReader[0].ToString();
                    }

                }
                else
                {
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.ObjetReader.Close();
                G.Déconnecter();
            }

            try
            {
                G.Connecter();
                G.Commande.CommandText = "select C.IdCentreFormation,C.NomCentreFormation from Centre C join [S'inscrire] S on S.IdCentreFormation=C.IdCentreFormation where  IdFormation =" + comboBox1.Text + " and PPR=" + VariableGlobale.PPR;
                G.ObjetReader = G.Commande.ExecuteReader();
                if (G.ObjetReader.HasRows)
                {
                    comboBox2.Enabled = false;
                    while (G.ObjetReader.Read())
                    {
                        comboBox2.Text = G.ObjetReader[0].ToString();
                        textBox1.Text = G.ObjetReader[1].ToString();
                    }

                }
                else
                {
                    comboBox2.Enabled = true;
                    try
                    {

                        G.ConnecterAux();
                        G.Commande1.CommandText = "select IdCentreFormation from Centre ";
                        G.ObjetReader = G.Commande1.ExecuteReader();
                        while (G.ObjetReader.Read())
                        {
                            comboBox2.Items.Add(G.ObjetReader[0]);
                        }

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
                    }
                    finally
                    {
                        G.ObjetReader.Close();
                        G.DéconnecterAux();
                    }
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.ObjetReader.Close();
                G.Déconnecter();


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1IndexChange();
        }

        private void UserControlS_inscrireFormation_Load(object sender, EventArgs e)
        {
            comboBox4.Items.Add("Formation Continu");
            comboBox4.Items.Add("Formation Non Continu");
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            //remplir la listes des formations qui ont enregistrer par l'admin depuis la table "Avoir"
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select distinct IdFormation from Avoir ";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    comboBox1.Items.Add(G.ObjetReader[0]);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
                G.ObjetReader.Close();
            }

            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomModule from Module where IdModule ="+comboBox3.Text;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    textBox2.Text = G.ObjetReader[0].ToString();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
            }
            finally
            {
                G.Déconnecter();
                G.ObjetReader.Close();
            }
            
            comboBox4.Enabled = true;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            if (comboBox3.Enabled == false)
            {
                MessageBox.Show("vous avez déjà effectuer tout les modules dans cette formation");
            }
            else
            {
                try
                {
                    G.Connecter();
                    G.Commande.CommandText = "select 1 from [S'inscrire] where PPR=" + VariableGlobale.PPR + " and IdFormation =" + comboBox1.Text;
                    G.ObjetReader = G.Commande.ExecuteReader();
                    if (G.ObjetReader.HasRows)
                    {
                        try
                        {
                            TransactionFonction();
                            CommandeTransaction.CommandText = "insert into Effectuer values ('" + comboBox4.Text + "','','" + VariableGlobale.PPR + "'," + comboBox3.Text + "," + comboBox1.Text + ")";
                            CommandeTransaction.ExecuteNonQuery();
                            Transaction.Commit();
                            MessageBox.Show("Opération effectuer ");
                            VideChamps();
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
                            Transaction.Rollback();
                        }
                        finally
                        {
                            G.DéconnecterAux();
                        }
                    }
                    else {
                        try
                        {
                            TransactionFonction();
                            CommandeTransaction.CommandText = "insert into [S'inscrire] values ('"+VariableGlobale.PPR+"',"+comboBox1.Text+","+comboBox2.Text+")";
                            CommandeTransaction.ExecuteNonQuery();
                            CommandeTransaction.CommandText = "insert into Effectuer values ('" + comboBox4.Text + "','','" + VariableGlobale.PPR + "'," + comboBox2.Text + "," + comboBox1.Text + ")";
                            CommandeTransaction.ExecuteNonQuery();
                            Transaction.Commit();
                            MessageBox.Show("Opération effectuer ");
                            VideChamps();
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
                            Transaction.Rollback();
                        }
                        finally
                        {
                            G.DéconnecterAux();
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("L'erreur suivante a été rencontré " + Ex.Message);
                }
                finally
                {
                    G.Déconnecter();
                }
            }

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox4.Text = "";
            comboBox1.Text = "";
                
                    
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomCentreFormation from Centre where IdCentreFormation ="+comboBox2.Text;
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
                G.ObjetReader.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}
