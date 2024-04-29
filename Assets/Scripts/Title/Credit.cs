using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    [Header("ステージ番号(0はチュートリアル)"), SerializeField]
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
