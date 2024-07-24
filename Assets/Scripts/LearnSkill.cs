using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnSkill : MonoBehaviour
{
    public void LearnSkillAttack()
    {
        FindObjectOfType<PlayerCombat2>().enabled = true;
        FindObjectOfType<GameSession>().UISkill();
        Destroy(gameObject);
    }
    public void LearnUntilAttack()
    {
        FindObjectOfType<PlayerCombat3>().enabled = true;
        FindObjectOfType<GameSession>().UIUntil();
        Destroy(gameObject);
    }
}
