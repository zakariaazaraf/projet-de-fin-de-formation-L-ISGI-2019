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
    public partial class AccueilAdministrateur : Form
    {
        public AccueilAdministrateur()
        {
            InitializeComponent();
        }

        private void AccueilAdministrateur_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            GérerModule GModule = new GérerModule();
            this.Hide();
            GModule.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            GérerFormation GFormation = new GérerFormation();
            this.Hide();
            GFormation.Show();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            GérerFormateur GFormateur = new GérerFormateur();
            this.Hide();
            GFormateur.Show();

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            GérerUtilisateur GUtilisateur = new GérerUtilisateur();
            this.Hide();
            GUtilisateur.Show();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            GérerCeentreFormation Centre = new GérerCeentreFormation();
            this.Hide();
            Centre.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
