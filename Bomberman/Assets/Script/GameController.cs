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
    public float seconds1;

    public int BombCount;

    public float BurstTime;
    public float seconds2;
    public bool WideRange;

    GameObject[] enemyObjects;
    public int enemyNum;

    GameObject[] item_bombObjects;
    public int item_bombNum;

    GameObject[] bombObjects;
    public int bombNum;

    GameObject[] doorObjects;
    public int doorNum;

    ClearDoor ClearDoor;
    public bool clear = false;

    void Start () {
        Initialize();
    }
	
	public void Update () {
        totalTime -= Time.deltaTime;
        seconds1 = (int)totalTime;
        timerText.text = seconds1.ToString();
        //print("seconds1:"+ seconds1);

        if (seconds1 == 0)
        {
            seconds1 = 0;
            timerText.text = seconds1.ToString();
           
            if (!ClearDoor.clear)
            {
                print("GameController:gameOver1");
                GameOver();
            } else
            {
                SceneManager.LoadScene("ClearScene");
            }
        }

        if (WideRange)
        {
            BurstTime -= Time.deltaTime;
            seconds2 = (int)BurstTime;
            BurstT.text = seconds2.ToString();
        }
        if (BurstTime <= 0)
        {
            BurstTime = 0.0f;
            WideRange = false;
        }

        item_bombObjects = GameObject.FindGameObjectsWithTag("Item_bomb");
        item_bombNum = item_bombObjects.Length;
        print("item_bomb:" + item_bombNum);

        Enemyfind();
        print("enemyNum:" + enemyNum);

        bombObjects = GameObject.FindGameObjectsWithTag("Bomb");
        bombNum =bombObjects.Length;
        print("bombNum:" + bombNum);

        doorObjects = GameObject.FindGameObjectsWithTag("ClearDoor");
        doorNum = doorObjects.Length;

        if (BombCount == 0 && bombNum == 0 && item_bombNum == 0)
        {
            if (seconds1 > 0)
            {
                Invoke("Enemyfind", 3.0f);
                if (enemyNum >= 1 || doorNum == 0)
                {
                    print("GameController:gameOver2");
                    Invoke("GameOver", 5.0f);
                }
            }
        }
    }


    void Enemyfind()
    {
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemyNum = enemyObjects.Length;
    }

    void Initialize()
    {
        BombCt.text = BombCount.ToString();
        WideRange = false;
        ClearDoor = GameObject.Find("ClearDoor").GetComponent<ClearDoor>();
    }

    public void Bomb()
    {
        BombCount -= 1;
        BombCt.text = BombCount.ToString();       
    }

    public void GetItem_bomb()
    {
        BombCount += 1;
        BombCt.text = BombCount.ToString();
    }

    public void GetItem_burst()
    {
        WideRange = true;
        BurstTime = 15;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
