using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerKnightBT : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rig;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpspeed = 30f;
    CapsuleCollider2D col;
    Animator aim;
    public BoxCollider2D feet;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        aim = GetComponent<Animator>();
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
        if (feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //Jump - false
            aim.SetFloat("MoveY", 0);
        }
        else
        {
            //Jump - true
            aim.SetFloat("MoveY", 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
    }
    void Run()
    {
        rig.velocity = new Vector2(moveInput.x * speed, rig.velocity.y);

        bool havemove = Mathf.Abs(rig.velocity.x) > Mathf.Epsilon;
        aim.SetBool("IsRunning", havemove);
        aim.SetFloat("MoveX", 1);
        Debug.Log("Run");

        if (feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //Jump - false
            aim.SetFloat("MoveY", 0);
            Debug.Log("Jump - false");
        }
        else
        {
            //Jump - true
            aim.SetFloat("MoveX", 0);
            aim.SetFloat("MoveY", 1);
            Debug.Log("Jump - true");
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
