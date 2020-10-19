using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [HideInInspector] public Rigidbody rigidbody;
    public float damageRadius = 1f;
    public string Foo = "Foo";
    [Space]
    [Tooltip("This is a tooltip")]
    [ContextMenuItem("Set random value", "SetRandomBar")]
    [Range(1, 100)] 
    public int bar = 5;

    void Reset()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void SetRandomBar()
    {
        bar = Random.Range(1, 100);
    }
}
