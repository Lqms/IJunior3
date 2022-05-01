using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    private void OnEnable()
    {
        if (Instance == null) 
            Instance = this;
    }

    private void OnDisable()
    {
        if (Instance == this) 
            Instance = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
