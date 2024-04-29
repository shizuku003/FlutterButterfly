using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloomRate : MonoBehaviour
{
    [Header("ステージ番号(0はチュートリアル)"), SerializeField]
    Text m_BloomRateText;
    [Header("表示する花のプレファブ"), SerializeField]
    List<GameObject> m_Flowers = new();
    [Header("花を咲かせる親オブジェクト"), SerializeField]
    GameObject m_Grass;
    [Header("ゲーム結果表示"), SerializeField]
    GameObject m_GameResult;

    [Header("流すBGM"), SerializeField]
    AudioClip m_StageSelectBGM;

    int m_BloomRate;
    float m_Timer;

    int m_BloomsNum = 20;
    int m_BloomLimit = 20;

    private void Start()
    {
        // 後で別のスクリプトに写す　シゲタ
        SoundManager_BGM soundManager_BGM = SoundManager_BGM.m_Instane;
        soundManager_BGM.PlayBackGroundMusic(m_StageSelectBGM);

        m_BloomRate = 0;
        m_BloomsNum = GameManager.instance.m_BloomNum;
        m_BloomLimit = GameManager.instance.stageGoalNumber;
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;

        if (m_BloomRate < m_BloomsNum && m_Timer > 0.05f)
        {
            m_BloomRate++;
            m_Timer = 0;

            // 開花率が上昇中緑の円の中にランダムに花を咲かせる
            for (int i = 0; i < 4; i++)
            {
                Vector3 flowerPosition = new Vector3(Random.Range(500, -500), Random.Range(250, -250), 0);
                GameObject uiClone = Instantiate(m_Flowers[Random.Range(0, 3)], flowerPosition, Quaternion.identity);
                uiClone.transform.SetParent(m_Grass.transform, false);
            }
        }
        else if (m_BloomRate >= m_BloomsNum)
        {
            m_GameResult.SetActive(true);
        }

        m_BloomRateText.text = "開花率　" + m_BloomRate.ToString() + "/" + m_BloomLimit.ToString();
    }
}
