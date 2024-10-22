using System;
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
    public int staminaCost = 10;
    public float CDSkill;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CDSkill -= Time.deltaTime;
        if (Input.GetKey(KeyCode.K) && Time.time >= nextTime && 
            FindObjectOfType<PlayerKnight>().isAttack == true && 
            FindObjectOfType<PlayerKnight>().stamina >= staminaCost)
        {
            audioManager.PlaySFX(audioManager.SwordSkill);
            aim.SetTrigger("Attack2");
            GetComponent<PlayerKnight>().CostSatamina(staminaCost);
            nextTime = Time.time + TimeRate;
            CDSkill = TimeRate;
        }
    }
    void Attack2()
    {
        
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
    

    
}
