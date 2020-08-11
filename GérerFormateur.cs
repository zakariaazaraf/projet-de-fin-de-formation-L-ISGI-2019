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
    public partial class GérerFormateur : Form
    {
        public GérerFormateur()
        {
            InitializeComponent();
        }

        private void GérerFormateur_Load(object sender, EventArgs e)
        {
            userControlFormateurAjout1.BringToFront();
            label4.Text = "Ajouter des formateur";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControlFormateurAjout1.BringToFront();
            label4.Text = "Ajouter des formateur";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControlFormateurModif1.BringToFront();
            label4.Text = "Modifier les formateurs";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControlFormateurSpp1.BringToFront();
            label4.Text = "Supprimer des formateurs";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControl1FormateurAff1.BringToFront();
            label4.Text = "la liste des formateurs";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccueilAdministrateur accueilAdmin = new AccueilAdministrateur();
            this.Hide();
            accueilAdmin.Show();
        }
    }
}
