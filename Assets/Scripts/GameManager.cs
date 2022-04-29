using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance => _instance;

    private void OnEnable()
    {
        if (_instance == null) _instance = this;
    }

    private void OnDisable()
    {
        if (_instance == this) _instance = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoadExit()
    {
        SceneManager.LoadScene(0);
    }
}
