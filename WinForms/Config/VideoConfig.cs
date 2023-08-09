using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursedSodiumConfig.WinForms.Config
{
    internal class VideoConfig : ICloneable
    {
        // General Options
        public int RenderDistance { get; set; } = 12;
        public int SimulationDistance { get; set; } = 12;
        public int Brightness { get; set; } = 50;

        public int GuiScale { get; set; } = 0;
        public bool Fullscreen { get; set; } = false;
        public bool VSync { get; set; } = true;
        public int MaxFramerate { get; set; } = 120;

        public bool ViewBobbing { get; set; } = true;
        public AttackIndicator AttackIndicator { get; set; } = AttackIndicator.Crosshair;
        public bool AutosaveIndicator { get; set; } = true;

        // Quality Options
        public GraphicsMode Graphics { get; set; } = GraphicsMode.Fancy;

        public bool Clouds { get; set; } = true;
        public GraphicsQuality Weather { get; set; } = GraphicsQuality.Default;
        public GraphicsQuality Leaves { get; set; } = GraphicsQuality.Default;
        public ParticlesMode Particles { get; set; } = ParticlesMode.All;
        public bool SmoothLighting { get; set; } = true;
        public int BiomeBlend { get; set; } = 2;
        public int EntityDistance { get; set; } = 100;
        public bool EntityShadows { get; set; } = true;
        public bool Vignette { get; set; } = true;

        public int MipmapLevels { get; set; } = 2;

        // Performance Options
        public int ChunkUpdateThreads { get; set; } = 0;
        public bool AlwaysDeferChunkUpdates { get; set; } = true;

        public bool UseBlockFaceCulling { get; set; } = true;
        public bool UseFogOccusion { get; set; } = true;
        public bool UseEntityCulling { get; set; } = true;
        public bool AnimateOnlyVisibleTextures { get; set; } = true;
        public bool UseNoErrorContext { get; set; } = true;

        // Advanced Options
        public bool UsePersistentMapping { get; set; } = true;
        public int CpuRenderAhendLimit { get; set; } = 3;

        public VideoConfig()
        {
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
