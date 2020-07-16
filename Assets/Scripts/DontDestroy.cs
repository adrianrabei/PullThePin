using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
   public static bool wasPlayed;
    public bool WasPlayed {
        get {return wasPlayed;}
        set {wasPlayed = value;}
    }
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
