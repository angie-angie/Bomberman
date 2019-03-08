using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject BombPrefab;
    public Transform BombSpawn;
    public Vector3 Pos;

    private Rigidbody rb;
    //public AudioClip die;

    // Animator コンポーネント
    private Animator animator;

    //public float dx = 1;

    // 設定したフラグの名前
    private const string key_Walk_F = "isWalk_F";
    private const string key_Walk_B = "isWalk_B";
    private const string key_Walk_R = "isWalk_R";
    private const string key_Walk_L = "isWalk_L";
    private const string key_Die = "Die";

    GameController gameCon;

    void Start() {
        rb = GetComponent<Rigidbody>();
        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();
        gameCon = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {

        Move();

        if (Input.GetKeyDown("space"))
        {
            Bomb();
        }
    }

    void Bomb()
    {
        Pos.x = transform.position.x;
        Pos.z = transform.position.z;
        BombSpawn.position = Pos;

        float x = transform.position.x;
        float z = transform.position.z;

        //Floorは切り捨て　戻り値がInt型
        float x2 = Mathf.Round(x) % 2;
        float z2 = Mathf.Round(z) % 2;

        if (x2 == 1)
        {
            Vector3 Pos = transform.position;
            Pos.x += 1;
            BombSpawn.position = Pos;
        }

        if (z2 == 1)
        {
            Vector3 Pos = transform.position;
            Pos.z += 1;
            BombSpawn.position = Pos;
        }

        if (gameCon.BombCount >= 1)
        {
            GameObject clone = Instantiate(BombPrefab, BombSpawn.position, BombSpawn.rotation) as GameObject;
            gameCon.Bomb();
        }
    }

    
    void OnCollisionEnter(Collision col)
    {
        //Stop();

        if (col.gameObject.tag == "Break" || col.gameObject.tag == "Cube" || col.gameObject.tag == "DWall" || col.gameObject.tag == "Item_bomb" || col.gameObject.tag == "Item_burst")
        {
            //壁にぶつかった時、プレイヤーの位置の座標の小数点以下を切り捨て
            float x1 = transform.position.x;
            float z1 = transform.position.z;

            //Floorは切り捨て　戻り値がInt型
            float x3 = Mathf.RoundToInt(x1);
            float z3 = Mathf.RoundToInt(z1);

            transform.position = new Vector3(x3, -0.5f, z3);

            //// transformを取得
            //Transform myTransform = this.transform;

            //// 座標を取得
            //Vector3 Pos = myTransform.position;
            //// Floorは小数点以下切り捨て　戻り値がInt型
            //Mathf.RoundToInt(Pos.x);
            //Mathf.RoundToInt(Pos.y);
            //Mathf.RoundToInt(Pos.z);
            //print(Pos);
            //// 座標を設定
            //myTransform.position = Pos;

            //　物理演算の影響を受けない
            //rb.isKinematic = true;
        }
        else if (col.gameObject.tag == "Enemy")
        {
            //AudioSource.PlayClipAtPoint(die, transform.position);
            
            rb.isKinematic = true;
            Invoke("GameOver", 3f);
        }
        //} else if(col.gameObject.tag == "Item_bomb")
        //{
        //    GameObject GameCon = GameObject.Find("GameController");
        //    GameCon.GetComponent<GameController>().GetItem_bomb();
        //}
        //else if (col.gameObject.tag == "Item_burst")
        //{
        //    GameObject GameCon = GameObject.Find("GameController");
        //    GameCon.GetComponent<GameController>().GetItem_burst();
        //}
    }

    void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // WaitからWalk_Lに遷移する
            //Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, 0), 45 * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(0, -90f, 0);
            this.animator.SetBool(key_Walk_F, true);
            transform.Translate(-1, 0, 0);
            //rb.velocity = new Vector3(-2, 0, 0);
        }
        else {
            // Walk_LからWaitに遷移する
            this.animator.SetBool(key_Walk_F, false);
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.rotation = Quaternion.Euler(0, 90f, 0);
            this.animator.SetBool(key_Walk_F, true);
            transform.Translate(1, 0, 0);
            //rb.velocity = new Vector3(2, 0, 0);
        }
        else
        {
            this.animator.SetBool(key_Walk_F, false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.animator.SetBool(key_Walk_F, true);
            transform.Translate(0, 0, 1);
            //rb.velocity = new Vector3(0, 0, 2);
        }
        else
        {
            // RunからWaitに遷移する
            this.animator.SetBool(key_Walk_F, false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.rotation = Quaternion.Euler(0, 180f, 0);
            this.animator.SetBool(key_Walk_F, true);
            transform.Translate(0, 0, -1);
            //rb.velocity = new Vector3(0, 0, -2);
        }
        else
        {
            // RunからWaitに遷移する
            this.animator.SetBool(key_Walk_F, false);
        }

    }

    }