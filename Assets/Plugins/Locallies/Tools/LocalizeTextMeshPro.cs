using Locallies.Core;
using TMPro;

/*
 * Localizes element of type TextMeshPro
 * Put this script into a TextMeshPro object to use it
*/

namespace Locallies.Tools {
    public class LocalizeTextMeshPro : LocalizeObject {
        // reference of TextMeshPro object
        private TextMeshProUGUI element;

        private void OnEnable() {
            LocalizationManager.MassLocalizationEvent += Localize;
        }
        private void OnDisable() {
            LocalizationManager.MassLocalizationEvent -= Localize;
        }

        // initial localization
        private void Start() {
            element = GetComponent<TextMeshProUGUI>();
            //Localize(true);
        }

        // updates in game text
        public override void Localize(bool canLocalize) {
            element.text = LocalizationManager.instance.Localize(key);
        }
    }
}