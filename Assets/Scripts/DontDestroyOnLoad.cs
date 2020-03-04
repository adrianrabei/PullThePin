using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
   public  bool wasPlayed;
    public  bool WasPlayed {
        get {return wasPlayed;}
        set {wasPlayed = value;}
    }
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
