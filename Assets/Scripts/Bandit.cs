using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    public Animator banditAim;
    public int maxHeath = 100;
    int currentHeath;
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHeath;
    }
    
    public void TakeDamge(int damge)
    {
        currentHeath -= damge;
        banditAim.SetTrigger("Hurt");
        if (currentHeath <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        banditAim.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
