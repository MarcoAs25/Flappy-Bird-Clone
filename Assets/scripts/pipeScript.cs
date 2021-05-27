using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScript : MonoBehaviour
{
    [SerializeField]
    private float speed, maxValueOf;
    [SerializeField]
    private int direction;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * direction * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x < maxValueOf)
        {
            Destroy(this.gameObject);
        }

    }
}
