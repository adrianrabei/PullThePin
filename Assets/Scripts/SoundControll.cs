using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControll : Singleton<SoundControll>
{
    public AudioClip pop;
    public AudioClip swoosh;
    public AudioClip win;
    public AudioClip fail;
    public AudioClip explosion;
    private AudioSource aSource;
    private bool canPlaySound;
    protected override void Awake()
    {
        base.Awake();
       
    }
    void Start()
    {
        aSource = GetComponent<AudioSource>();

        if(PlayerPrefs.GetInt("music", 1) == 1)
        {
            canPlaySound = true;
        }
    }

   
    
    public void PlaySound(string name)
    {
        if(canPlaySound)
        {
            if(name == "pop")
            {
                aSource.PlayOneShot(pop);
            }
            if(name == "swoosh")
            {
                aSource.PlayOneShot(swoosh);
            }
            if(name == "win")
            {
                aSource.PlayOneShot(win);
            }
            if(name == "fail")
            {
                aSource.PlayOneShot(fail);
            }
            if(name == "explosion")
            {
                aSource.PlayOneShot(explosion);
            }
        }
    }
}
