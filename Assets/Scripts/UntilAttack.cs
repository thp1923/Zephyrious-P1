using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntilAttack : MonoBehaviour
{
    GameObject player;
    private SpriteRenderer spriteRenderer;
    public Transform attackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamgeSkill2;
    public float liveTime = 1f;
    public Transform impactPoint;
    public GameObject Impact;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (player.transform.localScale.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (player.transform.localScale.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        Destroy(gameObject, liveTime);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
    }

    // Update is called once per frame
    void Update()
    {
        buff();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<Bandit>().TakeDamge(attackDamgeSkill2);
            
            GameObject impact = Instantiate(Impact, impactPoint.position, impactPoint.rotation);
            Destroy(gameObject);
        }
    }

    public void buff()
    {
        attackDamgeSkill2 = FindObjectOfType<GameSession>().damgeUntil;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            GameObject impact = Instantiate(Impact, impactPoint.position, impactPoint.rotation);
            Destroy(gameObject);
        }
    }
}
