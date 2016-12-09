using UnityEngine.UI;
using UnityEngine;
using System;

public class Stats : MonoBehaviour {
    private Character main;

    void Start()
    {
        main = GameObject.FindObjectOfType<Game>().mainChar;
    }

    void Update()
    {
        GetComponent<Text>().text = main.stats[tag].ToString();
    }
}
