using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_SE : MonoBehaviour
{
    public static SoundManager_SE m_Instane;

    private AudioSource m_AudioSourceSE;

    private void Awake()
    {
        //// ゲーム初回起動時はインスタンに何も入ってないので回避できるようにする
        //if (m_Instane != null)
        //{
        //    // もともと入っていたインスタンス(DontDestroyOnLoadされた一つ前のオブジェクト)を削除
        //    Destroy(m_Instane.gameObject);
        //}
        //// 今のオブジェクトをインスタンスにぶち込んで
        //m_Instane = this;
        //// DontDestroyOnLoadしてあげる。
        //DontDestroyOnLoad(gameObject);
        //return;

        if (m_Instane == null)
        {
            m_Instane = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        m_AudioSourceSE = this.GetComponent<AudioSource>();
    }

    public void PlaySoundEfect(AudioClip audioClip_SE)
    {
        m_AudioSourceSE.PlayOneShot(audioClip_SE);
    }
}
