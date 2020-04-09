using System;

/*
 * The LocalizationData script is the bridge between LocalizationManager and LocalizationItem
 * It stores as much LocalizationItems as desired and passes them to the Local Dictionary inside LocalizationManager
 * The class is Serializable to allow easy editing via Inspector
*/

namespace Locallies.Core {
    [Serializable]
    public class LocalizationData {
        public LocalizationItem[] items; //stores all localized strings to be used in the localization process
    }
}