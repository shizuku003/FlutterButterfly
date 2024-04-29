using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    [Header("ƒ{ƒ^ƒ“‚ÌŒø‰Ê‰¹"), SerializeField]
    AudioClip m_ButtonSE;
    [Header("—¬‚·BGM"), SerializeField]
    AudioClip m_StageSelectBGM;

    public void OnClick()
    {
        SoundManager_SE soundManager_SE = SoundManager_SE.m_Instane;
        soundManager_SE.PlaySoundEfect(m_ButtonSE);

        SoundManager_BGM soundManager_BGM = SoundManager_BGM.m_Instane;
        soundManager_BGM.PlayBackGroundMusic(m_StageSelectBGM);

        SceneManager.LoadScene("StageSelectScene");
    }
}
