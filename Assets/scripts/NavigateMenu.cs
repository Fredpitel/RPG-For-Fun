using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NavigateMenu : MonoBehaviour {

	public void navigate(String destination)
    {
        SceneManager.LoadScene(destination);
    }
}