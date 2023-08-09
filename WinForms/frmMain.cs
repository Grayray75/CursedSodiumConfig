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

            AddOptionsToForm(tabGeneral, this.GetGeneralOptions());
            AddOptionsToForm(tabQuality, this.GetQualityOptions());
            AddOptionsToForm(tabPerformance, this.GetPerformanceOptions());
            AddOptionsToForm(tabAdvanced, this.GetAdvancedOptions());
        }

        #region Option GUI Generation

        private void AddOptionsToForm(Control parent, OptionGroup[] groups)
        {
            Panel[] panels = groups.Select(g => g.GetFormsControl()).ToArray();

            int yOffset = 0;

            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Location = new Point(6, 6 + yOffset + 6 * i);
                yOffset += panels[i].Size.Height;
            }

            parent.Controls.AddRange(panels);
        }

        private OptionGroup[] GetGeneralOptions()
        {
            List<OptionGroup> groups = new List<OptionGroup>();

            OptionGroup group1 = new OptionGroup("General1");
            group1.AddIntOption("Render Distance", _videoConfig, nameof(_videoConfig.RenderDistance), 2, 32);
            group1.AddIntOption("Simulation Distance", _videoConfig, nameof(_videoConfig.SimulationDistance), 5, 32);
            group1.AddIntOption("Brightness", _videoConfig, nameof(_videoConfig.Brightness), 0, 100);
            groups.Add(group1);

            OptionGroup group2 = new OptionGroup("General2");
            group2.AddIntOption("GUI Scale", _videoConfig, nameof(_videoConfig.GuiScale), 0, 4);
            group2.AddBoolOption("Fullscreen", _videoConfig, nameof(_videoConfig.Fullscreen));
            group2.AddBoolOption("VSync", _videoConfig, nameof(_videoConfig.VSync));
            group2.AddIntOption("Max Framerate", _videoConfig, nameof(_videoConfig.MaxFramerate), 10, 260, 10);
            groups.Add(group2);

            OptionGroup group3 = new OptionGroup("General3");
            group3.AddBoolOption("View Bobbing", _videoConfig, nameof(_videoConfig.ViewBobbing));
            group3.AddEnumOption("Attack Indicator", _videoConfig, nameof(_videoConfig.AttackIndicator), typeof(AttackIndicator));
            group3.AddBoolOption("Autosave Indicator", _videoConfig, nameof(_videoConfig.AutosaveIndicator));
            groups.Add(group3);

            return groups.ToArray();
        }

        private OptionGroup[] GetQualityOptions()
        {
            List<OptionGroup> groups = new List<OptionGroup>();

            OptionGroup group1 = new OptionGroup("Quality1");
            group1.AddEnumOption("Graphics", _videoConfig, nameof(_videoConfig.Graphics), typeof(GraphicsMode));
            groups.Add(group1);

            OptionGroup group2 = new OptionGroup("Quality2");
            group2.AddBoolOption("Clouds", _videoConfig, nameof(_videoConfig.Clouds));
            group2.AddEnumOption("Weather", _videoConfig, nameof(_videoConfig.Weather), typeof(GraphicsQuality));
            group2.AddEnumOption("Leaves", _videoConfig, nameof(_videoConfig.Leaves), typeof(GraphicsQuality));
            group2.AddEnumOption("Particles", _videoConfig, nameof(_videoConfig.Particles), typeof(ParticlesMode));
            group2.AddBoolOption("Smooth Lighting", _videoConfig, nameof(_videoConfig.SmoothLighting));
            group2.AddIntOption("Biome Blend", _videoConfig, nameof(_videoConfig.BiomeBlend), 1, 7);
            group2.AddIntOption("Entity Distance", _videoConfig, nameof(_videoConfig.EntityDistance), 50, 500, 25);
            group2.AddBoolOption("Entity Shadows", _videoConfig, nameof(_videoConfig.EntityShadows));
            group2.AddBoolOption("Vignette", _videoConfig, nameof(_videoConfig.Vignette));
            groups.Add(group2);

            OptionGroup group3 = new OptionGroup("Quality3");
            group3.AddIntOption("Mipmap Levels", _videoConfig, nameof(_videoConfig.MipmapLevels), 0, 4);
            groups.Add(group3);

            return groups.ToArray();
        }

        private OptionGroup[] GetPerformanceOptions()
        {
            List<OptionGroup> groups = new List<OptionGroup>();

            OptionGroup group1 = new OptionGroup("Performancey1");
            group1.AddIntOption("Chunk Update Threads", _videoConfig, nameof(_videoConfig.ChunkUpdateThreads), 0, Environment.ProcessorCount);
            group1.AddBoolOption("Always Defer Chunk Updates", _videoConfig, nameof(_videoConfig.AlwaysDeferChunkUpdates));
            groups.Add(group1);

            OptionGroup group2 = new OptionGroup("Performance2");
            group2.AddBoolOption("Use Block Face Culling", _videoConfig, nameof(_videoConfig.UseBlockFaceCulling));
            group2.AddBoolOption("Use Fog Occusion", _videoConfig, nameof(_videoConfig.UseFogOccusion));
            group2.AddBoolOption("Use Entity Culling", _videoConfig, nameof(_videoConfig.UseEntityCulling));
            group2.AddBoolOption("Animate Only Visible Textures", _videoConfig, nameof(_videoConfig.AnimateOnlyVisibleTextures));
            group2.AddBoolOption("Use No Error Context", _videoConfig, nameof(_videoConfig.UseNoErrorContext));
            groups.Add(group2);

            return groups.ToArray();
        }

        private OptionGroup[] GetAdvancedOptions()
        {
            List<OptionGroup> groups = new List<OptionGroup>();

            OptionGroup group1 = new OptionGroup("Advanced1");
            group1.AddBoolOption("Use Persistent Mapping", _videoConfig, nameof(_videoConfig.UsePersistentMapping));
            groups.Add(group1);

            OptionGroup group2 = new OptionGroup("Advanced2");
            group2.AddIntOption("CPU Render-Ahend Limit", _videoConfig, nameof(_videoConfig.CpuRenderAhendLimit), 0, 9);
            groups.Add(group2);

            return groups.ToArray();
        }

        #endregion

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
