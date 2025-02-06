using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTX4WN
{
    public partial class MainForm : Form
    {
        private int munkalapSzamlalo = 0;
        private List<Work> betoltottMunka;
        private List<Work> mentettMunka = new List<Work>();


        public MainForm()
        {
            InitializeComponent();
        }

        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToShortDateString() + "\nYTX4WN", "Névjegy");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult response = MessageBox.Show(
                "Biztosan ki akar lépni?", "Figyelem!", MessageBoxButtons.YesNo
            );

            e.Cancel = response != DialogResult.Yes;
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fájlBetöltésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Szövegfájlok (*.txt)|*.txt|Összes fájl (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    Loader loader = new Loader();
                    betoltottMunka = loader.LoadData(selectedFilePath);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba történt a beolvasás közben!", "Figyelem!");
            }

        }


        private void munkalapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (betoltottMunka != null) 
            {
                MunkalapForm munkalapForm = new MunkalapForm(betoltottMunka, munkalapSzamlalo);

                munkalapForm.CheckedWorksSaved += MunkalapForm_CheckedWorksSaved;
                munkalapForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Valami hiba történt!", "Hiba");
            }
        }

        private void MunkalapForm_CheckedWorksSaved(object sender, List<Work> checkedWorks)
        {
            mentettMunka.AddRange(checkedWorks); 
            munkalapSzamlalo++; 
        }

        private void fizetésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mentettMunka.Count > 0)
            {
                FizetesForm fizetesForm = new FizetesForm(mentettMunka, munkalapSzamlalo);
                fizetesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kitöltött munkalap!", "Hiba");
            }
        }
    }

}

