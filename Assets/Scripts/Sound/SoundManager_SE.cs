using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_SE : MonoBehaviour
{
    public static SoundManager_SE m_Instane;

    private AudioSource m_AudioSourceSE;

    private void Awake()
    {
        //// �Q�[������N�����̓C���X�^���ɉ��������ĂȂ��̂ŉ���ł���悤�ɂ���
        //if (m_Instane != null)
        //{
        //    // ���Ƃ��Ɠ����Ă����C���X�^���X(DontDestroyOnLoad���ꂽ��O�̃I�u�W�F�N�g)���폜
        //    Destroy(m_Instane.gameObject);
        //}
        //// ���̃I�u�W�F�N�g���C���X�^���X�ɂԂ������
        //m_Instane = this;
        //// DontDestroyOnLoad���Ă�����B
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
