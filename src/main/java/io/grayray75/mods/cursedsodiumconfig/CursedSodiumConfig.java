package io.grayray75.mods.cursedsodiumconfig;

import io.grayray75.mods.cursedsodiumconfig.config.VideoConfigIO;
import net.fabricmc.api.ClientModInitializer;
import net.fabricmc.loader.api.FabricLoader;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.io.InputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.Arrays;
import java.util.List;

public class CursedSodiumConfig implements ClientModInitializer {
    private static Logger Logger;
    public static String WinFormsExe;

    @Override
    public void onInitializeClient() {
        Logger = LoggerFactory.getLogger("CursedSodiumConfig");

        try {
            Logger.info("Extracting WinForms files...");
            this.extractWinForms();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    private void extractWinForms() throws IOException {
        Path dataDir = Paths.get(FabricLoader.getInstance().getGameDir().toString(), "data");
        Path modDataDir = Paths.get(dataDir.toString(), "cursedsodiumconfig");
        Files.createDirectories(modDataDir);

        List<String> files = Arrays.asList(
                "CursedSodiumConfig.WinForms.deps.json",
                "CursedSodiumConfig.WinForms.dll",
                "CursedSodiumConfig.WinForms.exe",
                "CursedSodiumConfig.WinForms.runtimeconfig.json");

        for (int i = 0; i < files.size(); i++) {
            String fileName = files.get(i);

            InputStream fileStream = CursedSodiumConfig.class.getClassLoader().getResourceAsStream("assets/cursedsodiumconfig/WinForms/" + fileName);
            Path filePath = Paths.get(modDataDir.toString(), fileName);
            Files.copy(fileStream, filePath, StandardCopyOption.REPLACE_EXISTING);
            Logger.info("Extracted file: " + fileName);

            if (fileName.endsWith(".exe")) {
                WinFormsExe = filePath.toString();
            }
        }
    }

    public static Process openWinForms() {
        try {
            ProcessBuilder processBuilder = new ProcessBuilder(WinFormsExe, VideoConfigIO.getFilePath().toString());
            return processBuilder.start();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
