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
    [SerializeField] private Vector3 targetPosition;
    private float moveDuration = 0.1f;
    void Start()
    {
        
    }

    public void Play()
    {
        game.SetActive(true);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        game.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Fail()
    {
        fail.SetActive(true);
        game.SetActive(false);
        main.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        win.SetActive(true);
        Time.timeScale = 0;
        Invoke("NextScene", 1);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
