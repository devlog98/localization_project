using Locallies.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Base for all Game Objects to be localized
*/

namespace Locallies.Core {
    public abstract class LocalizeObject : MonoBehaviour {
        // used to find the correct translation
        [SerializeField] protected string key;

        // listeners setup
        protected void OnEnable() {
            LocalizationManager.MassLocalizationEvent += Localize;
        }
        protected void OnDisable() {
            LocalizationManager.MassLocalizationEvent -= Localize;
        }

        // updates in game text
        public abstract void Localize(bool canLocalize);
    }
}