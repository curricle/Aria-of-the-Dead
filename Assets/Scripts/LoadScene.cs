using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public String levelToLoad;

    public void LoadSelectedScene(string levelToLoad) {
       SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single); 
    }
}
