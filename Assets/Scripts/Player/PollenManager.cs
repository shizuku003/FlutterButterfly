using UnityEngine;

public class PollenManager : MonoBehaviour
{
    private int[] pollens = new int[2];//??????????
    private int pkind = 3;//??????????????
    private string[] flowerTags = { "FlowerRed", "FlowerWhite", "FlowerYellow", "CarnivorousPlants" };//???????????????^?O
    private string pollenTag;//???????????????????????????^?O???i?[
    public int bloomNum = 0;
    [SerializeField]
    private StageUIManager stageUIManager;
    [SerializeField]
    ScalesColor m_ScalesColor;

    private int _currentPollen = 0;

    // Audio
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip pollenChangeAudioClip;
    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        _currentPollen = Random.Range(0, pkind);
        stageUIManager.UpdateCurrentPollen(_currentPollen);

        //for (int i = 0; i < pollens.Length; i++)
        //{
        //    pollens[i] = Random.Range(0, pkind);//???????????????????????????????????i?[
        //}
        FlowerTagSetting();
        //stageUIManager.UpdateNextPollen(pollens[1]);
        m_ScalesColor.ChangeScalesColor(_currentPollen);
    }

    private void Update()
    {
            if (Input.GetKeyDown("a") || Input.GetKeyDown("j"))
            {
                _currentPollen = 0;
                m_ScalesColor.ChangeScalesColor(_currentPollen);
                stageUIManager.UpdateCurrentPollen(_currentPollen);
                audioSource.PlayOneShot(pollenChangeAudioClip);

            }
            else if (Input.GetKeyDown("s") || Input.GetKeyDown("k"))
            {
                _currentPollen = 1;
                m_ScalesColor.ChangeScalesColor(_currentPollen);
                audioSource.PlayOneShot(pollenChangeAudioClip);
                stageUIManager.UpdateCurrentPollen(_currentPollen);
            }
            else if (Input.GetKeyDown("d") || Input.GetKeyDown("l"))
            {
                _currentPollen = 2;
                m_ScalesColor.ChangeScalesColor(_currentPollen);
                audioSource.PlayOneShot(pollenChangeAudioClip);
                stageUIManager.UpdateCurrentPollen(_currentPollen);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FlowerTagSetting();

        if (collision.gameObject.tag == pollenTag)//???G?????I?u?W?F?N?g???^?O????????????????????????????
        {
            Debug.Log("????");//?e?X?g?p
            //pollens[0] = pollens[1];
            //pollens[1] = Random.Range(0, pkind);//0????2??????????????

            //_currentPollen = Random.Range(0, pkind);

            bloomNum++;
            stageUIManager.UpdateScore(bloomNum);
            //stageUIManager.UpdateNextPollen(pollens[1]);
            //stageUIManager.UpdateNextPollen(_currentPollen);
            collision.gameObject.GetComponent<Flower>().Blooming();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (collision.gameObject.tag == flowerTags[3])
        {
            Debug.Log("carnivorous plants");//?e?X?g?p
            this.gameObject.GetComponent<PlayerController>().FallPlayer();
            GameManager.instance.isDead = true;
        }
        else
        {
            Debug.Log("??????");//?e?X?g?p
        }
    }

    private void FlowerTagSetting()
    {
        pollenTag = _currentPollen switch
        {
            0 => flowerTags[0],
            1 => flowerTags[1],
            2 => flowerTags[2],
        };
    }
}
