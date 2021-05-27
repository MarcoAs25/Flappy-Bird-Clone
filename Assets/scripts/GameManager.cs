using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    [SerializeField]
    public bool paused = false, isPlaying = false;
    [SerializeField]
    private GameObject MenuInt;
    [SerializeField]
    private GameObject MenuGame;
    [SerializeField]
    private GameObject GameOver;
    [SerializeField]
    private Text score, Hscore;
    [SerializeField]
    private Image imgnew;
    [SerializeField]
    private Sprite imgPaused,imgContinue;
    [SerializeField]
    private Button btnPause;
    // Start is called before the first frame update

    void Awake()
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

    void Start()
    {
        
        Time.timeScale = 0;
        isPlaying = false;
        MenuInt.SetActive(true);
    }

    public void play() {
        MenuGame.SetActive(true);
        MenuInt.SetActive(false);
        isPlaying = true;
        Time.timeScale = 1;
    }

    public void GameO()
    {
        isPlaying = false;
        if (ScoreManager.inst.isNewScore())
        {
            score.text = ScoreManager.inst.getScore().ToString();
            Hscore.text = ScoreManager.inst.getHighScore().ToString();
            GameOver.SetActive(true);
            imgnew.enabled = true;
            Time.timeScale = 0;
        }
        else
        {
            score.text = ScoreManager.inst.getScore().ToString();
            Hscore.text = ScoreManager.inst.getHighScore().ToString();
            GameOver.SetActive(true);
            imgnew.enabled = false;
            Time.timeScale = 0;
        }

    }

    public void pausePlay()
    {
        if (isPlaying)
        {
            SoundManager.inst.PlayAudio(4);
            if (paused)
            {
                Time.timeScale = 1;
                btnPause.image.sprite = imgPaused;
                paused = false;
            }
            else
            {
                Time.timeScale = 0;
                btnPause.image.sprite = imgContinue;
                paused = true;
            }
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
