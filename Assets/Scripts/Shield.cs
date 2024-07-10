using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Animator shield;
    
    CapsuleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        shield = GetComponent<Animator>();
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
