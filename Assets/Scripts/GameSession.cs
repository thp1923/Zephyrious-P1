using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public int playerlivesMax = 1000;
    public int playerlives;
    public int score = 0;
    public int scoreCost = 100;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI scoreText2;
    public TMPro.TextMeshProUGUI Errors;

    public int powerPoint = 1;
    public int DefPoint = 1;
    public int HpPoint = 1;
    public int StaminaPoint = 1;

    public int UpPower = 10;
    public int UpDef = 10;
    public int UpHp = 10;
    public int UpMana = 10;

    public TMPro.TextMeshProUGUI PowerText;
    public TMPro.TextMeshProUGUI DefText;
    public TMPro.TextMeshProUGUI HpText;
    public TMPro.TextMeshProUGUI ManaText;

    public Slider liveSlider;
    public Slider staminaSlider;
    public Slider DefSlider;
    public GameObject gameOver;
    public GameObject UI;
    public GameObject stats;
    private void Start()
    {
        
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();
        playerlives = playerlivesMax;
        liveSlider.maxValue = playerlivesMax;
        liveSlider.value = playerlives;
        staminaSlider.maxValue = FindObjectOfType<PlayerKnight>().staminaMax;
        staminaSlider.value = FindObjectOfType<PlayerKnight>().stamina;
        DefSlider.maxValue = FindObjectOfType<PlayerTakeDamge>().DefMax;
        DefSlider.value = FindObjectOfType<PlayerTakeDamge>().Def;
        gameOver.SetActive(false);
    }
    IEnumerator DelText()
    {
        yield return new WaitForSecondsRealtime(3f);
        Errors.text = null;
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

    private void Update()
    {
        staminaSlider.maxValue = FindObjectOfType<PlayerKnight>().staminaMax;
        DefSlider.maxValue = FindObjectOfType<PlayerTakeDamge>().DefMax;
        liveSlider.maxValue = playerlivesMax;

        liveSlider.value = playerlives;
        staminaSlider.value = FindObjectOfType<PlayerKnight>().stamina;
        DefSlider.value = FindObjectOfType<PlayerTakeDamge>().Def;

        scoreText2.text = score.ToString();
        scoreText.text = score.ToString();
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

    public void PowerUp()
    {
        if(score < scoreCost)
        {
            TextError();
            return;
        }
        powerPoint += 1;
        score -= scoreCost;
        PowerText.text = powerPoint.ToString();
        Damge();
    }
    public void DefUp()
    {
        if (score < scoreCost)
        {
            TextError();
            return;
        }
        DefPoint += 1;
        score -= scoreCost;
        DefText.text = DefPoint.ToString();
        Def();
    }
    public void HpUp()
    {
        if (score < scoreCost)
        {
            TextError();
            return;
        }
        HpPoint += 1;
        score -= scoreCost;
        HpText.text = HpPoint.ToString();
        Hp();
    }
    public void ManaUp()
    {
        if (score < scoreCost)
        {
            TextError();
            return;
        }
        StaminaPoint += 1;
        score -= scoreCost;
        ManaText.text = StaminaPoint.ToString();
        Stamina();
    }
    public void Damge()
    {
        FindObjectOfType<PlayerCombat>().UpDamge(UpPower);
        FindObjectOfType<AttackPlayer>().UpDamge(UpPower);
        FindObjectOfType<UntilAttack>().UpDamge(UpPower);
        FindObjectOfType<ImpactPlayer>().UpDamge(UpPower);
    }
    public void Def()
    {
        FindObjectOfType<PlayerTakeDamge>().UpDef(UpDef);
    }
    public void Hp()
    {
        playerlivesMax += UpHp;
    }
    public void Stamina()
    {
        FindObjectOfType<PlayerKnight>().UpStamina(UpMana);
    }
    public void TextError()
    {
        Errors.text = "Not Enough Score";
        StartCoroutine(DelText());
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
        scoreText2.text = score.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        UI.SetActive(false);
        gameOver.SetActive(true);

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
