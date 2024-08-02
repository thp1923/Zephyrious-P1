using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsClose : MonoBehaviour
{
    
    public void OffStats()
    {
        gameObject.SetActive(false);
    }
    public void timeNext()
    {
        Time.timeScale = 1;
    }
}
