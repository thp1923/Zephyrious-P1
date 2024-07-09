using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    // Qua màn dựa vào build setting.
    // Scene hiện tại
    private int currentScene;

    // lấy scene hiện tại
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    // kiểm tra va chạm với player
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // tăng scene lên 1 (trong build setting)
            int nextSceneIndex = currentScene + 1;

            // kiểm tra secne xem nó đã quá số lượng chưa
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                // chuyển scene kế tiếp
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                // Nếu scene đã hết thì về ban đầu
                SceneManager.LoadScene(0);
            }
        }
    }
}
