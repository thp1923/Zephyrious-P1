using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Playables;
public class CutSceneText : MonoBehaviour
{
    public GameObject Panel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public float timeNext = 1f;
    float nextTime;

    public GameObject nextButton;

    public float wordSpeed;
    public bool playerIsClose;
    public bool isSpeaking = false;
    void Update()
    {
        if (Time.time >= nextTime)
        {
            StartCoroutine(Typing());
            NextLine();
            nextTime = Time.time + timeNext;
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        Panel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {

            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {
        nextButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            isSpeaking = true;
            StartCoroutine(Typing());
        }
        else
        {
            isSpeaking = false;
            zeroText();
        }
    }
}
