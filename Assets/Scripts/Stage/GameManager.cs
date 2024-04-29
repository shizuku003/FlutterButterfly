using Constants;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // ステージのプレイ時間
    public float playTimer;
    // ステージの目標数
    public int stageGoalNumber = 10;
    public bool isDead = false;
    public int m_BloomNum;

    private PollenManager pollenManager;

    private bool _isTutorial = false;
    public bool IsTutorial { get => _isTutorial; private set => _isTutorial = value; }
    public bool IsPause { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playTimer = 57;
        IsPause = true;
        pollenManager = FindObjectOfType<PollenManager>();
        if (SceneManager.GetActiveScene().name == Consts.Scenes[SceneNames.Tutorial]) { _isTutorial = true; }


        if (SceneManager.GetActiveScene().name == Consts.Scenes[SceneNames.Tutorial]) {
            stageGoalNumber = 5;
        }else if(SceneManager.GetActiveScene().name == Consts.Scenes[SceneNames.Stage1])
        {
            stageGoalNumber = 10;
            Debug.Log("ステージの数を変更");
        }else if(SceneManager.GetActiveScene().name == Consts.Scenes[SceneNames.Stage2])
        {
            stageGoalNumber = 20;
        }
        else if (SceneManager.GetActiveScene().name == Consts.Scenes[SceneNames.Stage3])
        {
            stageGoalNumber = 30;
        }
    }

    void Update()
    {
        if (IsPause || _isTutorial) { return; }

        playTimer -= Time.deltaTime;

        m_BloomNum = pollenManager.bloomNum;

        if (playTimer < 0)
        {
            if (!isDead && m_BloomNum >= stageGoalNumber)
            {
                Fade.Instance.RegisterFadeOutEvent(
                    new Action[] { () => SceneLoader.LoadToScene(SceneNames.GameClear) });
                Fade.Instance.StartFadeOut();
            }
            else if (isDead || m_BloomNum < stageGoalNumber)
            {
                Fade.Instance.RegisterFadeOutEvent(
                    new Action[] { () => SceneLoader.LoadToScene(SceneNames.GameOver) });
                Fade.Instance.StartFadeOut();
            }
        }

    }

    public void PauseSwitch(bool flag)
    {
        IsPause = flag;
    }
}
