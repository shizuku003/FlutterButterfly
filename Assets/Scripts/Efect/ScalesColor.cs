using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalesColor : MonoBehaviour
{
    [Header("鱗粉の色"), SerializeField]
    List<Color> m_ScalesColor = new();
    [Header("鱗粉のエフェクト"), SerializeField]
    ParticleSystem m_Scales;

    public void ChangeScalesColor(int colorNum)
    {
        m_Scales.startColor = m_ScalesColor[colorNum];
    }
}
