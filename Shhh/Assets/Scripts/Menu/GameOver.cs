using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public Canvas over;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == FindObjectOfType<Player>().tag)
        {
            Time.timeScale = 0;
            GameObject ui = GameObject.Find("UI/");
            ui.SetActive(false);

            over.gameObject.SetActive(true);
        }
    }
}
