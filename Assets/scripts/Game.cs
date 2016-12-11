using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    private static Game mainGame;
    public static Game Instance { get { return mainGame; } }
    public Character mainChar;

	void Awake () {
        if (mainGame != null && mainGame != this)
        {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this);
            mainGame = this;
            mainChar = GetComponent<Character>();
        }
    }
}
