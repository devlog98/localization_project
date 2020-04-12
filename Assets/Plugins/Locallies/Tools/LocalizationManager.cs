using Locallies.Core;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
 * Singleton used to deliver translations anywhere
 * Put this script into an empty Game Object to use it
*/

namespace Locallies.Tools {
    public class LocalizationManager : MonoBehaviour {
        //singleton instance
        public static LocalizationManager instance;

        //dictionary with data and related attributes
        private Dictionary<string, string> localDictionary;
        private string missingKey = "Localized string not found!";
        private bool isReady;

        //stores Localization File name
        private string localizationFile;

        //singleton setup
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }

            //line used to test file loading
            LoadLocalizationFile("en.json");
        }

        // loads data from Localization File into dictionary
        public void LoadLocalizationFile(string filename) {
            //searches Localization File
            string filepath = Path.Combine(Application.streamingAssetsPath, filename);

            //loads data from file
            LocalizationData localizationData = new LocalizationData();
            bool success = LocalizationParser.ReadLocalizationFile(filepath, out localizationData);

            //if operation successful...
            if (success) {
                //creates and populates dictionary
                localDictionary = new Dictionary<string, string>();
                foreach (LocalizationItem item in localizationData.items) {
                    localDictionary.Add(item.key, item.value);
                }

                //saves Localization File name
                localizationFile = filename;

                //sucessful debug
                Debug.Log("Data loaded! Dictionary contains " + localDictionary.Count + " entries!");
            }
            else {
                //error debug
                Debug.LogError("Cannot find Localization File!!");
            }
        }

        // gets value from dictionary or returns missing key message
        public string Localize(string key) {
            string result = missingKey;
            localDictionary.TryGetValue(key, out result);
            return result;
        }
    }
}