using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public int playerlives = 1000;
    public int score = 0;
    public TMPro.TextMeshProUGUI scoreText;

    public Slider liveSlider;
    public GameObject gameOver;
    public GameObject UI;
    private void Start()
    {
        //scoreText.text = score.ToString();

        liveSlider.value = playerlives;
    }

    private void Awake()
    {
        //so luong doi tuong GameSession
        int numbersession = FindObjectsOfType<GameSession>().Length;
        //neu no co nhieu hon phien ban thi se huy no
        if (numbersession > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject); //khong cho huy khi load
    }

    //khi player chet
    public void PlayerDeath()
    {
        GameOver();
    }

    //doat mang
    public void TakeLife(int damgeEnemy)
    {

        playerlives -= damgeEnemy;//giam mang
        liveSlider.value = playerlives;
        if (playerlives <= 0)
        {
            PlayerDeath();
        }
    }

    

    //het mang, reset toan bo, choi lai tu dau
    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);//load lai Scene 0
        Time.timeScale = 1;
        Destroy(gameObject); //destroy GameSession luon

    }
    public void Play()
    {

        Destroy(gameObject);
    }

    public void PlayAgain()
    {
        //lay index cua scene hien tai
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        //load lai scene hien tai

        SceneManager.LoadScene(currentsceneindex);
        Time.timeScale = 1;
        Destroy(gameObject); //destroy GameSession luon
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = score.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        //UI.SetActive(false);
        //gameOver.SetActive(true);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void youWin()
    {
        UI.SetActive(false);
        SceneManager.LoadScene("Win");
        Destroy(gameObject);
    }
}
