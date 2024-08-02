using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoStopTime : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }
}
