using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageUIManager : MonoBehaviour
{
    // UI:持ってる花粉情報
    [SerializeField] GameObject[] pollenUIs;
    // UI:次の花粉を表示する
    [SerializeField] Image nextPollen;
    // UI:現在花粉をあげた花の数
    [SerializeField] Text pollinatedFlower;
    [SerializeField]
    private Text _countDownText = default;

    // Audio
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip countDownAudioClip;
    [SerializeField] AudioClip startAudioClip;

    private int _currentIndex = 0;

    private int stageNumLim = 0;

    private void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        UpdateScore(0);
        StartCoroutine(CountDown());
        stageNumLim = GameObject.Find(SceneManager.GetActiveScene().name).GetComponent<StageMovement>().FlowerCount;
        pollinatedFlower.text
            = "0 / " + " 目標数：" + GameManager.instance.stageGoalNumber.ToString();
    }

    /// <summary> 受粉した数/目標数を表示する </summary>
    public void UpdateScore(int pollinatedFlowerNumber)
    {
        pollinatedFlower.text
            = pollinatedFlowerNumber.ToString() + " / " + " 目標数：" + GameManager.instance.stageGoalNumber;

    }

    /// <summary> 次の花粉を表示する </summary>
    /*
    public void UpdateNextPollen(int nextPollenNumber)
    {
        nextPollen.sprite = pollenSprites[nextPollenNumber];
    }
    */
    public void UpdateCurrentPollen(int pollenNum)
    {
        pollenUIs[_currentIndex].transform.DOComplete();
        for (int i = 0; i < pollenUIs.Length; i++)
        {
            pollenUIs[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        pollenUIs[pollenNum].transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.5f);
        _currentIndex = pollenNum;
    }
    public void ResetPollenUIs()
    {
        for (int i = 0; i < pollenUIs.Length; i++)
        {
            pollenUIs[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(0.5f);
        _countDownText.text = "3";
        audioSource.PlayOneShot(countDownAudioClip);
        yield return new WaitForSeconds(1);
        _countDownText.text = "2";
        audioSource.PlayOneShot(countDownAudioClip);
        yield return new WaitForSeconds(1);
        _countDownText.text = "1";
        audioSource.PlayOneShot(countDownAudioClip);
        yield return new WaitForSeconds(1);
        _countDownText.text = "スタート!!";
        audioSource.PlayOneShot(startAudioClip);

        yield return new WaitForSeconds(1);
        _countDownText.text = "";
        _countDownText.gameObject.SetActive(false);
        GameManager.instance.PauseSwitch(false);
    }
}
