using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private static menuMusic music;



    void Awake()
    {
        if (music == null)
        {
            music = this;
            DontDestroyOnLoad(music);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
