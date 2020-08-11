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
    public partial class UserControlFormationAffich : UserControl
    {
        Globale G = new Globale();
        public UserControlFormationAffich()
        {
            InitializeComponent();
        }

        private void UserControlFormationAffich_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select * from Formation";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuDropdown1.Items.Add(G.ObjetReader[0]);
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
        }
    }
}
