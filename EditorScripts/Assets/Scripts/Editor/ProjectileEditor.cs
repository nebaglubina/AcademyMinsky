using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

    [CustomEditor(typeof(Projectile))]
public class ProjectileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();
        if (GUILayout.Button("Hello"))
        {
            Debug.Log("Hello");
        }
    }

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
    public static void DrawProjectile(Projectile proj, GizmoType gizmoType)
    {
        var trans = proj.transform;
        Gizmos.DrawSphere(trans.position, 1f);
    }

    private void OnSceneGUI()
    {
        Projectile proj = target as Projectile;
        Transform trans = proj.transform;
        proj.damageRadius = Handles.RadiusHandle(trans.rotation, trans.position, proj.damageRadius);
    }
}
