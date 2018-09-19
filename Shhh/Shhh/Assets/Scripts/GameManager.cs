using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager
{
    private bool recordLogs = false;

    private int level = 1;
    private int attempt = 1;
    private float lastTime = 0;
    public static GameManager instance = null;
    public Dictionary<int, Dictionary<int, InformationSet>> info;

    GameManager()
    {
        Dictionary<int, InformationSet> dict = new Dictionary<int, InformationSet>();
        dict.Add(attempt, new InformationSet());
        info = new Dictionary<int, Dictionary<int, InformationSet>>();
        info.Add(level, dict);
    }

    public static GameManager getInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }

        return instance;
    }

    public void getEnemies()
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.getEnemies();
    }

    public void getSkills()
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.getSkills();
    }

    public void getItems()
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.getItems();
    }

    public void getMovement()
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.getMovement();
    }

    public void getLogEnemies(StreamWriter logFile, int l, int a)
    {
        InformationSet temp;
        info[l].TryGetValue(a, out temp);
        temp.getLogEnemies(logFile);
    }

    public void getLogSkills(StreamWriter logFile, int l, int a)
    {
        InformationSet temp;
        info[l].TryGetValue(a, out temp);
        temp.getLogSkills(logFile);
    }

    public void getLogItems(StreamWriter logFile, int l, int a)
    {
        InformationSet temp;
        info[l].TryGetValue(a, out temp);
        temp.getLogItems(logFile);
    }

    public void getLogMovement(StreamWriter logFile, int l, int a)
    {
        InformationSet temp;
        info[l].TryGetValue(a, out temp);
        temp.getLogMovement(logFile);
    }

    public void getLogTime(StreamWriter logFile, int l, int a)
    {
        InformationSet temp;
        info[l].TryGetValue(a, out temp);
        temp.getLogTime(logFile);
    }

    public void writeToFile()
    {
        int rng = UnityEngine.Random.Range(0, int.MaxValue - 1);

        if (recordLogs)
        {
            if (!Directory.Exists(Application.dataPath + "\\Logs"))
                Directory.CreateDirectory(Application.dataPath + "\\Logs");

            string logstr = Application.dataPath + "\\Logs\\log_" + rng + ".txt";
            while (File.Exists(logstr))
            {
                rng = UnityEngine.Random.Range(0, sizeof(int) - 1);
                logstr = "log_" + rng + ".txt";
            }

            StreamWriter logFile = File.CreateText(logstr);
            foreach (int l in info.Keys)
            {
                logFile.WriteLine("\r\n\r\nLevel " + l + "\r\n");
                foreach (int a in info[l].Keys)
                {
                    logFile.WriteLine("\r\nAttempt " + a + "\r\n");
                    logFile.WriteLine("Time:");
                    getLogTime(logFile, l, a);
                    logFile.WriteLine("\r\nEnemies:\r\n");
                    getLogEnemies(logFile, l, a);
                    logFile.WriteLine("\r\nSkills:\r\n");
                    getLogSkills(logFile, l, a);
                    logFile.WriteLine("\r\nItems:\r\n");
                    getLogItems(logFile, l, a);
                    logFile.WriteLine("\r\nMovement:\r\n");
                    getLogMovement(logFile, l, a);
                }
            }
            logFile.Flush();
            logFile.Close();
        } 
    }

    public void addNewLevel()
    {
        addTime(Time.time - lastTime);
        lastTime = Time.time;
        level++;
        attempt = 1;
        Dictionary<int, InformationSet> dict = new Dictionary<int, InformationSet>();
        dict.Add(attempt, new InformationSet());
        info.Add(level, dict);
    }

    public void addNewAttempt()
    {
        addTime(Time.time - lastTime);
        lastTime = Time.time;
        attempt++;
        info[level].Add(attempt, new InformationSet());
    }

    public void addDeathByEnemy(String enemy)
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.addDeathByEnemy(enemy);
    }

    public void addEnemiesAlerted(String enemy)
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.addEnemiesAlerted(enemy);
    }

    public void addAbilityUsage(String ability)
    {
        info[level][attempt].addAbilityUsage(ability);
    }

    public void addAbilityAttempt(String ability)
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.addAbilityAttempt(ability);
    }

    public void addItemsFound(String item)
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.addItemsFound(item);
    }

    public void addItemsUsed(String item)
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.addItemsUsed(item);
    }

    public void addItemsInteract(String item)
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.addItemsInteract(item);
    }

    public void addMovementTriggered(string mov)
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.addMovementTriggered(mov);
    }

    private void addTime(float t)
    {
        InformationSet temp;
        info[level].TryGetValue(attempt, out temp);
        temp.addTime(t);
    }
}