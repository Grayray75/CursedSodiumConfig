package io.grayray75.mods.cursedsodiumconfig.config;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import net.fabricmc.loader.api.FabricLoader;

import java.io.*;
import java.nio.file.Path;
import java.nio.file.Paths;

public class VideoConfigIO {
    private static final Gson GSON = new GsonBuilder().setPrettyPrinting().create();

    public static File getFilePath() {
        Path path = Paths.get(FabricLoader.getInstance().getGameDir().toString(), "data", "cursedsodiumconfig", "sodium-config.json");
        return new File(path.toString());
    }

    public static VideoConfig loadFile() {
        try {
            BufferedReader br = new BufferedReader(new FileReader(getFilePath()));
            VideoConfig config = GSON.fromJson(br, VideoConfig.class);
            return config;
        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }

    public static void saveFile(VideoConfig config) {
        try {
            String jsonString = GSON.toJson(config);
            FileWriter fileWriter = new FileWriter(getFilePath());
            fileWriter.write(jsonString);
            fileWriter.flush();
            fileWriter.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static void removeFile() {
        getFilePath().delete();
    }
}
