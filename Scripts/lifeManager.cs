using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lifeManager : MonoBehaviour
{
   
    
    public TextMeshProUGUI lifeUI;
    public int life;
    

    private void Update()
    {
        lifeUI.text = "×"+ life;
        //Debug.Log("¸ñ¼û: " + life);


        
    }


}
