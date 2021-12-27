using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Lesson_8_FileManager
{
    [Serializable]
    public sealed class Config
    {
        private int _maxDepth;
        private int _printPages;

        public int MaxDepth
        {
            get
            {
                return _maxDepth;
            }

            set
            {
                _maxDepth = value;
            }
        }
        public int PrintPages
        {
            get
            {
                return _printPages;
            }
            set
            {
                _printPages = value;
            }
        }

        public static Config GetConfig()
        {
            string path = @"config.json";
            Config BackupConfig = new Config() { MaxDepth = 3, PrintPages = 25 };
            try
            {
                if (!File.Exists(path))
                {
                    string json = JsonSerializer.Serialize(BackupConfig);
                    File.WriteAllText(path, json);
                }

                string newConfig = File.ReadAllText(path);
                Config config = JsonSerializer.Deserialize<Config>(newConfig);
                return config;
            }
            catch (Exception)
            {
                Console.WriteLine("Произошла ошибка чтения файла config.json");
                return BackupConfig;
            }
        }
    }
}
