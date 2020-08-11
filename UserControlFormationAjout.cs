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
    public partial class UserControlFormationAjout : UserControl
    {
        Globale G = new Globale();
        public UserControlFormationAjout()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "Insert into Formation values('"+bunifuDatepicker1.Value+"','"+bunifuDatepicker2.Value+"')";
                G.Commande.ExecuteNonQuery();
                MessageBox.Show("vous avez ajouter une formation ");
                
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
