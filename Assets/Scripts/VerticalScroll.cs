﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [Tooltip ("Game Units Per Second")]
    [SerializeField] float scrollRate = 0.4f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, scrollRate * Time.deltaTime));
    }
}
