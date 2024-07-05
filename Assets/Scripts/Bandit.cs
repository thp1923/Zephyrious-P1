using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    public Animator banditAim;
    public int maxHeath = 100;
    int currentHeath;
    public int DamgeEnemy = 10;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attack();
        }
    }
    void Attack()
    {
        FindObjectOfType<PlayerTakeDamge>().takeDamge(DamgeEnemy);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
