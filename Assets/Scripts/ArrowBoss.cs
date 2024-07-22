using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ArrowBoss : MonoBehaviour
{
    bool Flip;
    public Vector2 boxSize;
    public float boxAngle;
    private SpriteRenderer spriteRenderer;
    public Transform attackPoint;
    
    public LayerMask playerLayers;
    public int DamgeSkill = 10;
    public float knockBackUp = 1f;
    public float knockBack = 5f;
    public float liveTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, liveTime);
        Flip = GetComponent<Bandit>().isFlip;
        if (Flip == true)
        {
            spriteRenderer.flipX = true;
        }
        else if (Flip == false)
        {
            spriteRenderer.flipX = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        Collider2D colInto = Physics2D.OverlapBox(attackPoint.position , boxSize, boxAngle, playerLayers);
        if (colInto != null)
        {
            colInto.GetComponent<PlayerTakeDamge>().takeDamge(DamgeSkill, knockBack, knockBackUp);
            Destroy(gameObject);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(attackPoint.position, boxSize);

    }
}
