using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTele : MonoBehaviour
{
    GameObject Cong;
    GameObject Cong2;
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
        if (Cong2 != null)
        {
            UI.SetActive(true);
            UIEffect.SetActive(true);
            Time.timeScale = 0;
            StartCoroutine(SceneBoss());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            Cong = collision.gameObject;
        }
        if (collision.CompareTag("Portal2"))
        {
            Cong2 = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            Cong = null;
        }
        if (collision.CompareTag("Portal2"))
        {
            Cong2 = null;
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
    IEnumerator SceneBoss()
    {
        yield return new WaitForSecondsRealtime(time);
        aimUI.SetTrigger("Close");
        aimUIEffect.SetTrigger("Close");
        SceneManager.LoadScene("BossRoom");
        Time.timeScale = 1;
    }
}
