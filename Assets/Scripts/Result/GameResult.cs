using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    [Header("ステージ番号(0はチュートリアル)"), SerializeField]
    Text m_ThisText;

    bool m_Result;
    int m_BloomsNum = 20;
    int m_BloomLimit = 20;

    // Start is called before the first frame update
    void Start()
    {
        m_Result = GameManager.instance.isDead;
        m_BloomsNum = GameManager.instance.m_BloomNum;
        m_BloomLimit = GameManager.instance.stageGoalNumber;

        if (!m_Result && m_BloomsNum >= m_BloomLimit)
        {
            m_ThisText.text = "ゲームクリア！";
        }
        else if (m_Result || m_BloomsNum < m_BloomLimit)
        {
            m_ThisText.text = "ゲームオーバー…";
        }
    }
}
