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
    private bool alreadyPlayed;
    [SerializeField] private ParticleSystem winEffects;
    protected override void Awake()
    {
        base.Awake();
       
    }
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        level.text = "Level " + (sceneIndex+1); 
        alreadyPlayed = false;
    }
    void Update() 
    {
       
    }

    public void Play()
    {

        game.SetActive(true);
        SoundControll.Instance.PlaySound("pop");
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
        yield return new WaitForSeconds(0.5f);
        fail.SetActive(true);
        game.SetActive(false);

        if(!alreadyPlayed)
        {
            SoundControll.Instance.PlaySound("fail");
            alreadyPlayed = true;
        }
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
        win.SetActive(true);
        game.SetActive(false);

        if(!alreadyPlayed)
        {
            SoundControll.Instance.PlaySound("win");
            winEffects.Play();
            alreadyPlayed = true;
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
