package io.grayray75.mods.cursedsodiumconfig.mixin;

import io.grayray75.mods.cursedsodiumconfig.CursedSodiumConfig;
import io.grayray75.mods.cursedsodiumconfig.config.VideoConfig;
import io.grayray75.mods.cursedsodiumconfig.config.VideoConfigIO;
import io.grayray75.mods.cursedsodiumconfig.sodium.GraphicsQualityConverter;
import io.grayray75.mods.cursedsodiumconfig.sodium.TranslationKeys;
import me.jellysquid.mods.sodium.client.gui.SodiumGameOptions;
import me.jellysquid.mods.sodium.client.gui.SodiumOptionsGUI;
import me.jellysquid.mods.sodium.client.gui.options.Option;
import me.jellysquid.mods.sodium.client.gui.options.OptionPage;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.gui.DrawContext;
import net.minecraft.client.gui.screen.Screen;
import net.minecraft.client.option.AttackIndicator;
import net.minecraft.client.option.GraphicsMode;
import net.minecraft.client.option.ParticlesMode;
import net.minecraft.text.Text;
import org.spongepowered.asm.mixin.*;
import org.spongepowered.asm.mixin.injection.At;
import org.spongepowered.asm.mixin.injection.Inject;
import org.spongepowered.asm.mixin.injection.callback.CallbackInfo;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Mixin(SodiumOptionsGUI.class)
public abstract class SodiumOptionsGUIMixin extends Screen {
    @Shadow
    @Final
    private List<OptionPage> pages;

    @Shadow
    protected abstract void applyChanges();

    @Unique
    private Process winFormsProcess;
    @Unique
    private VideoConfig originalConfig;
    @Unique
    private final Map<String, Option<?>> optionControls = new HashMap<>();
    @Unique
    private boolean screenClosing = false;

    protected SodiumOptionsGUIMixin(Text title) {
        super(title);
    }

    @Inject(method = "init", at = @At("TAIL"))
    protected void init(CallbackInfo ci) {
        VideoConfig videoConfig = originalConfig = new VideoConfig();

        for (OptionPage page : this.pages) {
            for (Option<?> option : page.getOptions()) {
                // General Options
                if (option.getName().equals(Text.translatable(TranslationKeys.RenderDistance.getKey()))) {
                    optionControls.put(TranslationKeys.RenderDistance.getKey(), option);
                    videoConfig.RenderDistance = (int) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.SimulationDistance.getKey()))) {
                    optionControls.put(TranslationKeys.SimulationDistance.getKey(), option);
                    videoConfig.SimulationDistance = (int) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.Brightness.getKey()))) {
                    optionControls.put(TranslationKeys.Brightness.getKey(), option);
                    videoConfig.Brightness = (int) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.GuiScale.getKey()))) {
                    optionControls.put(TranslationKeys.GuiScale.getKey(), option);
                    videoConfig.GuiScale = (int) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.Fullscreen.getKey()))) {
                    optionControls.put(TranslationKeys.Fullscreen.getKey(), option);
                    videoConfig.Fullscreen = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.VSync.getKey()))) {
                    optionControls.put(TranslationKeys.VSync.getKey(), option);
                    videoConfig.VSync = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.MaxFramerate.getKey()))) {
                    optionControls.put(TranslationKeys.MaxFramerate.getKey(), option);
                    videoConfig.MaxFramerate = (int) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.ViewBobbing.getKey()))) {
                    optionControls.put(TranslationKeys.ViewBobbing.getKey(), option);
                    videoConfig.ViewBobbing = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.AttackIndicator.getKey()))) {
                    optionControls.put(TranslationKeys.AttackIndicator.getKey(), option);
                    videoConfig.AttackIndicator = ((AttackIndicator) option.getValue()).getId();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.AutosaveIndicator.getKey()))) {
                    optionControls.put(TranslationKeys.AutosaveIndicator.getKey(), option);
                    videoConfig.AutosaveIndicator = (boolean) option.getValue();
                }
                // Quality Options
                else if (option.getName().equals(Text.translatable(TranslationKeys.Graphics.getKey()))) {
                    optionControls.put(TranslationKeys.Graphics.getKey(), option);
                    videoConfig.Graphics = ((GraphicsMode) option.getValue()).getId();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.Clouds.getKey()))) {
                    optionControls.put(TranslationKeys.Clouds.getKey(), option);
                    videoConfig.Clouds = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.Weather.getKey()))) {
                    optionControls.put(TranslationKeys.Weather.getKey(), option);
                    videoConfig.Weather = GraphicsQualityConverter.getInt((SodiumGameOptions.GraphicsQuality) option.getValue());
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.Leaves.getKey()))) {
                    optionControls.put(TranslationKeys.Leaves.getKey(), option);
                    videoConfig.Leaves = GraphicsQualityConverter.getInt((SodiumGameOptions.GraphicsQuality) option.getValue());
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.Particles.getKey()))) {
                    optionControls.put(TranslationKeys.Particles.getKey(), option);
                    videoConfig.Particles = ((ParticlesMode) option.getValue()).getId();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.SmoothLighting.getKey()))) {
                    optionControls.put(TranslationKeys.SmoothLighting.getKey(), option);
                    videoConfig.SmoothLighting = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.BiomeBlend.getKey()))) {
                    optionControls.put(TranslationKeys.BiomeBlend.getKey(), option);
                    videoConfig.BiomeBlend = (int) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.EntityDistance.getKey()))) {
                    optionControls.put(TranslationKeys.EntityDistance.getKey(), option);
                    videoConfig.EntityDistance = (int) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.EntityShadows.getKey()))) {
                    optionControls.put(TranslationKeys.EntityShadows.getKey(), option);
                    videoConfig.EntityShadows = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.Vignette.getKey()))) {
                    optionControls.put(TranslationKeys.Vignette.getKey(), option);
                    videoConfig.Vignette = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.MipmapLevels.getKey()))) {
                    optionControls.put(TranslationKeys.MipmapLevels.getKey(), option);
                    videoConfig.MipmapLevels = (int) option.getValue();
                }
                // Performance Options
                else if (option.getName().equals(Text.translatable(TranslationKeys.ChunkUpdateThreads.getKey()))) {
                    optionControls.put(TranslationKeys.ChunkUpdateThreads.getKey(), option);
                    videoConfig.ChunkUpdateThreads = (int) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.AlwaysDeferChunkUpdates.getKey()))) {
                    optionControls.put(TranslationKeys.AlwaysDeferChunkUpdates.getKey(), option);
                    videoConfig.AlwaysDeferChunkUpdates = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.UseBlockFaceCulling.getKey()))) {
                    optionControls.put(TranslationKeys.UseBlockFaceCulling.getKey(), option);
                    videoConfig.UseBlockFaceCulling = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.UseFogOccusion.getKey()))) {
                    optionControls.put(TranslationKeys.UseFogOccusion.getKey(), option);
                    videoConfig.UseFogOccusion = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.UseEntityCulling.getKey()))) {
                    optionControls.put(TranslationKeys.UseEntityCulling.getKey(), option);
                    videoConfig.UseEntityCulling = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.AnimateOnlyVisibleTextures.getKey()))) {
                    optionControls.put(TranslationKeys.AnimateOnlyVisibleTextures.getKey(), option);
                    videoConfig.AnimateOnlyVisibleTextures = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.UseNoErrorContext.getKey()))) {
                    optionControls.put(TranslationKeys.UseNoErrorContext.getKey(), option);
                    videoConfig.UseNoErrorContext = (boolean) option.getValue();
                }
                // Advanced Options
                else if (option.getName().equals(Text.translatable(TranslationKeys.UsePersistentMapping.getKey()))) {
                    optionControls.put(TranslationKeys.UsePersistentMapping.getKey(), option);
                    videoConfig.UsePersistentMapping = (boolean) option.getValue();
                }
                else if (option.getName().equals(Text.translatable(TranslationKeys.CpuRenderAhendLimit.getKey()))) {
                    optionControls.put(TranslationKeys.CpuRenderAhendLimit.getKey(), option);
                    videoConfig.CpuRenderAhendLimit = (int) option.getValue();
                }
            }
        }

        VideoConfigIO.saveFile(videoConfig);
        winFormsProcess = CursedSodiumConfig.openWinForms();

        new Thread(() -> {
            try {
                winFormsProcess.waitFor();

                if (!screenClosing) {
                    MinecraftClient.getInstance().execute(() -> {
                        this.close();
                    });
                }
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
        }).start();
    }

    /**
     * @author Grayray75
     * @reason Don't render sodium gui
     */
    @Overwrite
    public void render(DrawContext drawContext, int mouseX, int mouseY, float delta) {
        super.renderBackground(drawContext);
        //super.render(drawContext, mouseX, mouseY, delta);
    }

    @Inject(method = "close", at = @At("HEAD"))
    public void close(CallbackInfo ci) {
        screenClosing = true;
        winFormsProcess.destroy();

        VideoConfig newConfig = VideoConfigIO.loadFile();
        VideoConfigIO.removeFile();

        // General Options
        if (originalConfig.RenderDistance != newConfig.RenderDistance) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.RenderDistance.getKey())).setValue(newConfig.RenderDistance);
        }
        if (originalConfig.SimulationDistance != newConfig.SimulationDistance) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.SimulationDistance.getKey())).setValue(newConfig.SimulationDistance);
        }
        if (originalConfig.Brightness != newConfig.Brightness) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.Brightness.getKey())).setValue(newConfig.Brightness);
        }
        if (originalConfig.GuiScale != newConfig.GuiScale) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.GuiScale.getKey())).setValue(newConfig.GuiScale);
        }
        if (originalConfig.Fullscreen != newConfig.Fullscreen) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.Fullscreen.getKey())).setValue(newConfig.Fullscreen);
        }
        if (originalConfig.VSync != newConfig.VSync) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.VSync.getKey())).setValue(newConfig.VSync);
        }
        if (originalConfig.MaxFramerate != newConfig.MaxFramerate) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.MaxFramerate.getKey())).setValue(newConfig.MaxFramerate);
        }
        if (originalConfig.ViewBobbing != newConfig.ViewBobbing) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.ViewBobbing.getKey())).setValue(newConfig.ViewBobbing);
        }
        if (originalConfig.AttackIndicator != newConfig.AttackIndicator) {
            ((Option<AttackIndicator>) this.optionControls.get(TranslationKeys.AttackIndicator.getKey())).setValue(AttackIndicator.byId(newConfig.AttackIndicator));
        }
        if (originalConfig.AutosaveIndicator != newConfig.AutosaveIndicator) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.AutosaveIndicator.getKey())).setValue(newConfig.AutosaveIndicator);
        }
        // Quality Options
        if (originalConfig.Graphics != newConfig.Graphics) {
            ((Option<GraphicsMode>) this.optionControls.get(TranslationKeys.Graphics.getKey())).setValue(GraphicsMode.byId(newConfig.Graphics));
        }
        if (originalConfig.Clouds != newConfig.Clouds) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.Clouds.getKey())).setValue(newConfig.Clouds);
        }
        if (originalConfig.Weather != newConfig.Weather) {
            ((Option<SodiumGameOptions.GraphicsQuality>) this.optionControls.get(TranslationKeys.Weather.getKey())).setValue(GraphicsQualityConverter.fromInt(newConfig.Weather));
        }
        if (originalConfig.Leaves != newConfig.Leaves) {
            ((Option<SodiumGameOptions.GraphicsQuality>) this.optionControls.get(TranslationKeys.Leaves.getKey())).setValue(GraphicsQualityConverter.fromInt(newConfig.Leaves));
        }
        if (originalConfig.Particles != newConfig.Particles) {
            ((Option<ParticlesMode>) this.optionControls.get(TranslationKeys.Particles.getKey())).setValue(ParticlesMode.byId(newConfig.Particles));
        }
        if (originalConfig.SmoothLighting != newConfig.SmoothLighting) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.SmoothLighting.getKey())).setValue(newConfig.SmoothLighting);
        }
        if (originalConfig.BiomeBlend != newConfig.BiomeBlend) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.BiomeBlend.getKey())).setValue(newConfig.BiomeBlend);
        }
        if (originalConfig.EntityDistance != newConfig.EntityDistance) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.EntityDistance.getKey())).setValue(newConfig.EntityDistance);
        }
        if (originalConfig.EntityShadows != newConfig.EntityShadows) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.EntityShadows.getKey())).setValue(newConfig.EntityShadows);
        }
        if (originalConfig.Vignette != newConfig.Vignette) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.Vignette.getKey())).setValue(newConfig.Vignette);
        }
        if (originalConfig.MipmapLevels != newConfig.MipmapLevels) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.MipmapLevels.getKey())).setValue(newConfig.MipmapLevels);
        }
        // Performance Options
        if (originalConfig.ChunkUpdateThreads != newConfig.ChunkUpdateThreads) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.ChunkUpdateThreads.getKey())).setValue(newConfig.ChunkUpdateThreads);
        }
        if (originalConfig.AlwaysDeferChunkUpdates != newConfig.AlwaysDeferChunkUpdates) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.AlwaysDeferChunkUpdates.getKey())).setValue(newConfig.AlwaysDeferChunkUpdates);
        }
        if (originalConfig.UseBlockFaceCulling != newConfig.UseBlockFaceCulling) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.UseBlockFaceCulling.getKey())).setValue(newConfig.UseBlockFaceCulling);
        }
        if (originalConfig.UseFogOccusion != newConfig.UseFogOccusion) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.UseFogOccusion.getKey())).setValue(newConfig.UseFogOccusion);
        }
        if (originalConfig.UseEntityCulling != newConfig.UseEntityCulling) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.UseEntityCulling.getKey())).setValue(newConfig.UseEntityCulling);
        }
        if (originalConfig.AnimateOnlyVisibleTextures != newConfig.AnimateOnlyVisibleTextures) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.AnimateOnlyVisibleTextures.getKey())).setValue(newConfig.AnimateOnlyVisibleTextures);
        }
        if (originalConfig.UseNoErrorContext != newConfig.UseNoErrorContext) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.UseNoErrorContext.getKey())).setValue(newConfig.UseNoErrorContext);
        }
        // Advanced Options
        if (originalConfig.UsePersistentMapping != newConfig.UsePersistentMapping) {
            ((Option<Boolean>) this.optionControls.get(TranslationKeys.UsePersistentMapping.getKey())).setValue(newConfig.UsePersistentMapping);
        }
        if (originalConfig.CpuRenderAhendLimit != newConfig.CpuRenderAhendLimit) {
            ((Option<Integer>) this.optionControls.get(TranslationKeys.CpuRenderAhendLimit.getKey())).setValue(newConfig.CpuRenderAhendLimit);
        }

        this.applyChanges();
    }
}
