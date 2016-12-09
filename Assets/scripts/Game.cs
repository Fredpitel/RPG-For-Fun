using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    private static Game mainGame;
    public static Game Instance
    {
        get
        {
            if(mainGame == null)
            {
                mainGame = new Game();
            }

            return mainGame;
        }
    }

    public Character mainChar = new Character();

	void Awake () {
		DontDestroyOnLoad(this);
	}
}
