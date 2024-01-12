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
            PlayerPrefs.SetInt("muted", 0);//�̰� �߰������ ��. 
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
                AudioListener.pause = false;   // �Ҹ� �׸��� on�̸� Ŭ���ϸ� off �׸����� �ƴϸ� �� �ݴ�� �ٲ��� 
            }
            Save();
            UpdateButtonIcon(); 
        }
        else  //��ư �ٲ��ַ��� �̰� �߰��ؾ��� 
        {
            if (muted == true)
            {
                muted = false;
                AudioListener.pause = false;

            }
            else
            {
                muted = true;
                AudioListener.pause = true;   // �Ҹ� �׸��� on�̸� Ŭ���ϸ� off �׸����� �ƴϸ� �� �ݴ�� �ٲ��� 
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
        muted = PlayerPrefs.GetInt("muted") == 1;   //muted�̸� true 0�̸� false 
        //muted = PlayerPrefs.GetInt("muted") == 0;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);  //muted �̸� 1, fasle�� 0���� , �Ҹ� ���� 
    }
    
}
