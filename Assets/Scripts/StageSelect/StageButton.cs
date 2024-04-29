using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    [Header("移動するシーン名"), SerializeField]
    string m_StageName;
    [Header("ボタンの効果音"), SerializeField]
    AudioClip m_ButtonSE;

    public void OnClick()
    {
        SoundManager_SE soundManager_SE = SoundManager_SE.m_Instane;
        soundManager_SE.PlaySoundEfect(m_ButtonSE);

        SoundManager_BGM soundManager_BGM = SoundManager_BGM.m_Instane;
        soundManager_BGM.StopBackGroundMusic();

        SceneManager.LoadScene(m_StageName);
    }
}
