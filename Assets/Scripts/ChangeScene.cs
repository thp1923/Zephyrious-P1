using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        StartCoroutine(SceneBoss());
    }
    IEnumerator SceneBoss()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        SceneManager.LoadScene("BossRoom");
    }
}
