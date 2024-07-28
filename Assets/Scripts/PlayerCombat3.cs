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
    public int staminaCost = 70;
    float nextTime;
    public float CDUntil;
    AudioManager audioManager;
    public GameObject Effect;

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
        CDUntil -= Time.deltaTime;
        if (Input.GetKey(KeyCode.L) && Time.time >= nextTime && 
            FindObjectOfType<PlayerKnight>().isAttack == true &&
            FindObjectOfType<PlayerKnight>().stamina >= staminaCost)
        {
            aim.SetTrigger("Attack3");
            Effect.SetActive(true);
            Time.timeScale = 0;
            GetComponent<PlayerKnight>().CostSatamina(staminaCost);
            nextTime = Time.time + TimeRate;
            CDUntil = TimeRate;
        }
    }
    public void UntilAudio()
    {
        audioManager.PlaySFX(audioManager.SwordUltimate);
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
