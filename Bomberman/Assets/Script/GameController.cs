using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text BombCt;
    public Text BurstT;
    public Text timerText;

    public float totalTime;
    int seconds1;

    public int BombCount;

    void Start () {
        Initialize();
    }
	
	void Update () {
        totalTime -= Time.deltaTime;
        seconds1 = (int)totalTime;
        timerText.text = seconds1.ToString();
        //if(seconds == 0)
        //{
        //    SceneManager.LoadScene("GameOverScene");
        //}
    }

    void Initialize()
    {
        BombCt.text = BombCount.ToString();
    }

    public void Bomb()
    {
        BombCount -= 1;
        BombCt.text = BombCount.ToString();
        if (BombCount == 0)
           {
               BombCount = 0;
           }
    }

    public void GetItem_bomb()
    {
        BombCount += 1;
        BombCt.text = BombCount.ToString();
    }
}
