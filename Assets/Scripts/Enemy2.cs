using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Animator banditAim;
    public int maxHeath = 100;
    int currentHeath;
    public int DamgeEnemy = 10;
    Transform player;
    public Transform attackPoint;
    bool isFlip = false;
    Rigidbody2D rb;
    public Transform here;
    public float distance = 10f;


    public float attackRange = 2f;
    public LayerMask attackMask;
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHeath;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        Run();
        Debug.DrawRay(here.transform.position, Vector2.right * distance, Color.green);
        Debug.DrawRay(here.transform.position, Vector2.left * distance, Color.green);
    }
    void Run()
    {
        if (FindObjectOfType<PlayerTakeDamge>().isAlive == false)
        {
            banditAim.SetBool("IsRunning", false);
            return;
        }
        if (Vector2.Distance(player.position, here.position) < distance)
        {
            banditAim.SetBool("IsRunning", true);
        }
        else
        {
            banditAim.SetBool("IsRunning", false);
        }
    }
    public void Attack()
    {
        Collider2D colInfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerTakeDamge>().takeDamge(DamgeEnemy);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
    public void Flip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlip = false;
        }
        else if (transform.position.x < player.position.x && !isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlip = true;
        }
    }
}
