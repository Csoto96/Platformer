using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuHud : MonoBehaviour
{
    public GameObject MenuScreen;
    public Button Resume;
    public Button Quit;
    void Start()
    {
        MenuScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (MenuScreen.activeInHierarchy == false)
            {
                MenuScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void Unpause()
    {
        MenuScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
