using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    [Header("�X�e�[�W�ԍ�(0�̓`���[�g���A��)"), SerializeField]
    GameObject m_Credit;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            m_Credit.SetActive(false);
        }
    }
}
