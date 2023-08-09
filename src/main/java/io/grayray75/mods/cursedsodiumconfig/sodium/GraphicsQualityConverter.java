package io.grayray75.mods.cursedsodiumconfig.sodium;

import me.jellysquid.mods.sodium.client.gui.SodiumGameOptions;

public class GraphicsQualityConverter {
    public static SodiumGameOptions.GraphicsQuality fromInt(int value) {
        return switch (value) {
            case 0 -> SodiumGameOptions.GraphicsQuality.DEFAULT;
            case 1 -> SodiumGameOptions.GraphicsQuality.FANCY;
            case 2 -> SodiumGameOptions.GraphicsQuality.FAST;
            default -> null;
        };
    }

    public static int getInt(SodiumGameOptions.GraphicsQuality graphicsQuality){
        return switch (graphicsQuality) {
            case DEFAULT -> 0;
            case FANCY -> 1;
            case FAST -> 2;
        };
    }
}
