using System.Collections;
using UnityEngine;


public class bird : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float impulse,maxAngle, minAngle;
    private float angleBird;
    [SerializeField]
    private bool isdeath = false;
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        animator.SetInteger("color", Random.Range(0, 3));
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !isdeath && !GameManager.inst.paused)
        {
            if (!GameManager.inst.isPlaying)
            {
                GameManager.inst.play();
                rb2d.velocity = Vector3.up * impulse;
                SoundManager.inst.PlayAudio(1);
            }
            else
            {
                rb2d.velocity = Vector3.up * impulse;
                SoundManager.inst.PlayAudio(1);
            }
            
        }

        if (rb2d.velocity.y < 0)
        {
            angleBird = Mathf.LerpAngle(0, minAngle, -rb2d.velocity.y / 8);
            transform.rotation = Quaternion.Euler(0, 0, angleBird);

        }
        else if (rb2d.velocity.y > 0)
        {
            angleBird = Mathf.LerpAngle(0, maxAngle, rb2d.velocity.y / 8);
            transform.rotation = Quaternion.Euler(0, 0, angleBird);
        }
        else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
    }

    private void FixedUpdate()
    {
        if(transform.position.y >= 2.0f && !isdeath)
        {
            SoundManager.inst.PlayAudio(2);
            isdeath = true;
            StartCoroutine("waitoPlayAudio");
        }
    }

    IEnumerator waitoPlayAudio()
    {
        yield return new WaitForSeconds(0.2f);
        SoundManager.inst.PlayAudio(3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isdeath)
        {
            if (collision.collider.CompareTag("pipe"))
            {
                SoundManager.inst.PlayAudio(2);
                rb2d.constraints = RigidbodyConstraints2D.None;
                rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                isdeath = true;
                StartCoroutine("waitoPlayAudio");
            }
            else if (collision.collider.CompareTag("gnd"))
            {
                SoundManager.inst.PlayAudio(2);
                rb2d.constraints = RigidbodyConstraints2D.None;
                rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                isdeath = true;
                GameManager.inst.GameO();
            }

        }
        else if (collision.collider.CompareTag("gnd"))
        {
            GameManager.inst.GameO();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("score") && !isdeath)
        {
            ScoreManager.inst.addScore();
            SoundManager.inst.PlayAudio(0);
        }
    }
}
