using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string Scenename;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(Scenename);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
