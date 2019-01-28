using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyTime : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 2);
    }
}