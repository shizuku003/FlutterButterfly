using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditButton : MonoBehaviour
{
    [Header("ステージ番号(0はチュートリアル)"), SerializeField]
    GameObject m_Credit;
    [Header("SEオーディオソース"), SerializeField]
    AudioSource m_AudioSource_SE;
    [Header("ボタンの効果音"), SerializeField]
    AudioClip m_ButtonSE;

    public void OnClick()
    {
        m_Credit.SetActive(true);
        m_AudioSource_SE.PlayOneShot(m_ButtonSE);
    }
}
