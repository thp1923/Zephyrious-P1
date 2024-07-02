using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat2 : MonoBehaviour
{
    public GameObject attack;
    public Transform FirePoint;
    public float speed = 10f;
    public float TimeRate = 1f;
    public Animator aim;
    float nextTime;
    public Transform attackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamge = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L) && Time.time >= nextTime)
        {
            Attack2();
            Attack();
            nextTime = Time.time + TimeRate;
        }
    }
    void Attack2()
    {
        aim.SetTrigger("Attack2");
        GameObject Attack = Instantiate(attack, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = Attack.GetComponent<Rigidbody2D>();
        if (transform.localScale.x < 0)
        {

            rb.AddForce(transform.right * -speed, ForceMode2D.Impulse);
        }
        else if (transform.localScale.x > 0)
        {

            rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        }
    }
    void Attack()
    {
        

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Bandit>().TakeDamge(attackDamge);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
    }
}
