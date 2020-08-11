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
    public partial class AccueilCilent : Form
    {
        public AccueilCilent()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControlS_inscrireFormation1.BringToFront();
            label1.Text = "s'inscrire dans une formation";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControlS_inscrireFormation1.BringToFront();
            label1.Text = "s'inscrire dans une formation";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControlCompte1.BringToFront();
            label1.Text = "Modifier ou supprimer votre compte";
            
        }

        private void AccueilCilent_Load(object sender, EventArgs e)
        {
            userControlCompte1.BringToFront();
            label1.Text = "Modifier ou supprimer votre compte";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControlListeFormations1.BringToFront();
            label1.Text = "La liste des formations";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            userControlMesFormations1.BringToFront();
            label1.Text = "Mes formations ";
        }

        private void panelSide_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            utilisateurSupprimerFormation1.BringToFront();
            label1.Text = "Supprimer une formation";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            utilisateurModifierFormation1.BringToFront();
            label1.Text = "Modifier une formation";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            utilisateurSuppModuleFormation1.BringToFront();
            label1.Text = "Supprimer un module depuis cette formation";
        }

       

        
    }
}
