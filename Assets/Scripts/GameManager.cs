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

    private int sceneIndex;
    private bool alreadyPlayed;
    [SerializeField] private ParticleSystem winEffects;
    public bool canFail;
    protected override void Awake()
    {
        base.Awake();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(PlayerPrefs.GetInt("level", 0) == sceneIndex)
        {
            
        }
        else SceneManager.LoadScene(PlayerPrefs.GetInt("level", 0));       
    }
    void Start()
    {
        alreadyPlayed = false;
        canFail = true;
        if(DontDestroy.wasPlayed)
        {
            Play();
        }
        
    }
    void Update() 
    {
       Debug.Log(DontDestroy.wasPlayed);
    }

    public void Play()
    {
        main.SetActive(false);
        game.SetActive(true);
        SoundControll.Instance.PlaySound("pop");
        DontDestroy.wasPlayed = true;
        
    }

    public void Pause()
    {
        game.SetActive(false);
        main.SetActive(true);
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
        canFail = false;

        if(!alreadyPlayed)
        {
            SoundControll.Instance.PlaySound("win");
            winEffects.Play();
            alreadyPlayed = true;
        }
        PlayerPrefs.SetInt("level", sceneIndex + 1);
    }

    public void NextScene()
    {
       
        if(PlayerPrefs.GetInt("level", 1) <= 49)
        {
            SceneManager.LoadScene(sceneIndex + 1);
        }
        else
        {
            int nextLevel = Random.Range(0, 49);
            SceneManager.LoadScene(nextLevel);
        }

       
    }

    public void VibrationController()
    {
        if(PlayerPrefs.GetInt("vibration", 1) == 0)
        {
            return;
        }
        Handheld.Vibrate();
    }

    
}
