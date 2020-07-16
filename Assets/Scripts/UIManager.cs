using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform main, game, settings, sound, vibration, soundToggle, vibrationToggle;
    [SerializeField] private GameObject soundT, vibrationT;
    [SerializeField] private Sprite toggleOn, toggleOff;

    void Awake()
    {
        SoundToggle(soundT, PlayerPrefs.GetInt("music", 1));
        VibrationToggle(vibrationT, PlayerPrefs.GetInt("vibration", 1));
        
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

    public void SoundSettings()
    {
        if(PlayerPrefs.GetInt("music", 1) == 1)
        {
            PlayerPrefs.SetInt("music", 0);
            soundToggle.DOAnchorPos(new Vector2(-120, 0), 0.2f);
        }
        else 
        {
            PlayerPrefs.SetInt("music", 1);
            soundToggle.DOAnchorPos(new Vector2(-40, 0), 0.2f);
        }
        SoundToggle(soundT, PlayerPrefs.GetInt("music", 1));
    }

    public void SoundToggle(GameObject button, int state)
    {
        if(state == 0)
        {
            soundT.GetComponent<Image>().sprite = toggleOff;
            soundToggle.anchoredPosition = new Vector2(-120, 0);
        }
        else 
        {
            soundT.GetComponent<Image>().sprite = toggleOn;
            soundToggle.anchoredPosition = new Vector2(-40, 0);
        }
    }
    public void VibrationSettings()
    {
        if(PlayerPrefs.GetInt("vibration", 1) == 1)
        {
            PlayerPrefs.SetInt("vibration", 0);
            vibrationToggle.DOAnchorPos(new Vector2(-120, 0), 0.2f);
        }
        else 
        {
            PlayerPrefs.SetInt("vibration", 1);
            soundToggle.DOAnchorPos(new Vector2(-40, 0), 0.2f);
        }
        VibrationToggle(soundT, PlayerPrefs.GetInt("vibration", 1));
    }

    public void VibrationToggle(GameObject button, int state)
    {
        if(state == 0)
        {
            vibrationT.GetComponent<Image>().sprite = toggleOff;
            vibrationToggle.anchoredPosition = new Vector2(-120, 0);
        }
        else 
        {
            vibrationT.GetComponent<Image>().sprite = toggleOn;
            vibrationToggle.anchoredPosition = new Vector2(-40, 0);
        }
    }

}
