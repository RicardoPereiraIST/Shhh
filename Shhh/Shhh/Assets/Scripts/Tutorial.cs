using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    List<Dictionary<string, bool>> sentences = new List<Dictionary<string, bool>>();
    int sentenceCount = 0;

    float startTime;
    float duration = 5;
    bool pressed = false;
    //bool pressedSecond = false;

    public GameObject text;
    public GameObject cubeToDestroy;
    public GameObject enemyPrefab;
    public GameObject distraction;

    bool instanciated = false;

    // Use this for initialization
    //void Start () {
    //    Dictionary<string, bool> sentence = new Dictionary<string, bool>();
    //    sentence.Add("Welcome to our tutorial. We will be teaching you the controls of our game!", true);
    //    sentences.Add(sentence);
    //    sentence = new Dictionary<string, bool>();
    //    sentence.Add("Let's start with movement. If you press WASD, you start moving!",false);
    //    sentences.Add(sentence);
    //    sentence = new Dictionary<string, bool>();
    //    sentence.Add("Well done. Now press shift to walk slower!",false);
    //    sentences.Add(sentence);
    //    sentence = new Dictionary<string, bool>();
    //    sentence.Add("Now let's try skills. For now, you have a scanner. Press 1 to try it out.", false);
    //    sentences.Add(sentence);
    //    sentence = new Dictionary<string, bool>();
    //    sentence.Add("Hmmm, what is that orange thing? Go find out.", false);
    //    sentences.Add(sentence);
    //    sentence = new Dictionary<string, bool>();
    //    sentence.Add("Now you have a key! In a real level, you could now open a door.", false);
    //    sentences.Add(sentence);
    //    sentence = new Dictionary<string, bool>();
    //    sentence.Add("Oh look, an enemy! Real enemies will chase you down if you get close.", false);
    //    sentences.Add(sentence);
    //    sentence = new Dictionary<string, bool>();
    //    sentence.Add("This one is a dummy. Use your new skill by pressing 2 and choose a place close to him with your mouse, to distract him.", false);
    //    sentences.Add(sentence);
    //    sentence = new Dictionary<string, bool>();
    //    sentence.Add("Congratulations! You've finished the tutorial. Later on you'll find more items and skills.", false);
    //    sentences.Add(sentence);
    //    sentence = new Dictionary<string, bool>();
    //    sentence.Add("We will now teleport you to the first level.", false);
    //    sentences.Add(sentence);
    //    startTime = Time.time;
    //    text.GetComponent<Text>().text = sentences[sentenceCount].Keys.First();
    //}
    
    void Start()
    {
        Dictionary<string, bool> sentence = new Dictionary<string, bool>();
        //0
        sentence.Add("Welcome to our tutorial!\n Here, you will learn the basics of \"Shhh\"", true);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //1
        sentence.Add("Let's start by moving around", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //2 - RUN
        sentence.Add("To walk, press the [W,A,S,D] keys.\n Walking doesn't make much noise.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //3
        sentence.Add("Well done! Now let's try running.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //4 - WALK
        sentence.Add("To run, hold the [Shift] key while moving.\n Running is noisy.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //5
        sentence.Add("Now, let's try using an ability.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //6 - SCAN
        sentence.Add("Right now, you only have the \"Scanner\" ability.\n Press [1] to try it out.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //7
        sentence.Add("Hmmm ... I wonder what that orange circle is?\n Let's go find out.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //8 - ITEM
        sentence.Add("Nice! You've found an item.\n More specifically, a key.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //9
        sentence.Add("In an actual level, that key would let you unlock a locked door.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //10
        sentence.Add("Look over there!\n A wild enemy has appeared!", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //11
        sentence.Add("Real enemies will chase you down if they hear you.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //12
        sentence.Add("Luckily, this one is just a dummy.\n Let's mess with him a little.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //13 - DISTRACT - STEP 1
        sentence.Add("To use your \"Distraction\" ability, press the [2] key.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //14 - DISTRACT - STEP 2
        sentence.Add("Now, use the [Left Mouse Button] to click on a spot inside the range circle, and close to the enemy.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //15
        sentence.Add("While playing, you will gain new abilities, and find different kinds of items.", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //16
        sentence.Add("Congratulations!\n You have successfully completed the tutorial!", false);
        sentences.Add(sentence);
        sentence = new Dictionary<string, bool>();
        //17 - END
        sentence.Add("We will now teleport you to the first level.\n Good luck!", false);
        sentences.Add(sentence);
        startTime = Time.time;
        text.GetComponent<Text>().text = sentences[sentenceCount].Keys.First();
    }

    void Update()
    {
        //BEGGINING
        if (sentenceCount == 0 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
            }
        }
        else if (sentenceCount == 1 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
            }
        }

        else if (sentenceCount == 2 && sentences[sentenceCount].Values.First() == true)
        {
            if (!pressed && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
                pressed = true;
                startTime = Time.time;
            }
            if (Time.time > startTime + duration && pressed)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                pressed = false;
                startTime = Time.time;
            }
        }

        else if (sentenceCount == 3 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
            }
        }

        else if (sentenceCount == 4 && sentences[sentenceCount].Values.First() == true)
        {
            if (!pressed && Input.GetKeyDown(KeyCode.LeftShift))
            {
                pressed = true;
                startTime = Time.time;
            }
            if (Time.time > startTime + duration && pressed)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                pressed = false;
                startTime = Time.time;
            }
        }

        else if (sentenceCount == 5 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
            }
        }


        else if (sentenceCount == 6 && sentences[sentenceCount].Values.First() == true)
        {
            if (!pressed && Input.GetKeyDown(KeyCode.Alpha1))
            {
                pressed = true;
                startTime = Time.time;
            }
            if (Time.time > startTime + 2 && pressed)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                pressed = false;
                startTime = Time.time;
            }
        }

        else if (sentenceCount == 7 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + 2)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                startTime = Time.time;
                Destroy(cubeToDestroy);
                pressed = false;
            }
        }

        else if (sentenceCount == 7 || sentenceCount == 8)
        {
            if (!pressed && Input.GetKeyDown(KeyCode.E))
            {
                sentenceCount++;
                pressed = true;
                sentences[sentenceCount - 1][sentences[sentenceCount - 1].Keys.First()] = false;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
            }
            else if (Time.time > startTime + duration && pressed)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
            }
        }

        else if (sentenceCount == 9 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
            }
        }

        else if (sentenceCount == 10 && sentences[sentenceCount].Values.First() == true)
        {
            if (!instanciated)
            {
                enemyPrefab.SetActive(true);
                instanciated = true;
            }

            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
                pressed = false;
                distraction.SetActive(true);
            }
        }

        else if (sentenceCount == 11 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
            }
        }

        else if (sentenceCount == 12 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
            }
        }

        else if (sentenceCount == 13 && sentences[sentenceCount].Values.First() == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;

            }
        }

        else if(sentenceCount == 14 && sentences[sentenceCount].Values.First() == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount--;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;

            }

            else if (Input.GetMouseButtonDown(0) && !pressed && sentenceCount == 14)
            {
                pressed = true;
                startTime = Time.time;
            }

            if (Time.time > startTime + duration && pressed)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
                pressed = false;
            }
        }

        else if (sentenceCount == 15 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
                pressed = false;
            }
        }

        else if (sentenceCount == 16 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + duration)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                sentenceCount++;
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
                startTime = Time.time;
                pressed = false;
            }
        }

        else if (sentenceCount == 17 && sentences[sentenceCount].Values.First() == true)
        {
            if (Time.time > startTime + 5)
            {
                sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
                SceneManager.LoadScene("level_01");
                GameManager.getInstance().addNewLevel();
            }
        }

        text.GetComponent<Text>().text = sentences[sentenceCount].Keys.First();
    }

    // Update is called once per frame
    //void Update () {
    //    if (sentenceCount == 0 && sentences[sentenceCount].Values.First() == true)
    //    {
    //        if (Time.time > startTime + duration)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            sentenceCount++;
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
    //            startTime = Time.time;
    //        }
    //    }

    //    else if (sentenceCount == 1 && sentences[sentenceCount].Values.First() == true)
    //    {
    //        if (!pressed && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
    //        {
    //            pressed = true;
    //            startTime = Time.time;
    //        }
    //        if (Time.time > startTime + duration && pressed)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            sentenceCount++;
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
    //            pressed = false;
    //        }
    //    }

    //    else if (sentenceCount == 2 && sentences[sentenceCount].Values.First() == true)
    //    {
    //        if (!pressed && Input.GetKeyDown(KeyCode.LeftShift))
    //        {
    //            pressed = true;
    //            startTime = Time.time;
    //        }
    //        if (Time.time > startTime + duration && pressed)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            sentenceCount++;
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
    //            pressed = false;
    //        }
    //    }

    //    else if (sentenceCount == 3 && sentences[sentenceCount].Values.First() == true)
    //    {
    //        if (!pressed && Input.GetKeyDown(KeyCode.Alpha1))
    //        {
    //            pressed = true;
    //            startTime = Time.time;
    //        }
    //        if (Time.time > startTime + 2 && pressed)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            sentenceCount++;
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
    //            pressed = false;
    //            startTime = Time.time;
    //        }
    //    }

    //    else if (sentenceCount == 4 && sentences[sentenceCount].Values.First() == true)
    //    {
    //        if (Time.time > startTime + 2)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            startTime = Time.time;
    //            Destroy(cubeToDestroy);
    //            pressed = false;
    //        }
    //    }

    //    else if (sentenceCount == 4 || sentenceCount == 5)
    //    {
    //        if (!pressed && Input.GetKeyDown(KeyCode.E))
    //        {
    //            sentenceCount++;
    //            pressed = true;
    //            sentences[sentenceCount - 1][sentences[sentenceCount - 1].Keys.First()] = false;
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
    //            startTime = Time.time;
    //        }
    //        else if (Time.time > startTime + duration && pressed)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            sentenceCount++;
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
    //            startTime = Time.time;
    //        }
    //    }

    //    else if (sentenceCount == 6 && sentences[sentenceCount].Values.First() == true)
    //    {
    //        if (!instanciated)
    //        {
    //            enemyPrefab.SetActive(true);
    //            instanciated = true;
    //        }

    //        if (Time.time > startTime + duration)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            sentenceCount++;
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
    //            startTime = Time.time;
    //            pressed = false;
    //            distraction.SetActive(true);
    //        }
    //    }

    //    else if (sentenceCount == 7 && sentences[sentenceCount].Values.First() == true)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Alpha2) && !pressed)
    //        {
    //            pressedSecond = !pressedSecond;
    //        }

    //        else if (pressedSecond && Input.GetMouseButtonDown(0) && !pressed)
    //        {
    //            pressed = true;
    //            startTime = Time.time;
    //        }

    //        if (Time.time > startTime + duration && pressed)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            sentenceCount++;
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
    //            startTime = Time.time;
    //            pressed = false;
    //        }
    //    }


    //    else if (sentenceCount == 8 && sentences[sentenceCount].Values.First() == true)
    //    {
    //        if (Time.time > startTime + duration)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            sentenceCount++;
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = true;
    //            startTime = Time.time;
    //            pressed = false;
    //        }
    //    }

    //    else if (sentenceCount == 9 && sentences[sentenceCount].Values.First() == true)
    //    {
    //        if (Time.time > startTime + 5)
    //        {
    //            sentences[sentenceCount][sentences[sentenceCount].Keys.First()] = false;
    //            SceneManager.LoadScene("level_01");
    //            GameManager.getInstance().addNewLevel();
    //        }
    //    }

    //    text.GetComponent<Text>().text = sentences[sentenceCount].Keys.First();
    //}
}
