using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character))]
public class MyCharacterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Character mc = target as Character;
        EditorGUILayout.LabelField("Level", mc.Level.ToString());
    }
}
