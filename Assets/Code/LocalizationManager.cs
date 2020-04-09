using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
 * The LocalizationManager script is the heart of the system
 * It is responsible for loading the localized data and providing it for other scripts
*/

namespace Locallies.Core {
    public class LocalizationManager : MonoBehaviour {
        public static LocalizationManager instance; //singleton instance to be used anywhere

        Dictionary<string, string> localDictionary; //current loaded dictionary containing all translated sentences
        string localFilename; //the name of the current file loaded on local dictionary
        string missingKey = "Localized string not found!"; //text to be displayed when key is not found on local dictionary
        bool isReady; //if local dictionary received all keys and now can translate sentences

        //singleton setup
        void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        // loads each translation from a LocalizationFile into the local dictionary
        public void LoadLocalizationFile(string filename) {
            localDictionary = new Dictionary<string, string>(); //creates new dictionary

            string filepath = Path.Combine(Application.streamingAssetsPath, filename); //finds path of Localization File using its filename
            
            //if file is found, else...
            if (File.Exists(filepath)) {
                string jsonData = File.ReadAllText(filepath); //reads the whole file
                LocalizationData localizationData = JsonUtility.FromJson<LocalizationData>(jsonData); //interprets jsonData text as a LocalizationData object

                //adds each LocalizationItem found in LocalizationData to the local dictionary
                foreach (LocalizationItem item in localizationData.items) {
                    localDictionary.Add(item.key, item.value);
                }

                localFilename = filename; //stores name of Localization File being used

                Debug.Log("Data loaded! Dictionary contains " + localDictionary.Count + " entries!"); //debugs size of local dictionary
            }
            else {
                Debug.LogError("Cannot find Localization File!!"); //debugs error on finding file
            }
        }
    }
}