using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNPC : MonoBehaviour
{
    public GameObject NPC;

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Bandit>().isDeath == true)
        {
            NPC.SetActive(true);
        }
    }
}
