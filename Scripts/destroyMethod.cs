using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LanguageData;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.HID;


public class destroyMethod : MonoBehaviour
{

    public string chineseCube;
    public wordCreator wordcreator;
    public lifeManager lifeScore;
    playerManager player;
    scoreManager scoremanager;
    XRController leftController;
    XRController rightController;

    
    private float leftCollisionTime;
    private float rightCollisionTime;

    //private List<GameObject> destroyedCubes = new List<GameObject>();

    private void OnDestroy()
    {
        OnCubeDestroyed();
       

    }

   

   


    public void OnCubeDestroyed()
    {
        TextMeshPro cubeText = GetComponentInChildren<TextMeshPro>();
        TextMeshPro cubeTextChild = GetComponent<TextMeshPro>();

        if ((cubeText != null || cubeTextChild != null))
        {
            string chineseCube = cubeText.text;

            scoremanager = FindObjectOfType<scoreManager>();

            // null 체크 추가
            TMP_Text wordAnswerText = GameObject.Find("wordAnswer")?.GetComponent<TMP_Text>();




            if (wordAnswerText != null)
            {
                string KoreanText = wordAnswerText.text;
                Debug.Log("wordAnswerText: " + KoreanText);

                GameObject smObject = GameObject.Find("ScoreManager");
                scoreManager sm = smObject.GetComponent<scoreManager>();

                GameObject lifeObj = GameObject.Find("playerManager");
                lifeScore = lifeObj.GetComponent<lifeManager>();
                

                for (int i = 0; i < WordPair.wordPairs.Count; i++)
                {
                    string chineseIndex1 = WordPair.wordPairs[i].ChineseWord;
                    string KoreanIndex = WordPair.wordPairs[i].KoreanWord;

                    int chineseInt = -1;
                    int koreanInt = -1;
                    if (chineseIndex1 == chineseCube)
                    {
                        // Debug.Log("중국어 인덱스: " + i);
                        chineseInt = i;
                    }

                    if (KoreanIndex == KoreanText)
                    {
                        koreanInt = i;
                        // Debug.Log("한국어 인덱스: " + i);
                    }

                    if (koreanInt != -1 && chineseInt != -1 && koreanInt == chineseInt)
                    {
                        //if()
                        sm.currentScore += 1;





                    }
                    if (koreanInt != -1  && chineseInt != -1 && koreanInt != chineseInt )
                    {
                        //Debug.Log("인덱스 다르다");
                       lifeScore.life -= 1;  //여기서 목숨 깎임 
                                              // Debug.Log("life: " + lifeScore.life);
                                              //wordcreator.DisableOtherCubesCollider();



                    }

                }
            }

            else
            {
                Debug.LogWarning("wordAnswer GameObject을 찾지 못했습니다.");
            }

            

        }

        else
        {
            Debug.LogWarning("TextMeshPro 컴포넌트를 찾지 못했습니다.");
        }

        
        

    }
    

   

}






