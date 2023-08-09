using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursedSodiumConfig.WinForms.Config
{
    internal static class VideoConfigIO
    {
        public static string ConfigPath = "./sodium-config.json";

        public static VideoConfig ParseFile()
        {
            try
            {
                string json = File.ReadAllText(ConfigPath);
                var config = JsonSerializer.Deserialize<VideoConfig>(json);

                if (config is null)
                {
                    return new VideoConfig();
                }
                else
                {
                    return config;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Couldn't parse config json!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex);
                return new VideoConfig();
            }
        }

        public static void SaveFile(VideoConfig videoConfig)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(videoConfig, options);
                File.WriteAllText(ConfigPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Couldn't save config json!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex);
            }
        }
    }
}
