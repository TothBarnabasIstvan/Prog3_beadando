using System.Windows.Forms;

namespace YTX4WN
{
    partial class MunkalapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRogzites = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAnyagkoltseg = new System.Windows.Forms.Label();
            this.labelMunkadij = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(15, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 593);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 313);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 7);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonRogzites
            // 
            this.buttonRogzites.Location = new System.Drawing.Point(632, 684);
            this.buttonRogzites.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRogzites.Name = "buttonRogzites";
            this.buttonRogzites.Size = new System.Drawing.Size(92, 38);
            this.buttonRogzites.TabIndex = 2;
            this.buttonRogzites.Text = "Rögzítés";
            this.buttonRogzites.UseVisualStyleBackColor = true;
            this.buttonRogzites.Click += new System.EventHandler(this.buttonRogzites_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 695);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Anyagköltség:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 695);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Munkadíj:";
            // 
            // labelAnyagkoltseg
            // 
            this.labelAnyagkoltseg.AutoSize = true;
            this.labelAnyagkoltseg.Location = new System.Drawing.Point(120, 698);
            this.labelAnyagkoltseg.Name = "labelAnyagkoltseg";
            this.labelAnyagkoltseg.Size = new System.Drawing.Size(35, 20);
            this.labelAnyagkoltseg.TabIndex = 5;
            this.labelAnyagkoltseg.Text = "0 Ft";
            // 
            // labelMunkadij
            // 
            this.labelMunkadij.AutoSize = true;
            this.labelMunkadij.Location = new System.Drawing.Point(409, 696);
            this.labelMunkadij.Name = "labelMunkadij";
            this.labelMunkadij.Size = new System.Drawing.Size(35, 20);
            this.labelMunkadij.TabIndex = 6;
            this.labelMunkadij.Text = "0 Ft";
            // 
            // MunkalapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(804, 757);
            this.Controls.Add(this.labelMunkadij);
            this.Controls.Add(this.labelAnyagkoltseg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRogzites);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MunkalapForm";
            this.Text = "Munkalap készítés";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MunkalapForm_FormClosing);
            this.Load += new System.EventHandler(this.MunkalapForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRogzites;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private BindingSource workBindingSource;
        private Label labelAnyagkoltseg;
        private Label labelMunkadij;
    }
}