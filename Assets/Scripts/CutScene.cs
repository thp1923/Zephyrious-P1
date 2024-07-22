using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneCutScene : MonoBehaviour
{
    public string SceneName;
    public Collider2D CutsceneCol;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        Cutscene();
    }
    void Cutscene()
    {
        if (CutsceneCol.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            SceneManager.LoadSceneAsync(SceneName);
            Debug.Log("Player is touching Cutscene collider");
        }
    }
}