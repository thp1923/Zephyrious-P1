using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamge : MonoBehaviour
{
    public GameObject Shield;
    public float timeShield = 5f;
    public float timeShieldCoolDown = 10f;
    float nextTime;
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
            nextTime = Time.time + timeShieldCoolDown;
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
        Shield.SetActive(false);
    }
}
