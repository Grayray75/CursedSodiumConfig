package io.grayray75.mods.cursedsodiumconfig.sodium;

public enum TranslationKeys {
    // General Options
    RenderDistance("options.renderDistance"),
    SimulationDistance("options.simulationDistance"),
    Brightness("options.gamma"),
    GuiScale("options.guiScale"),
    Fullscreen("options.fullscreen"),
    VSync("options.vsync"),
    MaxFramerate("options.framerateLimit"),
    ViewBobbing("options.viewBobbing"),
    AttackIndicator("options.attackIndicator"),
    AutosaveIndicator("options.autosaveIndicator"),

    // Quality Options
    Graphics("options.graphics"),
    Clouds("options.renderClouds"),
    Weather("soundCategory.weather"),
    Leaves("sodium.options.leaves_quality.name"),
    Particles("options.particles"),
    SmoothLighting("options.ao"),
    BiomeBlend("options.biomeBlendRadius"),
    EntityDistance("options.entityDistanceScaling"),
    EntityShadows("options.entityShadows"),
    Vignette("sodium.options.vignette.name"),
    MipmapLevels("options.mipmapLevels"),

    // Performance Options
    ChunkUpdateThreads("sodium.options.chunk_update_threads.name"),
    AlwaysDeferChunkUpdates("sodium.options.always_defer_chunk_updates.name"),
    UseBlockFaceCulling("sodium.options.use_block_face_culling.name"),
    UseFogOccusion("sodium.options.use_fog_occlusion.name"),
    UseEntityCulling("sodium.options.use_entity_culling.name"),
    AnimateOnlyVisibleTextures("sodium.options.animate_only_visible_textures.name"),
    UseNoErrorContext("sodium.options.use_no_error_context.name"),

    // Advanced Options
    UsePersistentMapping("sodium.options.use_persistent_mapping.name"),
    CpuRenderAhendLimit("sodium.options.cpu_render_ahead_limit.name");

    private final String key;

    private TranslationKeys(String key) {
        this.key = key;
    }

    public String getKey() {
        return key;
    }
}
