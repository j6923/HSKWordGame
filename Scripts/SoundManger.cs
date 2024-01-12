using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManger : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 1);
            Load();
        }
        else
        {
            PlayerPrefs.SetInt("muted", 0);//이것 추가해줘야 함. 
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted; 
    }

    
    public void OnButtonPress()
    {
        if(muted == false)
        {
            if(muted == false)
            {
                muted = true;
                AudioListener.pause = true; 

            } 
            else
            {
                muted = false;
                AudioListener.pause = false;   // 소리 그림을 on이면 클릭하면 off 그림으로 아니면 그 반대로 바꿔줌 
            }
            Save();
            UpdateButtonIcon(); 
        }
        else  //버튼 바꿔주려면 이것 추가해야함 
        {
            if (muted == true)
            {
                muted = false;
                AudioListener.pause = false;

            }
            else
            {
                muted = true;
                AudioListener.pause = true;   // 소리 그림을 on이면 클릭하면 off 그림으로 아니면 그 반대로 바꿔줌 
            }
            Save();
            UpdateButtonIcon();
        }

    }

    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;   //muted이면 true 0이면 false 
        //muted = PlayerPrefs.GetInt("muted") == 0;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);  //muted 이면 1, fasle면 0저장 , 소리 정장 
    }
    
}
