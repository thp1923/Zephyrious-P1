using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bandit : MonoBehaviour
{
    
    public Animator banditAim;
    public int maxHeath = 100;
    int currentHeath;
    public int DamgeEnemy = 10;
    public float knockBack = 5f;
    public float knockBackUp = 1f;
    Transform player;
    public Transform attackPoint;
    public bool isFlip = false;
    Rigidbody2D rb;
    public Transform here;
    public float distance = 10f;
    public bool isBoss = false;
    public bool isDestroy = false;
    float stargravityscale;
    public Slider liveSlider;
    public int pointAdd = 10;
    AudioManager audioManager;
    public float attackRange = 2f;
    public LayerMask attackMask;
    public BoxCollider2D box;
    public bool isDeath = false;
    public bool haveGround;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHeath;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stargravityscale = rb.gravityScale;
        liveSlider.maxValue = maxHeath;
        liveSlider.value = maxHeath;
    }
    
    public void TakeDamge(int damge)
    {
        audioManager.PlaySFX(audioManager.EnemyHit);
        currentHeath -= damge;
        liveSlider.value = currentHeath;
        banditAim.SetTrigger("Hurt");
        if (currentHeath <= 0)
        {
            Die();
            Destroy();
        }
    }
    void Die()
    {
        isDeath = true;
        FindObjectOfType<GameSession>().AddScore(pointAdd);
        banditAim.SetBool("Death", true);
        Destroy(box);
        GetComponent<Collider2D>().enabled = false;
        rb.gravityScale = 0;
        rb.drag = 10;
        this.enabled = false;

    }
    void Destroy()
    {
        if(isDestroy == true)
        {
            Destroy(gameObject, 1.6f);
        }
    }

    //void Dodge()
    //{
    //    float ramdomDodge = Random.Range(-10f, 3f);
    //    if(isBoss == false)
    //    {
    //        return;
    //    }
    //    if (FindObjectOfType<PlayerKnight>().isAttack == true && ramdomDodge > 2 && 
    //        Vector2.Distance(player.position, here.position) < distance)
    //    {
    //        banditAim.SetTrigger("Dodge");
    //        isDodge = true;
    //    }
    //    else
    //    {
    //        isDodge = false;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        Run();
        //Dodge();
        Debug.DrawRay(here.transform.position, Vector2.right * distance, Color.green);
        Debug.DrawRay(here.transform.position, Vector2.left * distance, Color.green);
        if (!box.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            haveGround = false;
        }
        else
        {
            haveGround = true;
        }


    }
    void Run()
    {
        if (FindObjectOfType<PlayerTakeDamge>().isAlive == false)
        {
            banditAim.SetBool("IsRunning", false);
            return;
        }
        if (Vector2.Distance(player.position, here.position) < distance && haveGround == true)
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
        Collider2D[] colInfo = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackMask);
        foreach(Collider2D col in colInfo)
        {
            FindObjectOfType<PlayerTakeDamge>().FlipTakeDamge(isFlip);
            col.GetComponent<PlayerTakeDamge>().takeDamge(DamgeEnemy, knockBack, knockBackUp);
            
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

        if(transform.position.x > player.position.x && isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlip = false;
            liveSlider.direction = Slider.Direction.LeftToRight;
        }
        else if (transform.position.x < player.position.x && !isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlip = true;
            liveSlider.direction = Slider.Direction.RightToLeft;
        }
    }
}
