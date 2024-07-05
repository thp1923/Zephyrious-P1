using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamge : MonoBehaviour
{
    public GameObject Shield;
    public float timeShield = 5f;
    public float timeShieldCoolDown = 10f;
    float nextTime;
    bool haveShield = false;
    // Start is called before the first frame update
    void Start()
    {
        Shield.SetActive(false);
        
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
            FindObjectOfType<GameSession>().TakeLife(damgeEnemy);
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
