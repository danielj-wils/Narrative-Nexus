#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.AudioController
{
    public class MenuItemUtilityAudioController : MenuItemUtility
    {
        #region GameObject Menu

        [MenuItem(AudioController_GameObjectMenu_Path + "/Sound Manager", true, AudioController_GameObjectMenu_Priority)]
        private static bool Gaskellgames_GameobjectMenu_SoundManager()
        {
            return !(GameObject.FindObjectOfType<SoundManager>());
        }
        
        [MenuItem(AudioController_GameObjectMenu_Path + "/Sound Manager", false, AudioController_GameObjectMenu_Priority)]
        private static void Gaskellgames_GameobjectMenu_SoundManager(MenuCommand menuCommand)
        {
            // create a custom gameObject, register in the undo system, parent and set position relative to context
            GameObject go = SetupMenuItemInContext(menuCommand, "SoundManager [DDoL]");
            
            // Create child game objects
            GameObject goChild1 = new GameObject("AudioSource_Music");
            GameObject goChild2 = new GameObject("AudioSource_SoundFX");
            GameObject goChild3 = new GameObject("AudioSource_Environment");
            GameObject goChild4 = new GameObject("AudioSource_MenuUI");
            goChild1.transform.SetParent(go.transform);
            goChild2.transform.SetParent(go.transform);
            goChild3.transform.SetParent(go.transform);
            goChild4.transform.SetParent(go.transform);
            
            // Add scripts & components
            go.transform.position = Vector3.zero;
            SoundManager soundManager = go.AddComponent<SoundManager>();
            AudioSource source1 = goChild1.AddComponent<AudioSource>();
            AudioSource source2 = goChild2.AddComponent<AudioSource>();
            AudioSource source3 = goChild3.AddComponent<AudioSource>();
            AudioSource source4 = goChild4.AddComponent<AudioSource>();
            soundManager.AudioSourceMusic = source1;
            soundManager.AudioSourceSoundFX = source2;
            soundManager.AudioSourceEnvironment = source3;
            soundManager.AudioSourceMenuUI = source4;
            AudioMixer audioMixer = AssetDatabase.LoadAssetAtPath<AudioMixer>("Assets/Gaskellgames/Audio Controller/Content/MainMixer.mixer");
            AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Music");
            source1.outputAudioMixerGroup = audioMixGroup[0];
            audioMixGroup = audioMixer.FindMatchingGroups("SoundFX");
            source2.outputAudioMixerGroup = audioMixGroup[0];
            audioMixGroup = audioMixer.FindMatchingGroups("Environment");
            source3.outputAudioMixerGroup = audioMixGroup[0];
            audioMixGroup = audioMixer.FindMatchingGroups("UI");
            source4.outputAudioMixerGroup = audioMixGroup[0];
            
            // select newly created gameObject
            Selection.activeObject = go;
        }
        
        [MenuItem(AudioController_GameObjectMenu_Path + "/Sound Controller", true, AudioController_GameObjectMenu_Priority)]
        private static bool Gaskellgames_GameobjectMenu_SoundController()
        {
            return !(GameObject.FindObjectOfType<SoundController>());
        }
        
        [MenuItem(AudioController_GameObjectMenu_Path + "/Sound Controller", false, AudioController_GameObjectMenu_Priority)]
        private static void Gaskellgames_GameobjectMenu_SoundController(MenuCommand menuCommand)
        {
            // create a custom gameObject, register in the undo system, parent and set position relative to context
            GameObject go = SetupMenuItemInContext(menuCommand, "SoundController");
            
            // add scripts & components
            go.AddComponent<SoundController>();
            
            // select newly created gameObject
            Selection.activeObject = go;
        }
        
        [MenuItem(AudioController_GameObjectMenu_Path + "/3D Sound Effect", false, AudioController_GameObjectMenu_Priority + 15)]
        private static void Gaskellgames_GameobjectMenu_SoundEffect(MenuCommand menuCommand)
        {
            // create a custom gameObject, register in the undo system, parent and set position relative to context
            GameObject go = SetupMenuItemInContext(menuCommand, "SoundEffect");
            
            // add scripts & components
            go.AddComponent<SoundEffect>();
            
            // select newly created gameObject
            Selection.activeObject = go;
        }
        
        #endregion
        
    } // class end
}

#endif