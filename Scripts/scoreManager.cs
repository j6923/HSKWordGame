using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    //public Text currentScoreUI;
    public TextMeshProUGUI currentScoreUI;
    public int currentScore;
    public int score = 0;

    private void Update()
    {
        currentScoreUI.text = "점수: " + currentScore;

    }
    
    /*
    private void OnCollisionEnter(Collision collision)
    {
        TextMeshProUGUI scoreObject = GetComponent<TextMeshProUGUI>();

        currentScore++;
        //currentScoreUI.text = "Á¡¼ö: " + currentScore;

    }
    */
}
