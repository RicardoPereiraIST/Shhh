using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public Transform mainMenu, controlMenu, creditsMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (controlMenu.gameObject.activeInHierarchy || creditsMenu.gameObject.activeInHierarchy)
            {
                controlMenu.gameObject.SetActive(false);
                creditsMenu.gameObject.SetActive(false);
                mainMenu.gameObject.SetActive(true);
            }
        }
    }

    public void loadLevel(string id)
    {
        SceneManager.LoadScene(id); 
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void controls(bool clicked)
    {
        controlMenu.gameObject.SetActive(clicked);
        mainMenu.gameObject.SetActive(!clicked);
    }

    public void credits(bool clicked)
    {
        creditsMenu.gameObject.SetActive(clicked);
        mainMenu.gameObject.SetActive(!clicked);
    }
}