using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform main, game;
    [SerializeField] private GameManager manager;
    public static bool wasPlayed = false;
    void Awake()
    {
        if(wasPlayed)
        {
            RestartButton();
        }
    }

    public void PlayButton()
    {
        manager.Play();
        main.DOAnchorPos(new Vector2(800, 0), 0.35f);
        wasPlayed = true;
    }

    public void PauseButton()
    {
        main.DOAnchorPos(new Vector2(0, 0), 0.35f);
    }

    public void RestartButton()
    {
        manager.Play();
        main.DOAnchorPos(new Vector2(800, 0), 0);
        wasPlayed = true;
    }
}
