using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InformationSet
{

    private Dictionary<String, int> deathByEnemy;
    private Dictionary<String, int> enemiesAlerted;                //MISSING
    private Dictionary<String, int> usageByAbility;
    private Dictionary<String, int> abilityAttempt;
    private Dictionary<String, int> itemsFound;
    private Dictionary<String, int> itemsUsed;
    private Dictionary<String, int> itemsInteract;      //MISSING
    private float time;
    private Dictionary<String, int> movementTriggered;

    public InformationSet()
    {
        deathByEnemy = new Dictionary<String, int>();
        enemiesAlerted = new Dictionary<String, int>();
        usageByAbility = new Dictionary<String, int>();
        abilityAttempt = new Dictionary<String, int>();
        itemsFound = new Dictionary<String, int>();
        itemsUsed = new Dictionary<String, int>();
        itemsInteract = new Dictionary<String, int>();
        movementTriggered = new Dictionary<String, int>();
    }

    public void addDeathByEnemy(String enemy)
    {
        if (!deathByEnemy.ContainsKey(enemy))
            deathByEnemy.Add(enemy, 1);
        else
            deathByEnemy[enemy]++;
    }

    public void getEnemies()
    {
        foreach (String e in enemiesAlerted.Keys)
        {
            Debug.Log("ALERT " + e + " " + enemiesAlerted[e]);
        }

        foreach (String e in deathByEnemy.Keys)
        {
            Debug.Log("ATTACK " + e + " " + deathByEnemy[e]);
        }
    }

    public void getSkills()
    {
        foreach (String e in usageByAbility.Keys)
        {
            Debug.Log("SkILL " + e + " " + usageByAbility[e]);
        }

        foreach (String e in abilityAttempt.Keys)
        {
            Debug.Log("TRIED " + e + " " + abilityAttempt[e]);
        }
    }

    public void getTime()
    {
        Debug.Log("TIME " + time);
    }

    public void getItems()
    {
        foreach (String e in itemsFound.Keys)
        {
            Debug.Log("FOUND " + e + " " + itemsFound[e]);
        }

        foreach (String e in itemsUsed.Keys)
        {
            Debug.Log("USED " + e + " " + itemsUsed[e]);
        }

        foreach (String e in itemsInteract.Keys)
        {
            Debug.Log("INTERACT " + e + " " + itemsInteract[e]);
        }
    }

    public void getMovement()
    {
        foreach (String e in movementTriggered.Keys)
        {
            Debug.Log("MOVE " + e + " " + movementTriggered[e]);
        }
    }

    public void addEnemiesAlerted(String enemy)
    {
        if (!enemiesAlerted.ContainsKey(enemy))
            enemiesAlerted.Add(enemy, 1);
        else
            enemiesAlerted[enemy]++;
    }

    public void addAbilityUsage(String ability)
    {
        if (!usageByAbility.ContainsKey(ability))
            usageByAbility.Add(ability, 1);
        else
            usageByAbility[ability]++;
    }

    public void addAbilityAttempt(String ability)
    {
        if (!abilityAttempt.ContainsKey(ability))
            abilityAttempt.Add(ability, 1);
        else
            abilityAttempt[ability]++;
    }

    public void addItemsFound(String item)
    {
        if (!itemsFound.ContainsKey(item))
            itemsFound.Add(item, 1);
        else
            itemsFound[item]++;
    }

    public void addItemsUsed(String item)
    {
        if (!itemsUsed.ContainsKey(item))
            itemsUsed.Add(item, 1);
        else
            itemsUsed[item]++;
    }

    public void addItemsInteract(String item)
    {
        if (!itemsInteract.ContainsKey(item))
            itemsInteract.Add(item, 1);
        else
            itemsInteract[item]++;
    }

    public void addMovementTriggered(string mov)
    {
        if (!movementTriggered.ContainsKey(mov))
            movementTriggered.Add(mov, 1);
        else
            movementTriggered[mov]++;
    }

    public void addTime(float t)
    {
        time = t;
    }


    public void getLogEnemies(StreamWriter logFile)
    {
        logFile.WriteLine("ALERTED:");
        foreach (String e in enemiesAlerted.Keys)
        {
            logFile.WriteLine(e + " " + enemiesAlerted[e]);
        }

        logFile.WriteLine("\r\nATTACKED:");
        foreach (String e in deathByEnemy.Keys)
        {
            logFile.WriteLine(e + " " + deathByEnemy[e]);
        }
    }

    public void getLogSkills(StreamWriter logFile)
    {
        logFile.WriteLine("SKILLS USED:");
        foreach (String e in usageByAbility.Keys)
        {
            logFile.WriteLine(e + " " + usageByAbility[e]);
        }

        logFile.WriteLine("\r\nSKILLS TRIED:");
        foreach (String e in abilityAttempt.Keys)
        {
            logFile.WriteLine(e + " " + abilityAttempt[e]);
        }
    }

    public void getLogItems(StreamWriter logFile)
    {
        logFile.WriteLine("ITEMS FOUND:");
        foreach (String e in itemsFound.Keys)
        {
            logFile.WriteLine(e + " " + itemsFound[e]);
        }

        logFile.WriteLine("\r\nITEMS USED:");
        foreach (String e in itemsUsed.Keys)
        {
            logFile.WriteLine(e + " " + itemsUsed[e]);
        }

        logFile.WriteLine("\r\nITEMS INTERACTED:");
        foreach (String e in itemsInteract.Keys)
        {
            logFile.WriteLine(e + " " + itemsInteract[e]);
        }
    }

    public void getLogMovement(StreamWriter logFile)
    {
        foreach (String e in movementTriggered.Keys)
        {
            logFile.WriteLine(e + " " + movementTriggered[e]);
        }
    }

    public void getLogTime(StreamWriter logFile)
    {
        logFile.WriteLine(time);
    }
}
