using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    [Header("ボタンの効果音"), SerializeField]
    AudioClip m_ButtonSE;

    public void OnClick()
    {
        //m_AudioSource_SE.PlayOneShot(m_ButtonSE);
        SoundManager_SE soundManager_SE = SoundManager_SE.m_Instane;
        soundManager_SE.PlaySoundEfect(m_ButtonSE);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
            Application.Quit();//ゲームプレイ終了
        #endif
    }
}
