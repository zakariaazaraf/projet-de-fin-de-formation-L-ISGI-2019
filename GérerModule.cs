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
    public partial class GérerModule : Form
    {
        public GérerModule()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControlModuleAjout1.BringToFront();
            label4.Text = "Ajouter des modules";
        }

        private void GérerModule_Load(object sender, EventArgs e)
        {
            userControlModuleAjout1.BringToFront();
            label4.Text = "Ajouter des modules";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControlModuleModif1.BringToFront();
            label4.Text = "Modifier des modules";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControlModuleSupp1.BringToFront();
            label4.Text = "Supprimer des modules";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControlModuleAfficher1.BringToFront();
            label4.Text = "la liste des modules";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccueilAdministrateur accueilAdmin = new AccueilAdministrateur();
            this.Hide();
            accueilAdmin.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
