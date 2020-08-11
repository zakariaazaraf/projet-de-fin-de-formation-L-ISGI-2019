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
    public partial class UserControlModuleAfficher : UserControl
    {
        Globale G = new Globale();
        public UserControlModuleAfficher()
        {
            InitializeComponent();
        }

        private void UserControlModuleAfficher_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Rows.Clear();
            try {
                G.Connecter();
                G.Commande.CommandText = "select IdModule,NomModule from Module";
                G.ObjetReader = G.Commande.ExecuteReader();
                while(G.ObjetReader.Read()){
                    bunifuCustomDataGrid1.Rows.Add(G.ObjetReader[0], G.ObjetReader[1]);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("L'erreur suivante a été rencontré " + EX.Message);
            }
            finally {
                G.Déconnecter();
            }
        }
    }
}
