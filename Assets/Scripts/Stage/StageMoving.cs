using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMoving : MonoBehaviour
{
    [SerializeField] float stageSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - stageSpeed * Time.deltaTime, transform.position.y,0);
    }
}
