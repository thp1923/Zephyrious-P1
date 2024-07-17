using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactPlayer : MonoBehaviour
{
    public Transform attackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamgeSkill3;
    public float liveTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, liveTime);
    }

    // Update is called once per frame
    void Update()
    {
        attackDamgeSkill3 = FindObjectOfType<GameSession>().damgeImpact;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
    }
    public void Impact()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Bandit>().TakeDamge(attackDamgeSkill3);
            
        }

    }
    

}
