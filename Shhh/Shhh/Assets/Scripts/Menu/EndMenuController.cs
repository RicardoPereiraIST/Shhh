using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuController : MonoBehaviour {
    public Transform endMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == FindObjectOfType<Player>().tag)
            trigger();
    }

    public void trigger()
    {
        Time.timeScale = 0;
        GameObject.Find("ui/").SetActive(false);
        endMenu.gameObject.SetActive(true);
    }

    public void loadLevel(string id)
    {
        SceneManager.LoadScene(id);
        Time.timeScale = 1;
    }
}
