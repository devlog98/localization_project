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

        // initial localization
        private void Start() {
            element = GetComponent<TextMeshProUGUI>();
            Localize();
        }

        // updates in game text
        public override void Localize() {
            element.text = LocalizationManager.instance.Localize(key);
        }
    }
}