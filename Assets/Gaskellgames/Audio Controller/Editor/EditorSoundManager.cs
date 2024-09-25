#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.AudioController
{
    [CustomEditor(typeof(SoundManager))]
    public class EditorSoundManager : GGEditor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty mixerMaster;
        SerializedProperty mixerMusic;
        SerializedProperty mixerSoundFX;
        SerializedProperty mixerEnvironment;
        SerializedProperty mixerMenuUI;
        
        SerializedProperty _music;
        SerializedProperty _soundFX;
        SerializedProperty _environment;
        SerializedProperty _menuUI;
        SerializedProperty overrideMute;

        SerializedProperty music;
        SerializedProperty soundFX;
        SerializedProperty environment;
        SerializedProperty menuUI;

        SerializedProperty playlists;

        bool AudioSourceGroup = false;

        private void OnEnable()
        {
            mixerMaster = serializedObject.FindProperty("mixerMaster");
            mixerMusic = serializedObject.FindProperty("mixerMusic");
            mixerSoundFX = serializedObject.FindProperty("mixerSoundFX");
            mixerEnvironment = serializedObject.FindProperty("mixerEnvironment");
            mixerMenuUI = serializedObject.FindProperty("mixerMenuUI");
            
            _music = serializedObject.FindProperty("_music");
            _soundFX = serializedObject.FindProperty("_soundFX");
            _environment = serializedObject.FindProperty("_environment");
            _menuUI = serializedObject.FindProperty("_menuUI");
            overrideMute = serializedObject.FindProperty("overrideMute");

            music = serializedObject.FindProperty("music");
            soundFX = serializedObject.FindProperty("soundFX");
            environment = serializedObject.FindProperty("environment");
            menuUI = serializedObject.FindProperty("menuUI");

            playlists = serializedObject.FindProperty("playlists");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            SoundManager soundManager = (SoundManager)target;
            serializedObject.Update();

            // draw banner if turned on in Gaskellgames settings
            EditorWindowUtility.DrawInspectorBanner("Assets/Gaskellgames/Audio Controller/Editor/Icons/inspectorBanner_AudioController.png");

            // custom inspector:
            AudioSourceGroup = EditorGUILayout.BeginFoldoutHeaderGroup(AudioSourceGroup, "Audio Sources");
            if (AudioSourceGroup)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(_music);
                EditorGUILayout.PropertyField(_soundFX);
                EditorGUILayout.PropertyField(_environment);
                EditorGUILayout.PropertyField(_menuUI);
                EditorGUILayout.PropertyField(overrideMute);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUILayout.PropertyField(music);
            EditorGUILayout.PropertyField(soundFX);
            EditorGUILayout.PropertyField(environment);
            EditorGUILayout.PropertyField(menuUI);

            EditorGUILayout.PropertyField(playlists);

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
    
    }// class end
}

#endif