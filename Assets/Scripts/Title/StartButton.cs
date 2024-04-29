using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [Header("ボタンの効果音"), SerializeField]
    AudioClip m_ButtonSE;
    //[Header("オーディオソース"), SerializeField]
    //AudioSource m_AudioSource_SE;

    public void OnClick()
    {
        SoundManager_SE soundManager_SE = SoundManager_SE.m_Instane;
        soundManager_SE.PlaySoundEfect(m_ButtonSE);
        //m_AudioSource_SE.PlayOneShot(m_ButtonSE);
        SceneManager.LoadScene("StageSelectScene");
    }
}
