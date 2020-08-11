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
    public partial class GérerFormation : Form
    {
        public GérerFormation()
        {
            InitializeComponent();
        }

        private void GérerFormation_Load(object sender, EventArgs e)
        {
            userControlFormationAjout1.BringToFront();
            label4.Text = "Ajouter des formations";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControlFormationAjout1.BringToFront();
            label4.Text = "Ajouter des formations";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControlFormationModif1.BringToFront();
            label4.Text = "Modifier des formations";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControlFormationSupp1.BringToFront();
            label4.Text = "Supprimer une formation";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControlFormationAffich1.BringToFront();
            label4.Text = "La liste des formatins";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccueilAdministrateur accueilAdmin = new AccueilAdministrateur();
            this.Hide();
            accueilAdmin.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            userControlFormationAjoutModule1.BringToFront();
            label4.Text = "Ajouter ce module à cette formation";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            userControlFormationSuppModule1.BringToFront();
            label4.Text = "Supprimer ce module depuis cette formation";
        }
    }
}
