using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat3 : MonoBehaviour
{
    public GameObject attack;
    public Transform FirePoint;
    public float speed = 10f;
    public float TimeRate = 1f;
    public Animator aim;
    float nextTime;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.K) && Time.time >= nextTime && FindObjectOfType<PlayerKnight>().isAttack == true)
        {
            aim.SetTrigger("Attack3");

            nextTime = Time.time + TimeRate;
        }
    }
    void Attack3()
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
