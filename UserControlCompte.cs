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
    public partial class UserControlCompte : UserControl
    {
        Globale G = new Globale();
        public UserControlCompte()
        {
            InitializeComponent();
        }

        private void UserControlCompte_Load(object sender, EventArgs e)
        {
            try {
                G.Connecter();
                G.Commande.CommandText = "select NomUtilisateur,PrénomUtilisateur,TéléUtilisateur,Matière,Etablissement,PasswordUtilisateur from Utilisateur where PPR='" + VariableGlobale.PPR + "'";
                G.ObjetReader = G.Commande.ExecuteReader();
                
                while(G.ObjetReader.Read()){
                    bunifuMaterialTextbox1.Text = VariableGlobale.PPR;
                    bunifuMaterialTextbox2.Text = G.ObjetReader.GetString(0);
                    bunifuMaterialTextbox3.Text = G.ObjetReader.GetString(1);
                    bunifuMaterialTextbox4.Text = G.ObjetReader.GetString(3);
                    bunifuMaterialTextbox5.Text = G.ObjetReader.GetString(4);
                    bunifuMaterialTextbox6.Text = G.ObjetReader.GetString(2);
                    bunifuMaterialTextbox7.Text = G.ObjetReader.GetString(5);
                    
                }
                
            }
            catch (Exception Ex) { 
                MessageBox.Show("L'erreur suivante à été rencontré "+Ex.Message);
            }
            finally {
                G.Déconnecter();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text != "" && bunifuMaterialTextbox3.Text != "" && bunifuMaterialTextbox7.Text != "" && bunifuMaterialTextbox4.Text != "" && bunifuMaterialTextbox5.Text != "" && bunifuMaterialTextbox6.Text != "")
            {

                try
                {
                    G.Connecter();
                    
                    G.Commande.Parameters.Add("@Nom",SqlDbType.NVarChar,20);
                    G.Commande.Parameters.Add("@Prénom", SqlDbType.NVarChar, 20);
                    G.Commande.Parameters.Add("@Matière", SqlDbType.NVarChar, 20);
                    G.Commande.Parameters.Add("@Etablissement", SqlDbType.NVarChar, 25);
                    G.Commande.Parameters.Add("@Télé", SqlDbType.NVarChar, 20);
                    G.Commande.Parameters.Add("@Password", SqlDbType.NVarChar, 20);
                    G.Commande.Parameters[0].Value=bunifuMaterialTextbox2.Text;
                    G.Commande.Parameters[1].Value=bunifuMaterialTextbox3.Text;
                    G.Commande.Parameters[2].Value=bunifuMaterialTextbox4.Text;
                    G.Commande.Parameters[3].Value=bunifuMaterialTextbox5.Text;
                    G.Commande.Parameters[4].Value=bunifuMaterialTextbox6.Text;
                    G.Commande.Parameters[5].Value = bunifuMaterialTextbox7.Text;
                    G.Commande.CommandText = "update Utilisateur set NomUtilisateur=@Nom,PrénomUtilisateur=@Prénom,TéléUtilisateur=@Télé,Matière=@Matière,Etablissement=@Etablissement,PasswordUtilisateur=@Password where PPR='" + VariableGlobale.PPR + "'";
                    G.Commande.ExecuteNonQuery();
                    G.Commande.Parameters.Clear();
                    MessageBox.Show("vous avez modifier vous informations ");

                    

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
            else {
                MessageBox.Show("vous devez remplir tout les champs");
            }
            try
            {
                G.Connecter();
                G.Commande.CommandText = "select NomUtilisateur,PrénomUtilisateur,TéléUtilisateur,Matière,Etablissement,PasswordUtilisateur from Utilisateur where PPR='" + VariableGlobale.PPR + "'";
                G.ObjetReader = G.Commande.ExecuteReader();

                while (G.ObjetReader.Read())
                {
                    bunifuMaterialTextbox1.Text = VariableGlobale.PPR;
                    bunifuMaterialTextbox2.Text = G.ObjetReader.GetString(0);
                    bunifuMaterialTextbox3.Text = G.ObjetReader.GetString(1);
                    bunifuMaterialTextbox4.Text = G.ObjetReader.GetString(3);
                    bunifuMaterialTextbox5.Text = G.ObjetReader.GetString(4);
                    bunifuMaterialTextbox6.Text = G.ObjetReader.GetString(2);
                    bunifuMaterialTextbox7.Text = G.ObjetReader.GetString(5);

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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                G.Connecter();
                G.Commande.CommandText = "delete Utilisateur where PPR='" + VariableGlobale.PPR + "'";
                G.Commande.ExecuteNonQuery();
                MessageBox.Show("vous avez supprimer votre compte");        
                Form1 f = new Form1();
                this.Hide();
                f.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("L'erreur suivante à été rencontré " + Ex.Message);
            }
            finally {
                G.Déconnecter();
            }
            
        }
    }
}
