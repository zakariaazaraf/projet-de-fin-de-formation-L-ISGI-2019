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
    public partial class UtilisateurAffichageParResultat : UserControl
    {
        Globale G = new Globale();
        public UtilisateurAffichageParResultat()
        {
            InitializeComponent();
        }

        private void UtilisateurAffichageParResultat_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    G.Connecter();
            //    G.Commande.CommandText = "select U.PPR,NomUtilisater,PrénomUtilisateur,M.NomModule,C.NomCentreFormtion,Resultat,TypeFormation from Utilisateur U join Effectuer E on U.PPR=E.PPR join Module M on E.IdModule = M.IdModule join Formation F on E.IdFormation = F.IdFormation join [S'inscrire] S on F.IdFormation S.IdFormation join Centre C on C.IdCentreFormation = S.IdCentreFormation";
            //    G.ObjetReader = G.Commande.ExecuteReader();
            //    while (G.ObjetReader.Read())
            //    {
            //        bunifuCustomDataGrid1.Rows.Add(G.ObjetReader[0], G.ObjetReader[1], G.ObjetReader[2], G.ObjetReader[3], G.ObjetReader[3], G.ObjetReader[4], G.ObjetReader[5], G.ObjetReader[6]);
            //    }
            //}
            //catch (Exception EX)
            //{
            //    MessageBox.Show("l'erreur suivante à été rencontré " + EX.Message);
            //}
            //finally
            //{
            //    G.Déconnecter();
            //}
        }
    }
}
