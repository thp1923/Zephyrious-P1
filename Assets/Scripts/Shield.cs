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
        col = GetComponent<CapsuleCollider2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            return;
        }
        else
        {
            shield.SetTrigger("TakeDamge");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
