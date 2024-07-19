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

    public int BuffSkill = 2;
    public int BuffUntil = 3;
    public int BuffImpack = 2 ;// (damge/BuffImpact)
    public int currentDefBuff;
    public int currentManaBuff;
    public int currentPowerBuff;
    public int damgeSkill;
    public int damgeUntil;
    public int damgeImpact;

    public TMPro.TextMeshProUGUI CD1;
    public TMPro.TextMeshProUGUI CD2;
    public TMPro.TextMeshProUGUI CD3;
    public float Cd1 = 0.1f;
    public float Cd2 = 0.1f;
    public float Cd3 = 0.1f;
    public GameObject cd1;
    public GameObject cd2;
    public GameObject cd3;

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
        currentPowerBuff = FindObjectOfType<PlayerCombat>().attackDamge;
        damgeSkill = currentPowerBuff * BuffSkill;
        damgeUntil = currentPowerBuff * BuffUntil;
        damgeImpact = currentPowerBuff / BuffImpack;
        currentDefBuff = FindObjectOfType<PlayerTakeDamge>().DefMax;
        currentManaBuff = FindObjectOfType<PlayerKnight>().staminaMax;
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
        Cd1 = FindObjectOfType<PlayerCombat>().CDAttack - 0.1f;
        Cd2 = FindObjectOfType<PlayerCombat2>().CDSkill - 0.1f;
        Cd3 = FindObjectOfType<PlayerCombat3>().CDUntil - 0.1f;

        CD1.text = Cd1.ToString("F1");
        CD2.text = Cd2.ToString("F1");
        CD3.text = Cd3.ToString("F1");

        CD();

        staminaSlider.maxValue = FindObjectOfType<PlayerKnight>().staminaMax;
        DefSlider.maxValue = FindObjectOfType<PlayerTakeDamge>().DefMax;
        liveSlider.maxValue = playerlivesMax;

        liveSlider.value = playerlives;
        staminaSlider.value = FindObjectOfType<PlayerKnight>().stamina;
        DefSlider.value = FindObjectOfType<PlayerTakeDamge>().Def;

        scoreText2.text = score.ToString();
        scoreText.text = score.ToString();
    }

    public void CD()
    {
        if(Cd1 >= 0) { cd1.SetActive(true); } else { cd1.SetActive(false); }
        if(Cd2 >= 0) { cd2.SetActive(true); } else { cd2.SetActive(false); }
        if (Cd3 >= 0) {  cd3.SetActive(true); } else { cd3.SetActive(false); }
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
        currentPowerBuff = FindObjectOfType<PlayerCombat>().attackDamge + UpPower;
        damgeSkill = currentPowerBuff * BuffSkill;
        damgeUntil = currentPowerBuff * BuffUntil;
        damgeImpact = currentPowerBuff / BuffImpack;
    }
    
    
    public void Def()
    {
        currentDefBuff += UpDef;
    }
    public void Hp()
    {
        playerlivesMax += UpHp;
    }
    public void Stamina()
    {
        currentManaBuff += UpMana;
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
        //Destroy(gameObject); //destroy GameSession luon
        playerlives = playerlivesMax;
        
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
