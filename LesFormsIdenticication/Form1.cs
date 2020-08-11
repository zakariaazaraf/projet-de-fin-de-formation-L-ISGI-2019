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
    public partial class Form1 : Form
    {
        int zz=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void bunifuMetroTextbox1_MouseLeave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "") {
                bunifuMetroTextbox1.Text = "Email";
            }
        }

        private void bunifuMetroTextbox2_MouseLeave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "")
            {
                bunifuMetroTextbox2.Text = "Password";
            }
        }

        

        private void bunifuMetroTextbox1_MouseEnter(object sender, EventArgs e)
        {
            if ( bunifuMetroTextbox1.Text == "Email")
            {
                bunifuMetroTextbox1.Text = "";
            }
            //bunifuMetroTextbox1.Text = "";
        }

        private void bunifuMetroTextbox2_MouseEnter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "Password")
            {
                bunifuMetroTextbox2.Text = "";
            }
            //bunifuMetroTextbox2.Text = "";
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            CreationCompte f = new CreationCompte();
            this.Hide();
            f.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(bunifuMetroTextbox1.Text + " " + bunifuMetroTextbox2.Text);
            Globale z = new Globale();
            
            try
            {
                
                z.Connecter();
                z.Commande.CommandType = CommandType.Text;
                //z.Commande.CommandText = "select PPR,IdFonction from Utilisateur where LoginUtilisateur='azarafzakaria' and PasswordUtilisateur='az33333'";
                z.Commande.CommandText = "select PPR,IdFonction from Utilisateur where LoginUtilisateur='" + bunifuMetroTextbox1.Text + "' and PasswordUtilisateur='" + bunifuMetroTextbox2.Text + "'";
                z.Commande.Connection = z.Connexion;
                
                z.ObjetReader = z.Commande.ExecuteReader();
                
                while (z.ObjetReader.Read())
                {
                    zz = z.ObjetReader.GetInt16(1);
                    VariableGlobale.PPR = z.ObjetReader.GetString(0);

                    //MessageBox.Show(z.ObjetReader.GetString(0) + " " + z.ObjetReader.GetInt16(1));
                }
                

                if (zz == 1)
                {
                    AccueilAdministrateur FormAccueilAdmin = new AccueilAdministrateur();
                    this.Hide();
                    FormAccueilAdmin.Show();
                }
                else if (zz == 2)
                {
                    AccueilCilent AccueilUtilisateur = new AccueilCilent();
                    this.Hide();
                    AccueilUtilisateur.Show();
                }

            }
            catch (Exception Erreur)
            {
                MessageBox.Show("l'erreur suivante à été rencontrée " + Erreur.Message);
            }
            finally
            {
                z.Déconnecter();
            }
            
            
            //AccueilCilent FormAccueil = new AccueilCilent();
            //this.Hide();
            //FormAccueil.Show();
        }
    }
}
