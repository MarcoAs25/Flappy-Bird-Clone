using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPipes : MonoBehaviour
{
    [SerializeField]
    private float mintime, maxTime, minHeight, maxHeight;
    [SerializeField]
    private float time, timeEl;
    [SerializeField]
    private GameObject[] pipes;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeEl = timeEl + Time.deltaTime;
        if(timeEl >= time)
        {
            time = Random.Range(mintime, maxTime);
            timeEl = 0f;
            Instantiate(pipes[Random.Range(0,pipes.Length)], new Vector3(transform.position.x, transform.position.y + Random.Range(minHeight, maxHeight), transform.position.z), Quaternion.identity);
        }


    }
}
