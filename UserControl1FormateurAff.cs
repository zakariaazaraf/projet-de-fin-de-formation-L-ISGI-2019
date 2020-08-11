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
    public partial class UserControl1FormateurAff : UserControl
    {
        Globale G = new Globale();
        public UserControl1FormateurAff()
        {
            InitializeComponent();
        }

        private void UserControl1FormateurAff_Load(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select IdFormateur,NomFormateur,PrénomFormateur,TéléFormateur,M.IdModule,M.NomModule from Module M join Formateur F on M.IdModule=F.IdModule ";
                G.ObjetReader = G.Commande.ExecuteReader();
                while (G.ObjetReader.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add(G.ObjetReader[0],G.ObjetReader[1],G.ObjetReader[2],G.ObjetReader[3],G.ObjetReader[4],G.ObjetReader[5]);
                }
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
