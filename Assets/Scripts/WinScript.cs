using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public GameObject ScreenDisplay;
    public Inventory Wincon;
    public Button Restart;
    public Button Quit;
    void Start()
    {
        ScreenDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Wincon.Coins == 8)
        {
            ScreenDisplay.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1f;
    }

    public void QuitFun()
    {
        Application.Quit();
    }
}
