using System;

/*
 * The LocalizationItem script is the smallest unit of the system
 * It sets a key and its corresponding value, allowing the LocalizationManager to find translations by key
 * The class is Serializable to allow easy editing via Inspector
*/

namespace Locallies.Core {
    [Serializable]
    public class LocalizationItem {
        public string key; //string LocalizationManager will use to find translation
        public string value; //string LocalizationManager will give when asked for a translation
    }
}