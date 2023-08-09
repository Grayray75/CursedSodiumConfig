package io.grayray75.mods.cursedsodiumconfig.config;

public class VideoConfig {
    // General Options
    public int RenderDistance;
    public int SimulationDistance;
    public int Brightness;

    public int GuiScale;
    public boolean Fullscreen;
    public boolean VSync;
    public int MaxFramerate;

    public boolean ViewBobbing;
    public int AttackIndicator;
    public boolean AutosaveIndicator;

    // Quality Options
    public int Graphics;

    public boolean Clouds;
    public int Weather;
    public int Leaves;
    public int Particles;
    public boolean SmoothLighting;
    public int BiomeBlend;
    public int EntityDistance;
    public boolean EntityShadows;
    public boolean Vignette;

    public int MipmapLevels;

    // Performance Options
    public int ChunkUpdateThreads;
    public boolean AlwaysDeferChunkUpdates;

    public boolean UseBlockFaceCulling;
    public boolean UseFogOccusion;
    public boolean UseEntityCulling;
    public boolean AnimateOnlyVisibleTextures;
    public boolean UseNoErrorContext;

    // Advanced Options
    public boolean UsePersistentMapping;
    public int CpuRenderAhendLimit;
}
