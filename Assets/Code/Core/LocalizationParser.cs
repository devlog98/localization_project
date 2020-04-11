using System.IO;
using UnityEngine;
using YamlDotNet.Serialization;

namespace Locallies.Core {
    public class LocalizationParser {
        public static void WriteLocalizationFile(string filepath, LocalizationData localizationData) {
            string fileData = null;

            string fileExtension = Path.GetExtension(filepath);

            switch (fileExtension) {
                case ".json":
                    fileData = ToJson(localizationData);
                    break;
                case ".yml":
                    fileData = ToYaml(localizationData);
                    break;
            }

            File.WriteAllText(filepath, fileData);
        }

        public static LocalizationData ReadLocalizationFile(string filepath) {
            LocalizationData localizationData = null;

            if (File.Exists(filepath)) {
                //interprets file data
                string fileData = File.ReadAllText(filepath);

                string fileExtension = Path.GetExtension(filepath);

                switch (fileExtension) {
                    case ".json":
                        localizationData = FromJson(fileData);
                        break;
                    case ".yml":
                        localizationData = FromYaml(fileData);
                        break;
                }
            }

            return localizationData;
        }

        private static string ToJson(LocalizationData data) {
            return JsonUtility.ToJson(data);
        }

        private static LocalizationData FromJson(string data) {
            return JsonUtility.FromJson<LocalizationData>(data);
        }

        private static string ToYaml(LocalizationData data) {
            ISerializer serializer = new SerializerBuilder().Build();
            return serializer.Serialize(data);
        }

        private static LocalizationData FromYaml(string data) {
            IDeserializer deserializer = new DeserializerBuilder().Build();
            return deserializer.Deserialize<LocalizationData>(data);
        }
    }
}