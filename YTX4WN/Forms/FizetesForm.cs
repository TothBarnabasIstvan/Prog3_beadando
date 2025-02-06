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
    public partial class FizetesForm : Form
    {
        private List<Work> works = new List<Work>();

        private int MunkalapSzamlalo;
        public FizetesForm(List<Work> works, int munkalapSzamlalo)
        {
            InitializeComponent();
            this.works = works;
            this.MunkalapSzamlalo = munkalapSzamlalo;
            DisplayPaymentDetails();
        }

        private void DisplayPaymentDetails()
        {
            int osszMunkalapSzam = MunkalapSzamlalo; 
            int osszAnyagkoltseg = 0;
            int osszMunkadij = 0;
            double osszMunkaido = 0;
            int osszMunkakSzama = 0;

            foreach (Work work in works)
            {
                osszAnyagkoltseg += work.Anyagkoltseg;
                osszMunkadij += work.CalculateCost();

                osszMunkaido += work.Munkaido;
                osszMunkakSzama++;
            }

            int totalPayment = osszAnyagkoltseg + osszMunkadij;

            labelMunkalapokSzama.Text = osszMunkalapSzam.ToString() + " db";
            labelMunkakSzama.Text = osszMunkakSzama.ToString() + " db";
            labelAnyagkoltseg.Text = osszAnyagkoltseg.ToString() + " Ft";
            LabelMunkadij.Text = osszMunkadij.ToString() + " Ft";
            labelMunkaido.Text = Math.Ceiling((osszMunkaido / 30)).ToString() + " * 30 perc";
            labelOsszeg.Text = totalPayment.ToString() + " Ft";
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sikeres fizetés!", "Fizetés", MessageBoxButtons.OK);

            works.Clear();

            this.Close();
        }
    }
}
