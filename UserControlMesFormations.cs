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
    public partial class UserControlMesFormations : UserControl
    {
        Globale G = new Globale();
        public UserControlMesFormations()
        {
            InitializeComponent();
        }

        private void UserControlMesFormations_Load(object sender, EventArgs e)
        {
            
            try {
                G.Connecter();
                G.Commande.CommandText = "select IdFormation from [S'inscrire] where PPR='"+VariableGlobale.PPR+"'";
                G.ObjetReader = G.Commande.ExecuteReader();
                while(G.ObjetReader.Read()){
                    comboBox1.Items.Add(G.ObjetReader[0]);
                }

            }catch(Exception Ex){
                MessageBox.Show("L'erreur suivante a été rencontré" +Ex.Message);
            }finally{
                G.Déconnecter();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Text = "";
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
                G.Commande.CommandText = "select NomCentreFormation from [S'inscrire] S join Centre C on S.IdCentreFormation=C.IdCentreFormation where S.IdCentreFormation =" + comboBox1.Text+" and PPR="+VariableGlobale.PPR;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomModule,TypeFormation,Resultat from Effectuer E join Module M on E.IdModule = M.IdMOdule where PPR =" + VariableGlobale.PPR + "and IdFormation=" + comboBox1.Text+" and E.IdModule ="+comboBox2.Text;
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    textBox4.Text = G.ObjetReader[0].ToString();
                    textBox2.Text = G.ObjetReader[1].ToString();
                    textBox3.Text = G.ObjetReader[2].ToString();

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
