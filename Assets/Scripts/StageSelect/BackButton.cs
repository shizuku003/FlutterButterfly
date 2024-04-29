using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton: MonoBehaviour
{
    [Header("ƒ{ƒ^ƒ“‚ÌŒø‰Ê‰¹"), SerializeField]
    AudioClip m_ButtonSE;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager_SE soundManager_SE = SoundManager_SE.m_Instane;
            soundManager_SE.PlaySoundEfect(m_ButtonSE);
            SceneManager.LoadScene("TitleScene");
        }
    }

    public void OnClick()
    {
        SoundManager_SE soundManager_SE = SoundManager_SE.m_Instane;
        soundManager_SE.PlaySoundEfect(m_ButtonSE);
        SceneManager.LoadScene("TitleScene");
    }
}
