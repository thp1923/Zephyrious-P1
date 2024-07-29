using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public void Healing()
    {
        FindObjectOfType<GameSession>().Heal();
        Destroy(gameObject);
    }
}
