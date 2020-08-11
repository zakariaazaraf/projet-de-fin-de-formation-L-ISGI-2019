using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetDuStage
{
    public partial class CreationCompte : Form
    {
        Globale G = new Globale();
        public CreationCompte()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void CreationCompte_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "" | bunifuMetroTextbox2.Text == "" | bunifuMetroTextbox3.Text == "" | bunifuMetroTextbox4.Text == "" | bunifuMetroTextbox5.Text == "" | bunifuMetroTextbox6.Text == "")
            {
                MessageBox.Show("Vous devez remplir tout les champs");
            }
            else {
                try
                {
                    
                    G.Connecter();
                    G.Commande.CommandType = CommandType.Text;
                    G.Commande.CommandText = "insert into Utilisateur values (@PPR,@Nom,@Prénom,@Télé,@Matière,@Etablissement,@Login,@Password,@IdFunction)";
                    G.Commande.Parameters.Add("@PPR", SqlDbType.NVarChar, 7);
                    G.Commande.Parameters.Add("@Nom", SqlDbType.NVarChar, 25);
                    G.Commande.Parameters.Add("@Prénom", SqlDbType.NVarChar, 25);
                    G.Commande.Parameters.Add("@Télé", SqlDbType.NVarChar, 25);
                    G.Commande.Parameters.Add("@Matière", SqlDbType.NVarChar, 25);
                    G.Commande.Parameters.Add("@Etablissement", SqlDbType.NVarChar, 30);
                    G.Commande.Parameters.Add("@Login", SqlDbType.NVarChar, 25);
                    G.Commande.Parameters.Add("@Password", SqlDbType.NVarChar, 25);
                    G.Commande.Parameters.Add("@IdFunction", SqlDbType.Int);
                    //tu dois déclarer les paramaitres avant les utilisé
                    G.Commande.Parameters[0].Value = bunifuMetroTextbox3.Text;
                    G.Commande.Parameters[1].Value = bunifuMetroTextbox1.Text;
                    G.Commande.Parameters[2].Value = bunifuMetroTextbox2.Text;
                    G.Commande.Parameters[3].Value = bunifuMetroTextbox4.Text;
                    G.Commande.Parameters[4].Value = bunifuMetroTextbox6.Text;
                    G.Commande.Parameters[5].Value = bunifuMetroTextbox5.Text;
                    G.Commande.Parameters[6].Value = bunifuMetroTextbox3.Text+ "@taalim.ma";
                    G.Commande.Parameters[7].Value = bunifuMetroTextbox3.Text;
                    G.Commande.Parameters[8].Value = 2;


                    G.Commande.Connection = G.Connexion;
                    int résultat = G.Commande.ExecuteNonQuery();
                    if (résultat == 1)
                    {
                        bunifuMetroTextbox1.Text = "";
                        bunifuMetroTextbox2.Text = "";
                        bunifuMetroTextbox3.Text = "";
                        bunifuMetroTextbox4.Text = "";
                        bunifuMetroTextbox5.Text = "";
                        bunifuMetroTextbox6.Text = "";
                        MessageBox.Show("vous avez effectuer un enregistrement !");
                        G.Commande.Parameters.Clear();
                    }
                }
                catch (Exception Ex) { MessageBox.Show("L'erreur suivante à été rencontreé " + Ex.Message); }
                finally { G.Déconnecter(); }
            }

            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

       

        
    }
}
