using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public AudioSource audioSource;
}

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    Sound[] sound;
    [SerializeField]
    public static SoundManager inst;

    // Start is called before the first frame update
    void Start()
    {
        if (inst == null)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(int idx) {
        sound[idx].audioSource.clip = sound[idx].clip;
        sound[idx].audioSource.Play();
    }
}
