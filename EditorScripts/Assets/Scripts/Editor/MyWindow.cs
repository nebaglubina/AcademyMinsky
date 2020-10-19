using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow
{
    [MenuItem("Window/My Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<MyWindow>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Do smth"))
        {
            Debug.Log("Something");
        }
    }
}
