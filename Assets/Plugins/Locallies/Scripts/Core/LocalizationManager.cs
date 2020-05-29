using Locallies.Core;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
 * Static class used to manage translations anywhere
 * Responsible for loading files and returning translations
*/

namespace Locallies.Core {
    public static class LocalizationManager {
        // triggers localization on all elements at scene
        public static event Action<bool> MassLocalizationEvent = delegate { };

        // localized data
        private static Dictionary<string, string> localDictionary;
        private static string missingKey = "Localized string not found!";

        // default locale to be used
        private static string defaultLocalizationFile = "en.yml";

        // loads data from Localization File
        public static void LoadLocalizationFile(string filename) {
            // loads data from file
            LocalizationData localizationData = new LocalizationData();
            bool success = LocalizationParser.ReadLocalizationFile(filename, out localizationData);

            if (success) {
                // creates and populates dictionary
                localDictionary = new Dictionary<string, string>();
                foreach (LocalizationItem item in localizationData.items) {
                    localDictionary.Add(item.key, item.value);
                }

                // sucessful debug
                Debug.Log("Data loaded! Dictionary contains " + localDictionary.Count + " entries!");

                // mass localization
                MassLocalize();
            }
            else {
                // error debug
                Debug.LogError("Cannot find Localization File!!");
            }
        }

        // localizes all elements listening to event
        public static void MassLocalize() {
            MassLocalizationEvent(true);
        }

        // gets value from dictionary or returns missing key message
        public static string Localize(string key) {
            // loads default Localization File if no dictionary
            if (localDictionary == null) {
                LoadLocalizationFile(defaultLocalizationFile);
            }

            localDictionary.TryGetValue(key, out string result);
            result = String.IsNullOrEmpty(result) ? missingKey : result;

            return result;
        }
    }
}