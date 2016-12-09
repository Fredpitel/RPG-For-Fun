using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{ 
    public String charName = "";
    public int classIndex = 0;
    public int sexIndex = 0;
    public Dictionary<String, int> stats = new Dictionary<String, int>()
    {
        { "STR", 13 },
        { "DEX", 10 },
        { "CON", 12 },
        { "INT", 7 },
        { "WIS", 9 },
        { "CHA", 9 }
    };
    public int spendablePoints = 10;

    public String getSex()
    {
        return (this.sexIndex == 0) ? "Male" : "Female";
    }

    void Update()
    {
        GetComponent<Text>().text = spendablePoints.ToString();
    }
}