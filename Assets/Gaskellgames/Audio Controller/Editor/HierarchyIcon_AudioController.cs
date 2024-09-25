#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.AudioController
{
    [InitializeOnLoad]
    public class HierarchyIcon_AudioController
    {
        #region Variables

        private static readonly Texture2D icon_SoundManager;
        private static readonly Texture2D icon_SoundController;
        private static readonly Texture2D icon_SoundEffect;

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Editor Loop

        static HierarchyIcon_AudioController()
        {
            icon_SoundManager = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Audio Controller/Editor/Icons/Icon_SoundManager.png", typeof(Texture2D)) as Texture2D;
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_SoundManager;
            
            icon_SoundController = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Audio Controller/Editor/Icons/Icon_SoundController.png", typeof(Texture2D)) as Texture2D;
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_SoundController;
            
            icon_SoundEffect = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Audio Controller/Editor/Icons/Icon_SoundEffect.png", typeof(Texture2D)) as Texture2D;
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_SoundEffect;
        }

        #endregion
        
        //----------------------------------------------------------------------------------------------------

        #region Private Functions

        private static void DrawHierarchyIcon_SoundManager(int instanceID, Rect position)
        {
            HierarchyUtility.DrawHierarchyIcon<SoundManager>(instanceID, position, icon_SoundManager);
        }
        
        private static void DrawHierarchyIcon_SoundController(int instanceID, Rect position)
        {
            HierarchyUtility.DrawHierarchyIcon<SoundController>(instanceID, position, icon_SoundController);
        }
        
        private static void DrawHierarchyIcon_SoundEffect(int instanceID, Rect position)
        {
            HierarchyUtility.DrawHierarchyIcon<SoundEffect>(instanceID, position, icon_SoundEffect);
        }

        #endregion
        
    } // class end
}

#endif