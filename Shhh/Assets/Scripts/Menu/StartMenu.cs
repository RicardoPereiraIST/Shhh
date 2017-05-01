using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public void startGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("prototype_level_test");
    }

	public void exitGame()
    {
        Application.Quit();
    }
}
