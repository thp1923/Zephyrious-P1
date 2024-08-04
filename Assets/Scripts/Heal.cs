using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Healing()
    {
        audioManager.PlaySFX(audioManager.Heal);
        FindObjectOfType<GameSession>().Heal();
        Destroy(gameObject);
    }
}
