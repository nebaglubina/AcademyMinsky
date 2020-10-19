using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItems : MonoBehaviour
{
    [MenuItem("Tools/Load Level Additive")]
    public static void LoadLevelAdditive()
    {
        var selection = Selection.activeObject;
        EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selection), OpenSceneMode.Additive);
    }
    [MenuItem("Tools/Load Level Additive", true)]
    public static bool LoadLevelAdditiveValidation()
    {
        return Selection.activeObject != null && Selection.activeObject.GetType() == typeof(SceneAsset);
    }
}
