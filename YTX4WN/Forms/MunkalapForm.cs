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
    public partial class MunkalapForm : Form
    {
        private List<Work> rendelhetoMunka;
        private int munkalapSzamlalo;
        private List<Work> kivalasztottMunka = new List<Work>();
        public event EventHandler<List<Work>> CheckedWorksSaved;

        private const int LabelOffsetX = 150;
        private const int LabelOffsetY = -30;
        private const int ControlOffsetX = 10;
        private const int ControlOffsetY = 40;

        public MunkalapForm(List<Work> betoltottMunka, int munkalapSzamlalo)
        {
            InitializeComponent();
            rendelhetoMunka = betoltottMunka;
            this.munkalapSzamlalo = munkalapSzamlalo;
        }

        private void MunkalapForm_Load(object sender, EventArgs e)
        {
            CreateDynamicFormContent();
        }

        private void CreateDynamicFormContent()
        {
            AddHeaderLabel("Anyagkoltseg", LabelOffsetX, LabelOffsetY);
            AddHeaderLabel("Munkaido", LabelOffsetX + 100, LabelOffsetY);
            AddHeaderLabel("Munkadij", LabelOffsetX + 250, LabelOffsetY);

            for (int i = 0; i < rendelhetoMunka.Count; i++)
            {
                CreateControlsOfItem(rendelhetoMunka[i], i);
            }
        }

        private void CreateControlsOfItem(Work work, int index)
        {
            Label nameLabel = new Label();
            nameLabel.Text = work.MunkaNev;
            nameLabel.Location = new Point(ControlOffsetX, ControlOffsetY + index * 40);
            nameLabel.AutoSize = true;

            Label materialCostLabel = new Label();
            materialCostLabel.Text = work.Anyagkoltseg.ToString() + " Ft";
            materialCostLabel.Location = new Point(ControlOffsetX + LabelOffsetX, ControlOffsetY + index * 40);
            materialCostLabel.AutoSize = true;

            Label timeLabel = new Label();
            timeLabel.Text = work.HourMinute;
            timeLabel.Location = new Point(ControlOffsetX + LabelOffsetX + 100, ControlOffsetY + index * 40);
            timeLabel.AutoSize = true;

            CheckBox costCheckBox = new CheckBox();
            costCheckBox.Location = new Point(ControlOffsetX + LabelOffsetX + 250, ControlOffsetY + index * 40);
            costCheckBox.AutoSize = true;
            costCheckBox.CheckedChanged += (sender, e) => UpdateCostLabels();

            panel1.Controls.AddRange(new Control[] { nameLabel, materialCostLabel, timeLabel, costCheckBox });
        }

        private void AddHeaderLabel(string text, int offsetX, int offsetY)
        {
            Label headerLabel = new Label();
            headerLabel.Text = text;
            headerLabel.Location = new Point(ControlOffsetX + offsetX, ControlOffsetY + offsetY);
            headerLabel.AutoSize = true;
            panel1.Controls.Add(headerLabel);
        }

        private int CalculateTotalCost(int totalRequiredTime)
        {
            int osszeg;
            int oraber = 15000;
            if (totalRequiredTime % 60 == 0)
            {
                osszeg = totalRequiredTime / 60 * oraber;
            }
            else
            {
                int fullHourCost = (totalRequiredTime / 60) * oraber;

                int remainingMinutes = totalRequiredTime % 60;
                int remainingMinutesCost = (remainingMinutes <= 30) ? oraber / 2 : oraber;

                osszeg = fullHourCost + remainingMinutesCost;
            }
            return osszeg;
        }

        private void UpdateCostLabels()
            {
                int anyagkoltseg = 0;
                int munkadij;
                int munkaido = 0;

                foreach (Control control in panel1.Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        int index = (checkBox.Location.Y - ControlOffsetY) / 40;
                        Work checkedWork = rendelhetoMunka[index];
                        anyagkoltseg += checkedWork.Anyagkoltseg;
                        munkaido += checkedWork.Munkaido;
                        checkBox.Text = (checkedWork.CalculateCost()).ToString() + " Ft";
                    }
                    else if (control is CheckBox checkBox1 && !checkBox1.Checked)
                    {
                        checkBox1.Text = "";
                    }
                }

                 munkadij = CalculateTotalCost(munkaido);

                labelAnyagkoltseg.ForeColor = Color.Green;
                labelAnyagkoltseg.Text = anyagkoltseg.ToString() + " Ft";

                labelMunkadij.ForeColor = Color.Red;
 
                labelMunkadij.Text = munkadij.ToString() + " Ft";
            }

        

        private void buttonRogzites_Click(object sender, EventArgs e)
        {
            FormClosing -= MunkalapForm_FormClosing;

            
            foreach (Control control in panel1.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    int index = (checkBox.Location.Y - ControlOffsetY) / 40;
                    Work checkedWork = rendelhetoMunka[index];
                    kivalasztottMunka.Add(checkedWork);
                }
            }
            
            CheckedWorksSaved?.Invoke(this, kivalasztottMunka);

            Close();

            FormClosing += MunkalapForm_FormClosing;
        }

        private void MunkalapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Biztosan bezárja rögzítés nélkül?", "Megerősítés",
                    MessageBoxButtons.YesNo);

                e.Cancel = (result == DialogResult.No);
            }
        }

    }
}

