using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems : Editor
{
    [MenuItem("Tools/Painting/Paint")]
    public static void ShowPaintWindow ()
    {
        EditorWindow.GetWindow<PaintWindow>();
    }
    public static void PaintInRed()
    {
        var objectsWithMesh = FindObjectsOfType<WallController>();
        foreach (var obj in objectsWithMesh)
        {
            obj.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
        }
    }
}
