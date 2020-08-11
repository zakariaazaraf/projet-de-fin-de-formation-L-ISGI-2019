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
    public partial class UserControlListeFormations : UserControl
    {
        Globale G = new Globale();
        public UserControlListeFormations()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select DébutFormation,FinFormation from Formation where IdFormation = '" + comboBox1.Text + "'";
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
        }

        private void UserControlListeFormations_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select * from Formation";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    
                    comboBox1.Items.Add(G.ObjetReader[0]);
                    bunifuCustomDataGrid1.Rows.Add(G.ObjetReader[0], G.ObjetReader[1], G.ObjetReader[2]);
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
