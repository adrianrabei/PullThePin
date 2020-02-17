using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] protected GameObject game;
    [SerializeField] protected GameObject win;
    [SerializeField] protected GameObject fail;

    
    void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        main.SetActive(false);
        game.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Fail()
    {
        fail.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        win.SetActive(true);
        Time.timeScale = 0;
    }
}
