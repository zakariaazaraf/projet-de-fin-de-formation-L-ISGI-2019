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
    public partial class GérerCeentreFormation : Form
    {
        public GérerCeentreFormation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccueilAdministrateur accueilAdmin = new AccueilAdministrateur();
            this.Hide();
            accueilAdmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControlCentreAjouter1.BringToFront();
            label3.Text = "Ajouter un centre de formation";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControlCentreModifier1.BringToFront();
            label3.Text = "Modifier un centre de formation";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControlCentreSupprimer1.BringToFront();
            label3.Text = "Supprimer un centre de formation";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControlCentreAfficher1.BringToFront();
            label3.Text = "Afficher les centres de formation";
        }

        private void GérerCeentreFormation_Load(object sender, EventArgs e)
        {
            userControlCentreAjouter1.BringToFront();
            label3.Text = "Ajouter un centre de formation";
        }
    }
}
