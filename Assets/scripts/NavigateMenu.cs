using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NavigateMenu : MonoBehaviour {

	public void navigate(String destination)
    {
        if(destination == "Quit")
        {
            Application.Quit();
        }
        SceneManager.LoadScene(destination);
    }
}