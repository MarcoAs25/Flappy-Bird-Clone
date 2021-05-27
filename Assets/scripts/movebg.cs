using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebg : MonoBehaviour
{
    [SerializeField]
    private float speed, maxValueOf;
    [SerializeField]
    private int direction;
    [SerializeField]
    private Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + speed * direction * Time.fixedDeltaTime, transform.position.y, transform.position.z);
        if (transform.position.x <= maxValueOf)
        {
            transform.position = startpos;
        }
    }
        
}
