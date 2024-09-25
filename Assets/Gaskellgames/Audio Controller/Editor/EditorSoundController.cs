#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.AudioController
{
    [CustomEditor(typeof(SoundController))]
    public class EditorSoundController : GGEditor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty songNameHUD;
        SerializedProperty artistNameHUD;
        SerializedProperty albumArtworkHUD;

        SerializedProperty stopMusic;
        SerializedProperty stopEnvironment;
        SerializedProperty stopSoundFX;
        SerializedProperty stopMenuUI;

        SerializedProperty playOnLoad;

        SerializedProperty trackID;
        SerializedProperty albumArtwork;
        SerializedProperty loop;

        SerializedProperty playlistID;
        SerializedProperty shuffle;
        SerializedProperty repeat;

        bool referenceGroup = false;
        bool singleTrackGroup = false;
        bool playlistGroup = false;

        private void OnEnable()
        {
            songNameHUD = serializedObject.FindProperty("songNameHUD");
            artistNameHUD = serializedObject.FindProperty("artistNameHUD");
            albumArtworkHUD = serializedObject.FindProperty("albumArtworkHUD");

            stopMusic = serializedObject.FindProperty("stopMusic");
            stopEnvironment = serializedObject.FindProperty("stopEnvironment");
            stopSoundFX = serializedObject.FindProperty("stopSoundFX");
            stopMenuUI = serializedObject.FindProperty("stopMenuUI");

            playOnLoad = serializedObject.FindProperty("playOnLoad");

            trackID = serializedObject.FindProperty("trackID");
            albumArtwork = serializedObject.FindProperty("albumArtwork");
            loop = serializedObject.FindProperty("loop");

            playlistID = serializedObject.FindProperty("playlistID");
            shuffle = serializedObject.FindProperty("shuffle");
            repeat = serializedObject.FindProperty("repeat");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            SoundController soundController = (SoundController)target;
            serializedObject.Update();

            // draw banner if turned on in Gaskellgames settings
            EditorWindowUtility.DrawInspectorBanner("Assets/Gaskellgames/Audio Controller/Editor/Icons/inspectorBanner_AudioController.png");

            // references
            referenceGroup = EditorGUILayout.BeginFoldoutHeaderGroup(referenceGroup, "HUD References");
            if (referenceGroup)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(songNameHUD);
                EditorGUILayout.PropertyField(artistNameHUD);
                EditorGUILayout.PropertyField(albumArtworkHUD);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space();

            // custom inspector:
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(stopMusic);
            EditorGUILayout.PropertyField(stopEnvironment);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(stopSoundFX);
            EditorGUILayout.PropertyField(stopMenuUI);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(playOnLoad);
            EditorGUILayout.Space();

            string value = soundController.GetMusicOnLoad();
            if (value == "SingleTrack" || value == "PlaylistFollowingSingleTrack") { singleTrackGroup = true; } else { singleTrackGroup = false; }
            if (value == "Playlist" || value == "PlaylistFollowingSingleTrack") { playlistGroup = true; } else { playlistGroup = false; }

            if (singleTrackGroup)
            {
                EditorGUILayout.PropertyField(trackID);
                EditorGUILayout.PropertyField(albumArtwork);
            }
            if (singleTrackGroup && !playlistGroup)
            {
                EditorGUILayout.PropertyField(loop);
            }
            if (singleTrackGroup && playlistGroup)
            {
                EditorGUILayout.Space();
            }
            if (playlistGroup)
            {
                EditorGUILayout.PropertyField(playlistID);
                EditorGUILayout.PropertyField(shuffle);
                EditorGUILayout.PropertyField(repeat);
            }

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

    }// class end
}

#endif