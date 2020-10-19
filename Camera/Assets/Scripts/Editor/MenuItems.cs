using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems : MonoBehaviour
{
    [MenuItem("Tools/Paint in red")]
    public static void PaintInRed()
    {
        var objectsWithMesh = FindObjectsOfType<WallController>();
        foreach (var obj in objectsWithMesh)
        {
            obj.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
