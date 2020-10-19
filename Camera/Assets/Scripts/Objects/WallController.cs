using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{

    public Color startColor;

    private void Reset()
    {
        startColor = GetComponent<MeshRenderer>().sharedMaterial.color;
    }

    public void SetStartingColor()
    {
        GetComponent<MeshRenderer>().sharedMaterial.color = startColor;
    }
}
