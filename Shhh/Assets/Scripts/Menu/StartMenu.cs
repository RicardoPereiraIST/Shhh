using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartMenu : MonoBehaviour {

    public GameObject img;
    public GameObject workaround;
    private bool isControlOn;

    void Start()
    {
        //Only for prototype, can't fix redraw
        if(img)
            img.SetActive(false);
    }

    void Update()
    {
        if (workaround)
        {
            workaround.SetActive(false);
            if (Input.GetButton("Fire1") && img.activeSelf)
            {
                //Only for prototype, can't fix redraw
                img.SetActive(false);
                workaround.SetActive(true);
            }
        }
    }

    public void startGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("prototype_level_test");
    }

	public void exitGame()
    {
        Application.Quit();
    }

    public void controls()
    {
        //Only for prototype, can't fix redraw
        img.SetActive(true);
    }
}
