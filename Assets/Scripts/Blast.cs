using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
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
        
    }

    public void BlastBoss()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayers);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerTakeDamge>().takeDamge(attackDamge);

        }
    }
}
