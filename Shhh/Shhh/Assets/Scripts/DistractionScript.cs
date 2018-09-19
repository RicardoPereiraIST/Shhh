using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistractionScript : MonoBehaviour
{
    float distractionTime = 3.5f;

    // Use this for initialization
    void Start()
    {
        if (gameObject.activeSelf)
            Destroy(gameObject, distractionTime);
    }

    // Update is called once per frame
    public void Update()
    {
        if (FindObjectOfType<Player>().distractionEffect.enabled)
            FindObjectOfType<Player>().distractionEffect.enabled = false;
    }
}
