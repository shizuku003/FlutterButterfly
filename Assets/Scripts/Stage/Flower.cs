using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flower : MonoBehaviour
{
    [SerializeField] int offset;
    [SerializeField] int direction;
    [SerializeField] int loopTimes = -1;
    [SerializeField] GameObject m_BloomEfect;
    float flowerEndPos;
    GameObject bud;
    GameObject flower;

    // Audio
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bloomAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        offset = Random.Range(1, 3);
        direction = Random.Range(0, 2);
        
        if(direction == 0)
        {
            flowerEndPos = transform.position.y + offset;
        }
        else
        {
            flowerEndPos = transform.position.y - offset;
        }
        this.transform.DOLocalMove(new Vector3(transform.position.x, flowerEndPos, 0), 2f).SetLoops(loopTimes, LoopType.Yoyo);
        bud = transform.Find("bud").gameObject;
        flower = transform.Find("flower").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -15)
        {
            Destroy(this.gameObject);
        }
    }

    public void Blooming()
    {
        bud.gameObject.SetActive(false);
        flower.gameObject.SetActive(true);
        m_BloomEfect.SetActive(true);
        audioSource.PlayOneShot(bloomAudioClip);
    }


}
