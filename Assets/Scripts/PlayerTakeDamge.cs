using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamge : MonoBehaviour
{
    public GameObject Shield;
    public float timeShield = 5f;
    public float timeShieldCoolDown = 10f;
    public float knockBack = 2f;
    public float knockBackUp = 2f;
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
        if(isAlive == false)
        {
            return;
        }
        nextTime -= Time.deltaTime;
        if (Input.GetKey(KeyCode.I) && nextTime <= 0)
        {
            OnShield();
            haveShield = true;
            nextTime = timeShieldCoolDown;
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
            FlipTakeDamge();
            rb.AddForce(transform.up * knockBackUp, ForceMode2D.Impulse);
            aim.SetTrigger("Hit");
            if (transform.localScale.x < 0)
            {

                rb.AddForce(transform.right * knockBack, ForceMode2D.Impulse);
            }
            else if (transform.localScale.x > 0)
            {

                rb.AddForce(transform.right * -knockBack, ForceMode2D.Impulse);
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
        rb.drag = 10f;
        rb.angularDrag = 10f;
        aim.SetBool("IsDeath", true);
        GetComponent<PlayerCombat>().enabled = false;
        GetComponent<PlayerKnight>().enabled = false;
        death.gameObject.SetActive(true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        
        
    }
    void FlipTakeDamge()
    {
        if(FindObjectOfType<Bandit>().isFlip == false)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if (FindObjectOfType<Bandit>().isFlip == true)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
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
