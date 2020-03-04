using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : UIManager
{
    public static bool wasPlayed = false;
    public static bool WasPlayed {
        get {return wasPlayed;}
        set {wasPlayed = value;}
    }
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
