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
    public partial class UserControlModuleAjout : UserControl
    {
        Globale G = new Globale();
        public UserControlModuleAjout()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "insert into Module values('"+bunifuMetroTextbox1.Text+"')";
                G.Commande.ExecuteNonQuery();
                MessageBox.Show("vous aver ajouter un module");
            }
            catch (Exception EX)
            {
                MessageBox.Show("L'erreur suivante a été rencontré " + EX.Message);
            }
            finally
            {
                G.Déconnecter();
            }
        }
    }
}
