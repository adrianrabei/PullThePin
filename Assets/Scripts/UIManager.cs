using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform main, game, settings, sound, vibration, soundToggle, vibrationToggle;
    [SerializeField] private GameObject soundT, vibrationT;
    private bool isOn;
    [SerializeField] private Sprite toggleOn, toggleOff;

    void Awake()
    {
        /*if(PlayerPrefs.GetInt("wasPlayed",0)==1)
        {
            PlayerPrefs.SetInt("wasPlayed",0);
            PlayButton();

        }*/
        
        isOn = true;
    }

    public void PlayButton()
    {
        GameManager.Instance.Play();
        main.DOAnchorPos(new Vector2(800, 0), 0.35f);
    
    }

    public void PauseButton()
    {
        main.DOAnchorPos(new Vector2(0, 0), 0.35f);
        GameManager.Instance.Pause();
    }

    public void RestartButton()
    {
        //PlayerPrefs.SetInt("wasPlayed", 1);
        GameManager.Instance.Restart();
    }

    public void GoToSettings()
    {
        main.DOAnchorPos(new Vector2(-800, 0), 0.35f);
        settings.DOAnchorPos(new Vector2(0, 0), 0.35f);
        sound.DOAnchorPos(new Vector2(4, 400), 0.5f).SetEase(Ease.InOutBounce);
        vibration.DOAnchorPos(new Vector2(4, 164), 0.6f).SetEase(Ease.InOutBounce);
    }

    public void BackToMain()
    {
        main.DOAnchorPos(new Vector2(0, 0), 0.35f);
        settings.DOAnchorPos(new Vector2(800, 0), 0.35f);
        sound.DOAnchorPos(new Vector2(800, 400), 0.45f);
        vibration.DOAnchorPos(new Vector2(800, 164), 0.65f);
    }

    public void NextLevel()
    {
        GameManager.Instance.NextScene();
    }

    public void SoundToggle()
    {
        if(isOn)
        {
            soundToggle.DOAnchorPos(new Vector2(-120, 0), 0.2f);
            soundT.GetComponent<Image>().sprite = toggleOff;
            isOn = !isOn;
        }
        else 
        {
            soundToggle.DOAnchorPos(new Vector2(-40, 0), 0.2f);
            soundT.GetComponent<Image>().sprite = toggleOn;
            isOn = !isOn;
        }
    }

     public void VibrationToggle()
    {   
        if(isOn)
        {
            vibrationToggle.DOAnchorPos(new Vector2(-120, 0), 0.2f);
            vibrationT.GetComponent<Image>().sprite = toggleOff;
            isOn = !isOn;
        }
        else 
        {
            vibrationToggle.DOAnchorPos(new Vector2(-40, 0), 0.2f);
            vibrationT.GetComponent<Image>().sprite = toggleOn;
            isOn = !isOn;
        }
    }
}
