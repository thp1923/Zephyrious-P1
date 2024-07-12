using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float RateTime = 1f;
    private float nextTime;

    public Animator aim;

    public Transform attackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamge = 20;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.J)&& Time.time >= nextTime && FindObjectOfType<PlayerKnight>().isAttack == true)
        {
            aim.SetTrigger("Attack1");
            nextTime = Time.time + RateTime;
        }
    }
    void Attack()
    {
        

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Bandit>().TakeDamge(attackDamge);
            

        }

    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
    }

    
}
