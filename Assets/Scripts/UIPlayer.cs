using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerCombat2>().enabled == false)
        {
            FindObjectOfType<GameSession>().FalseSkill();
        }
        if (GetComponent<PlayerCombat3>().enabled == false)
        {
            FindObjectOfType<GameSession>().FalseUntil();
        }
    }
}
