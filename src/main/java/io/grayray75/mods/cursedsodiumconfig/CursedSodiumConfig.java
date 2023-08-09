package io.grayray75.mods.cursedsodiumconfig;

import io.grayray75.mods.cursedsodiumconfig.config.VideoConfigIO;
import net.fabricmc.api.ClientModInitializer;
import net.fabricmc.api.EnvType;
import net.fabricmc.api.Environment;
import net.fabricmc.loader.api.FabricLoader;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;
import java.util.List;

@Environment(EnvType.CLIENT)
public class CursedSodiumConfig implements ClientModInitializer {

    public static String WinFormsExe;

    @Override
    public void onInitializeClient() {
        try {
            this.extractWinForms();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    private void extractWinForms() throws IOException {
        Path dataDir = Paths.get(FabricLoader.getInstance().getGameDir().toString(), "data");
        Path modDataDir = Paths.get(dataDir.toString(), "cursedsodiumconfig");
        Files.createDirectories(modDataDir);

        List<String> files = this.getResourceFiles("WinForms");

        for (int i = 0; i < files.size(); i++) {
            String fileName = files.get(i);

            InputStream fileStream = CursedSodiumConfig.class.getClassLoader().getResourceAsStream("WinForms/" + fileName);
            Path filePath = Paths.get(modDataDir.toString(), fileName);
            Files.copy(fileStream, filePath, StandardCopyOption.REPLACE_EXISTING);

            if (fileName.endsWith(".exe")) {
                WinFormsExe = filePath.toString();
            }
        }
    }

    private List<String> getResourceFiles(String path) throws IOException {
        List<String> filenames = new ArrayList<>();

        try (InputStream in = CursedSodiumConfig.class.getClassLoader().getResourceAsStream(path);
             BufferedReader br = new BufferedReader(new InputStreamReader(in))) {
            String resource;

            while ((resource = br.readLine()) != null) {
                filenames.add(resource);
            }
        }

        return filenames;
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
