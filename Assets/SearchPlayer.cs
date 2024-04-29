using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    private GameObject player;
    private float distance;
    [SerializeField]
    private float distanceLim = 3.5f;//食虫植物が開花するときのプレイヤーとの距離

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = (gameObject.transform.position - player.transform.position).magnitude;
        if (distance < distanceLim)
        {
            gameObject.GetComponentInParent<Flower>().Blooming();
        }
    }
}
