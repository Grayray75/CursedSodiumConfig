using System.Drawing;
using System.Windows.Forms;
using CursedSodiumConfig.WinForms.Controls;

namespace CursedSodiumConfig.WinForms
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            tabSettings = new TabControl();
            tabGeneral = new TabPage();
            tabQuality = new TabPage();
            tabPerformance = new TabPage();
            tabAdvanced = new TabPage();
            pnlButtons = new Panel();
            btnDone = new Button();
            btnApply = new Button();
            btnUndo = new Button();
            pnlCoffee = new Panel();
            lblCoffee = new RgbLabel();
            btnCoffee = new Button();
            tabSettings.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlCoffee.SuspendLayout();
            SuspendLayout();
            // 
            // tabSettings
            // 
            tabSettings.Controls.Add(tabGeneral);
            tabSettings.Controls.Add(tabQuality);
            tabSettings.Controls.Add(tabPerformance);
            tabSettings.Controls.Add(tabAdvanced);
            tabSettings.Location = new Point(12, 12);
            tabSettings.Name = "tabSettings";
            tabSettings.SelectedIndex = 0;
            tabSettings.Size = new Size(390, 390);
            tabSettings.TabIndex = 0;
            // 
            // tabGeneral
            // 
            tabGeneral.Location = new Point(4, 24);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new Padding(3);
            tabGeneral.Size = new Size(382, 362);
            tabGeneral.TabIndex = 0;
            tabGeneral.Text = "General";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabQuality
            // 
            tabQuality.Location = new Point(4, 24);
            tabQuality.Name = "tabQuality";
            tabQuality.Padding = new Padding(3);
            tabQuality.Size = new Size(382, 362);
            tabQuality.TabIndex = 1;
            tabQuality.Text = "Quality";
            tabQuality.UseVisualStyleBackColor = true;
            // 
            // tabPerformance
            // 
            tabPerformance.Location = new Point(4, 24);
            tabPerformance.Name = "tabPerformance";
            tabPerformance.Padding = new Padding(3);
            tabPerformance.Size = new Size(382, 362);
            tabPerformance.TabIndex = 2;
            tabPerformance.Text = "Performance";
            tabPerformance.UseVisualStyleBackColor = true;
            // 
            // tabAdvanced
            // 
            tabAdvanced.Location = new Point(4, 24);
            tabAdvanced.Name = "tabAdvanced";
            tabAdvanced.Padding = new Padding(3);
            tabAdvanced.Size = new Size(382, 362);
            tabAdvanced.TabIndex = 3;
            tabAdvanced.Text = "Advanced";
            tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // pnlButtons
            // 
            pnlButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlButtons.Controls.Add(btnDone);
            pnlButtons.Controls.Add(btnApply);
            pnlButtons.Controls.Add(btnUndo);
            pnlButtons.Location = new Point(414, 365);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(319, 36);
            pnlButtons.TabIndex = 1;
            // 
            // btnDone
            // 
            btnDone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDone.Location = new Point(215, 3);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(100, 30);
            btnDone.TabIndex = 2;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // btnApply
            // 
            btnApply.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnApply.Location = new Point(109, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 30);
            btnApply.TabIndex = 1;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnUndo
            // 
            btnUndo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUndo.Location = new Point(3, 3);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(100, 30);
            btnUndo.TabIndex = 0;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // pnlCoffee
            // 
            pnlCoffee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlCoffee.BackColor = SystemColors.ControlLight;
            pnlCoffee.Controls.Add(lblCoffee);
            pnlCoffee.Controls.Add(btnCoffee);
            pnlCoffee.Location = new Point(549, 12);
            pnlCoffee.Name = "pnlCoffee";
            pnlCoffee.Size = new Size(184, 35);
            pnlCoffee.TabIndex = 2;
            pnlCoffee.Click += Coffee_Click;
            // 
            // lblCoffee
            // 
            lblCoffee.AutoSize = true;
            lblCoffee.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblCoffee.ForeColor = Color.FromArgb(70, 185, 0);
            lblCoffee.Location = new Point(3, 6);
            lblCoffee.Name = "lblCoffee";
            lblCoffee.Size = new Size(133, 23);
            lblCoffee.TabIndex = 2;
            lblCoffee.Text = "Buy us a coffee!";
            lblCoffee.Click += Coffee_Click;
            // 
            // btnCoffee
            // 
            btnCoffee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCoffee.FlatStyle = FlatStyle.Flat;
            btnCoffee.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCoffee.Location = new Point(152, 5);
            btnCoffee.Name = "btnCoffee";
            btnCoffee.Size = new Size(25, 25);
            btnCoffee.TabIndex = 1;
            btnCoffee.Text = "X";
            btnCoffee.UseVisualStyleBackColor = true;
            btnCoffee.Click += Coffee_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(745, 413);
            Controls.Add(pnlCoffee);
            Controls.Add(pnlButtons);
            Controls.Add(tabSettings);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sodium Video Options";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            tabSettings.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            pnlCoffee.ResumeLayout(false);
            pnlCoffee.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabSettings;
        private TabPage tabGeneral;
        private TabPage tabQuality;
        private TabPage tabPerformance;
        private TabPage tabAdvanced;
        private Panel pnlButtons;
        private Button btnDone;
        private Button btnApply;
        private Button btnUndo;
        private Panel pnlCoffee;
        private Button btnCoffee;
        private RgbLabel lblCoffee;
    }
}