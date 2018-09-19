using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
    public Transform pauseMenu;
    public GameObject endMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !endMenu.activeInHierarchy)
        {
            pause();
        }
	}

    public void pause()
    {
        if (pauseMenu.gameObject.activeInHierarchy == false)
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void loadLevel(string id)
    {
        SceneManager.LoadScene(id);
        Time.timeScale = 1;
    }
}
