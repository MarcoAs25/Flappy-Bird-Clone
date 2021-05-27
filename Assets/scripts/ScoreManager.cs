using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int score,highScore;
    public static ScoreManager inst;
    public Text txtscore;
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
        score = 0;
    }
    
    public bool isNewScore()
    {
        if (PlayerPrefs.HasKey("HScore"))
        {
            if (PlayerPrefs.GetInt("HScore") < score)
            {
                PlayerPrefs.SetInt("HScore", score);
                highScore = score;
                return true;
            }
            else
            {

                highScore =  PlayerPrefs.GetInt("HScore");
                return false;
            }
            
        }
        else
        {
            highScore = score;
            PlayerPrefs.SetInt("HScore", highScore);
            
            return true;
        }
    }

    public int getScore()
    {
        return score;
    }
    public int getHighScore()
    {
        return highScore;
    }

    public void addScore() {
        score++;
        txtscore.text = getScore().ToString();
    }
}
