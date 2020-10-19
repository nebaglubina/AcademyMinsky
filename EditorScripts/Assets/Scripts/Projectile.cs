using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [HideInInspector] public Rigidbody rigidbody;
    public float damageRadius = 1f;

    void Reset()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
