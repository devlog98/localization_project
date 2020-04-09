using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The LocalizationManager script is the heart of the system
 * It is responsible for loading the localized data and providing it for other scripts
*/

namespace devlog98.Localization {
    public class LocalizationManager : MonoBehaviour {
        public static LocalizationManager instance; //singleton instance to be used anywhere

        Dictionary<string, string> localDictionary; //current loaded dictionary containing all translated sentences
        string missingKey = "Localized string not found!"; //text to be displayed when key is not found on local dictionary
        string filename; //the name of the current file loaded on local dictionary
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
    }
}