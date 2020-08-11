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
    public partial class GérerUtilisateur : Form
    {
        public GérerUtilisateur()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControlUtilisateurResultat1.BringToFront();
            label4.Text = "effectuer les resultats";
        }

        private void GérerUtilisateur_Load(object sender, EventArgs e)
        {
            userControlUtilisateurResultat1.BringToFront();
            label4.Text = "effectuer les resultats";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccueilAdministrateur accueilAdmin = new AccueilAdministrateur();
            this.Hide();
            accueilAdmin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControlUtilisateurAff1.BringToFront();
            label4.Text = "la liste des utilisateurs";
        }

        private void userControlUtilisateurAff1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            utilisateurAffichageParResultat1.BringToFront();
            label4.Text = "les resultats des Utilisateur";
        }
    }
}
