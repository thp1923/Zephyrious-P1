using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamge : MonoBehaviour
{
    public GameObject Shield;
    public float timeShield = 5f;
    public float timeShieldCoolDown = 10f;
    public float knockBack = 2f;
    public BoxCollider2D death;
    public Animator aim;

    public bool isAlive = true;
    float nextTime;
    bool haveShield = false;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Shield.SetActive(false);
        aim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        death.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I) && Time.time > nextTime)
        {
            OnShield();
            haveShield = true;
            nextTime = Time.time + timeShieldCoolDown;
        }
    }
    

    public void takeDamge(int damgeEnemy)
    {
        if(haveShield == true)
        {
            return;
        }
        else if (haveShield == false)
        {
            aim.SetTrigger("Hit");
            if (transform.localScale.x < 0)
            {

                rb.AddForce(transform.right * knockBack, ForceMode2D.Force);
            }
            else if (transform.localScale.x > 0)
            {

                rb.AddForce(transform.right * -knockBack, ForceMode2D.Force);
            }
            FindObjectOfType<GameSession>().TakeLife(damgeEnemy);
            
        }
        if (FindObjectOfType<GameSession>().playerlives <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        isAlive = false;
        aim.SetBool("IsDeath", true);
        GetComponent<PlayerCombat>().enabled = false;
        GetComponent<PlayerKnight>().enabled = false;
        death.gameObject.SetActive(true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        
        
    }
    void OnShield()
    {
        
        Shield.SetActive(true);
        StartCoroutine(OffShield());
    }

    IEnumerator OffShield()
    {
        yield return new WaitForSeconds(timeShield);
        haveShield = false;
        Shield.SetActive(false);
    }
}
