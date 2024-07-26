using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTele : MonoBehaviour
{
    GameObject Cong;
    public float time = 2f;
    public GameObject UI;
    public GameObject UIEffect;
    public Animator aimUI;
    public Animator aimUIEffect;
    // Update is called once per frame
    void Update()
    {
        if(Cong != null)
        {
            UI.SetActive(true);
            UIEffect.SetActive(true);
            Time.timeScale = 0;
            StartCoroutine(DichChuyen());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            Cong = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            Cong = null;
        }
    }
    IEnumerator DichChuyen()
    {
        yield return new WaitForSecondsRealtime(time);
        aimUI.SetTrigger("Close");
        aimUIEffect.SetTrigger("Close");
        Time.timeScale = 1;
        transform.position = Cong.GetComponent<Portal>().GetDiemDichChuyenDen().position;
        
    }
    
}
