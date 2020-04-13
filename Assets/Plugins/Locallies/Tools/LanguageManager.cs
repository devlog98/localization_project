using Locallies.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Locallies.Tools {
    public class LanguageManager : MonoBehaviour {
        [SerializeField] List<LanguageItem> languages;

        [Space]
        [SerializeField] Image languageFlagUI;
        [SerializeField] TextMeshProUGUI languageNameUI;

        LanguageItem currentLanguage;
        int currentIndex;

        private void Start() {
            ChangeLanguage();
        }

        private void ChangeLanguage() {
            currentLanguage = languages[currentIndex];
            languageFlagUI.sprite = currentLanguage.languageFlagSprite;
            languageNameUI.text = currentLanguage.languageName;
            LocalizationManager.instance.LoadLocalizationFile(currentLanguage.fileName);
        }

        private void AddToIndex(int index) {
            currentIndex += index;

            if (currentIndex > languages.Count - 1) {
                currentIndex = 0;
            }
            else if (currentIndex < 0) {
                currentIndex = languages.Count - 1;
            }

            ChangeLanguage();
        }

        public void PreviousLanguage() {
            AddToIndex(-1);
        }

        public void NextLanguage() {
            AddToIndex(1);
        }
    }
}