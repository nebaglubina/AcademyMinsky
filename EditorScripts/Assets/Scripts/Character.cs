using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Experience;
    public int Level
    {
        get { return Experience / 750; }
    }
}
