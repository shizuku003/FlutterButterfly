using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalesColor : MonoBehaviour
{
    [Header("�ؕ��̐F"), SerializeField]
    List<Color> m_ScalesColor = new();
    [Header("�ؕ��̃G�t�F�N�g"), SerializeField]
    ParticleSystem m_Scales;

    public void ChangeScalesColor(int colorNum)
    {
        m_Scales.startColor = m_ScalesColor[colorNum];
    }
}
