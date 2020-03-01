using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject main;
    [SerializeField] protected GameObject game;
    [SerializeField] protected GameObject win;
    [SerializeField] protected GameObject fail;
    [SerializeField] private Text level;
    private int sceneIndex;
    protected override void Awake()
    {
        base.Awake();
       
    }
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
        level.text = "Level " + (sceneIndex+1); 
    }
    void Update() 
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
        SceneManager.LoadScene(sceneIndex);
    }

    public IEnumerator Fail()
    {
        yield return new WaitForSeconds(1f);
        fail.SetActive(true);
        game.SetActive(false); 
        print("Boom blea");
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
        win.SetActive(true);
        game.SetActive(false);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
