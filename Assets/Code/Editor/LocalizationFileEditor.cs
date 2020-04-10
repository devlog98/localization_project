using Locallies.Core;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

/*
 * Creates an editor window in order to manage Localization Files without any additional software
 * Window located at Window/Locallies/Localization File Editor
*/

namespace Locallies.Tools {
    public class LocalizationFileEditor : EditorWindow {
        //data from the Localization File
        public LocalizationData localizationData;

        // window scroll position
        private Vector2 scrollPosition;

        //initializes window at path
        [MenuItem("Window/Locallies/Localization File Editor")]
        private static void Init() {
            EditorWindow.GetWindow(typeof(LocalizationFileEditor)).Show();
        }

        //window behaviour
        private void OnGUI() {
            //begin scroll
            scrollPosition = BeginScrollView(); 

            //if file is loaded...
            if (localizationData != null) {
                //allows data to be edited via Inspector
                SerializedObject serializedObject = new SerializedObject(this);
                SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");
                EditorGUILayout.PropertyField(serializedProperty, true);

                //apply changes
                serializedObject.ApplyModifiedProperties();

                //save file button
                if (GUILayout.Button("Save File")) {
                    SaveLocalizationFile();
                }
            }

            //load file button
            if (GUILayout.Button("Load File")) {
                LoadLocalizationFile();
            }

            //new file button
            if (GUILayout.Button("Load File")) {
                NewLocalizationFile();
            }

            //end scroll
            EndScrollView(); 
        }

        //creates new file
        private void NewLocalizationFile() {
            localizationData = new LocalizationData();
        }

        //saves current file
        private void SaveLocalizationFile() {
            //save window
            string filepath = EditorUtility.SaveFilePanel("Save Localization File", Application.streamingAssetsPath, "language", "json");

            //if valid path, save data onto Localization File
            if (!String.IsNullOrEmpty(filepath)) {
                string jsonData = JsonUtility.ToJson(localizationData);
                File.WriteAllText(filepath, jsonData);
            }
        }

        //loads file
        private void LoadLocalizationFile() {
            //load window
            string filepath = EditorUtility.OpenFilePanel("Load Localization File", Application.streamingAssetsPath, "json");

            //if valid path, load data from Localization File
            if (!String.IsNullOrEmpty(filepath)) {
                string jsonData = File.ReadAllText(filepath);
                localizationData = JsonUtility.FromJson<LocalizationData>(jsonData);
            }
        }

        //begins scroll
        private Vector2 BeginScrollView() {
            //window scroll properties
            bool horizontalScroll = true;
            bool verticalScroll = true;

            //window size properties
            float windowWidth = this.position.width;
            float windowHeight = this.position.height;
            
            //returns scroll position
            return GUILayout.BeginScrollView(scrollPosition, horizontalScroll, verticalScroll, GUILayout.Width(windowWidth), GUILayout.Height(windowHeight));
        }

        //ends scroll
        private void EndScrollView() {
            GUILayout.EndScrollView();
        }
    }
}