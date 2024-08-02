using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamge : MonoBehaviour
{
    public GameObject Shield;
    public float timeShield = 5f;
    public float timeShieldCoolDown = 10f;
    
    public BoxCollider2D death;
    public Animator aim;
    public int DefMax = 500;
    public int Def;
    public int DefRegen = 50;
    public float DefRegenTime = 3f;
    float nextDefRegenTime;
    

    public bool isAlive = true;
    float nextTime;
    bool haveShield = false;
    Rigidbody2D rb;

    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        Shield.SetActive(false);
        aim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        death.gameObject.SetActive(false);
        Def = DefMax;
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (isAlive == false)
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
        if(Def >= DefMax)
        {
            Def = DefMax;
            nextDefRegenTime = Time.time + DefRegenTime;
        }
        else if (Def < DefMax && haveShield == false && Time.time >= nextDefRegenTime)
        {
            Def += DefRegen;
            nextDefRegenTime = Time.time + DefRegenTime;
        }
        if (Def < 0)
        {
            Def = 0;
            nextDefRegenTime = Time.time + DefRegenTime;
            haveShield = false;
            Shield.SetActive(false);
        }
        DefMax = FindObjectOfType<GameSession>().currentDefBuff;
    }
    

    public void takeDamge(int damgeEnemy, float knockBack, float knockBackUp)
    {
        if(haveShield == true)
        {
            Def -= damgeEnemy;
            audioManager.PlaySFX(audioManager.TakeDamgeShield);
        }
        else if (haveShield == false)
        {
            audioManager.PlaySFX(audioManager.TakeDamge);
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
            audioManager.PlaySFX(audioManager.GameOver);
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
    public void FlipTakeDamge(bool flip)
    {
        if(flip == true)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
            Debug.Log("Trai");
            
        }
        else if (flip == false)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
            Debug.Log("Phai");
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
