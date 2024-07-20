using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public Transform attackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamge = 20;
    public float knockBack = 5f;
    public float knockBackUp = 1f;
    AudioManager audioManager;
    // Start is called before the first frame update
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlastBoss()
    {
        audioManager.PlaySFX(audioManager.EnemyExplosion);
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayers);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerTakeDamge>().takeDamge(attackDamge, knockBack, knockBackUp);

        }
    }
}
