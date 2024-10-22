using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerKnight : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rig;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpspeed = 30f;
    float currentSpeed;
    float currentJumpSpeed;
    CapsuleCollider2D col;
    Animator aim;
    public BoxCollider2D feet;
    public bool isAttack = false;
    public bool isTele = false;
    public int staminaMax = 100;
    public int recugeraceStamina = 30;
    public float recugeraceStaminaTime = 10f;
    public int stamina;
    float nextrecugeraceStaminaTime;
    AudioManager audioManager;
    public GameObject Speak;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        stamina = staminaMax;
    }
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        aim = GetComponent<Animator>();
        currentJumpSpeed = jumpspeed;
        currentSpeed = speed;
        stamina = staminaMax;
    }
    public void CostSatamina(int cost)
    {
        stamina -= cost;
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (value.isPressed)
        {
            rig.velocity += new Vector2(0f, jumpspeed);
        }
        audioManager.PlaySFX(audioManager.Jump);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Speak.SetActive(false);
        }
        staminaMax = FindObjectOfType<GameSession>().currentManaBuff;
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.K))
        {
            isAttack = true;
            speed = 0;
            jumpspeed = 0;
        }
        else
        {
            isAttack = false;
            speed = currentSpeed;
            jumpspeed = currentJumpSpeed;
        }
        Run();
        Flip();
        if (stamina >= staminaMax)
        {
            stamina = staminaMax;
            nextrecugeraceStaminaTime = Time.time + recugeraceStaminaTime;
        }
        else if (stamina < staminaMax && isAttack == false && Time.time >= nextrecugeraceStaminaTime)
        {
            stamina += recugeraceStamina;
            nextrecugeraceStaminaTime = Time.time + recugeraceStaminaTime;
        }
    }
    
    
    void Run()
    {
        if (isTele == true)
        {
            return;
        }
        rig.velocity = new Vector2(moveInput.x * speed, rig.velocity.y);

        bool havemove = Mathf.Abs(rig.velocity.x) > Mathf.Epsilon;
        aim.SetBool("Run", havemove);
        
        if (feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //Jump - false
            aim.SetBool("Jump", false);
        }
        else
        {
            //Jump - true
            aim.SetBool("Jump", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            Speak.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            Speak.SetActive(false);
        }
    }
    void Flip()
    {
        bool havemove = Mathf.Abs(rig.velocity.x) > Mathf.Epsilon;
        
        
        if (havemove)
        {

            transform.localScale = new Vector2(Mathf.Sign(rig.velocity.x), transform.localScale.y);
        }
        //RotatePlayer();
        
    }
    
}
