using UnityEngine;
using System.IO;
using System;
using SimpleJSON;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour {
    const int MAX = 18;
    const int MIN = 3;

    private Character main;
    private SpriteRenderer sr;
    private Sprite[][] spriteColl = new Sprite[2][];
    private Sprite[] spritesMale;
    private Sprite[] spritesFemale;
    private String jsonString;
    JSONNode json;

    void Start()
    {
        main = GameObject.FindObjectOfType<Game>().mainChar;
        sr = GetComponent<SpriteRenderer>();
        spritesMale = Resources.LoadAll<Sprite>("CharacterCreation/Male");
        spritesFemale = Resources.LoadAll<Sprite>("CharacterCreation/Female");

        spriteColl[0] = spritesMale;
        spriteColl[1] = spritesFemale;

        jsonString = File.ReadAllText(Application.dataPath + "/Resources/CharacterCreation/startingStats.json");
        json = JSON.Parse(jsonString);
        resetStats(0);
    }

    public void changeSex(int sexIndex)
    {
        sr.sprite = spriteColl[sexIndex][main.classIndex];
        main.sexIndex = sexIndex;
    }

    public void changeClass(int classIndex)
    {
        sr.sprite = spriteColl[main.sexIndex][classIndex];
        main.classIndex = classIndex;
        resetStats(classIndex);
    }

    void resetStats(int classIndex)
    {
        JSONArray classStats = json["startingStats"][classIndex]["stats"].AsArray;

        foreach(JSONNode stat in classStats)
        {
            Text statLabel = GameObject.Find("Text - StatsValue - " + stat["stat"]).GetComponent<Text>();
            statLabel.text = stat["value"];
        }

        GameObject.Find("Text - Points Left Value").GetComponent<Text>().text = json["startingPoints"];
    }

    public void updateName(String charName)
    {
        main.charName = charName;
    }

    public void incStat(String stat)
    {
        int val = main.stats[stat];
        if (val < MAX && main.spendablePoints > 0)
        {
            main.stats[stat]++;
            main.spendablePoints--;
        }
    }

    public void decStat(String stat)
    {
        int val = main.stats[stat];
        if (val > MIN)
        {
            main.stats[stat]--;
            main.spendablePoints++;
        }
    }

    public void createChar()
    {
        if (main.charName == "")
        {
            InputField charNameInput = GameObject.Find("Input - CharName").GetComponent<InputField>();
            charNameInput.Select();
        } else {

        }
    }
}