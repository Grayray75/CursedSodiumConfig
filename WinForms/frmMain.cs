using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CursedSodiumConfig.WinForms.Config;
using CursedSodiumConfig.WinForms.Controls;
using CursedSodiumConfig.WinForms.Utils;

namespace CursedSodiumConfig.WinForms
{
    public partial class frmMain : Form
    {
        private readonly VideoConfig _originalConfig;
        private readonly VideoConfig _videoConfig;

        public frmMain()
        {
            InitializeComponent();

            _videoConfig = VideoConfigIO.ParseFile();
            _originalConfig = (VideoConfig)_videoConfig.Clone();

            ResetOptionGui();
        }

        private void ResetOptionGui()
        {
            tabGeneral.Controls.Clear();
            tabQuality.Controls.Clear();
            tabPerformance.Controls.Clear();
            tabAdvanced.Controls.Clear();

            OptionPages pages = new OptionPages(_videoConfig);
            AddOptionsToForm(tabGeneral, pages.GetGeneralOptions());
            AddOptionsToForm(tabQuality, pages.GetQualityOptions());
            AddOptionsToForm(tabPerformance, pages.GetPerformanceOptions());
            AddOptionsToForm(tabAdvanced, pages.GetAdvancedOptions());
        }

        private void AddOptionsToForm(Control parent, OptionGroup[] groups)
        {
            Panel[] panels = groups.Select(g => g.GetControl()).ToArray();

            int yOffset = 0;

            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Location = new Point(6, 6 + yOffset + 6 * i);
                yOffset += panels[i].Size.Height;
            }

            parent.Controls.AddRange(panels);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var comboBoxes = this.RecursiveControls().OfType<BetterComboBox>().ToArray();

            for (int i = 0; i < comboBoxes.Length; i++)
            {
                comboBoxes[i].PerformFormLoadedEvent(this, EventArgs.Empty);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            VideoConfigIO.SaveFile(_videoConfig);
        }

        private void Coffee_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://caffeinemc.net/donate") { UseShellExecute = true });
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            // It works :)
            // Just do not question it
            _originalConfig.CopyProperties(_videoConfig);
            ResetOptionGui();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            VideoConfigIO.SaveFile(_videoConfig);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
