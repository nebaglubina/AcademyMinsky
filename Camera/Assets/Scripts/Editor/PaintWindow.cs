using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PaintWindow : EditorWindow
{
    Color color = default;
    private void OnGUI()
    {
        color = EditorGUILayout.ColorField("Choose a color:", color);
        if (GUILayout.Button("Paint all walls"))
        {
            var objectsWithMesh = FindObjectsOfType<WallController>();
            foreach (var obj in objectsWithMesh)
            {
                obj.GetComponent<MeshRenderer>().sharedMaterial.color = color;
            }
        }

        if (GUILayout.Button("Restore original colors"))
        {
            var objectsWithMesh = FindObjectsOfType<WallController>();
            foreach (var obj in objectsWithMesh)
            {
                obj.GetComponent<MeshRenderer>().sharedMaterial.color = obj.startColor;
            }
        }
    }
}
