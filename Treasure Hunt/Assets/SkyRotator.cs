﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(0, 1, 0);
        transform.Rotate(v * Time.deltaTime);
    }
}
