using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject BombPrefab;
    public Transform BombSpawn;

    public Vector3 Pos;

    private Rigidbody rb;
    private Animator animator;

    //public float dx = 1;

    // 設定したフラグの名前
    private const string Idle = "Idle";
    private const string Run = "Run";
    
    GameController gameCon;

    //移動スピード
    public float speed = 8f;

    //ユニティちゃんの位置を入れる
    Vector3 playerPos;

    void Start() {
        rb = GetComponent<Rigidbody>();
        // 自分に設定されているAnimatorコンポーネントを習得する
        animator = GetComponent<Animator>();
        gameCon = GameObject.Find("GameController").GetComponent<GameController>();
        //ユニティちゃんの現在より少し前の位置を保存
        playerPos = transform.position;
    }

    void Update()
    {

        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space");
            Bomb();
        }
    }

    void Bomb()
    {
        //Pos.x = transform.position.x;
        //print("Pos.x:" + Pos.x);
        //Pos.z = transform.position.z;
        //print("Pos.z:" + Pos.z);
        //BombSpawn.position = Pos;
        //print("Pos:"+Pos);

        float x = transform.position.x;
        print("x:" + x);
        float y = transform.position.y;
        print("y:" + y);
        float z = transform.position.z;
        print("z:" + z);

        //Floorは切り捨て　戻り値がInt型
        float x2 = Mathf.RoundToInt(x);
        print("x2:" + x2);
        float z2 = Mathf.RoundToInt(z);
        print("z2:" + z2);

        Pos.x = x2;
        print("Pos.x:" + Pos.x);
        Pos.y = y + 0.5f;
        print("Pos.y:" + Pos.y);
        Pos.z = z2;
        print("Pos.z:" + Pos.z);
        BombSpawn.position = Pos;
        print("Pos:" + Pos);

        //Floorは切り捨て　戻り値がInt型
        float x3 = Mathf.Round(x2) % 2;
        print("x3:" + x3);
        float z3 = Mathf.Round(z2) % 2;
        print("z3:" + z3);

        if (x3 == 1)
        {
            //Vector3 Pos = transform.position;
            Pos.x += 1;
            BombSpawn.position = Pos;
        }

        if (z3 == 1)
        {
            //Vector3 Pos = transform.position;
            Pos.z += 1;
            BombSpawn.position = Pos;
        }

        if (gameCon.BombCount >= 1)
        {
            Instantiate(BombPrefab, BombSpawn.position, BombSpawn.rotation);
            print("BombSpawn:"+ BombSpawn.position);
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
            rb.isKinematic = true;
            print("PlayerController:gameover");
            Invoke("GameOver", 2f);
        }
    }

    //void Stop()
    //{
    //    rb.velocity = Vector3.zero;
    //    rb.angularVelocity = Vector3.zero;
    //}

    void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void Move()
    {
        //A・Dキー、←→キーで横移動
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        //W・Sキー、↑↓キーで前後移動
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //現在の位置＋入力した数値の場所に移動する
        rb.MovePosition(transform.position + new Vector3(x, 0, z));

        //ユニティちゃんの最新の位置から少し前の位置を引いて方向を割り出す
        Vector3 direction = transform.position - playerPos;

        //移動距離が少しでもあった場合に方向転換
        if (direction.magnitude > 0.01f)
        {
            //directionのX軸とZ軸の方向を向かせる
            transform.rotation = Quaternion.LookRotation(new Vector3
                (direction.x, 0, direction.z));
            //走るアニメーションを再生
            animator.SetBool("Running", true);
        }
        else
        {
            //ベクトルの長さがない＝移動していない時は走るアニメーションはオフ
            animator.SetBool("Running", false);
        }

        //ユニティちゃんの位置を更新する
        playerPos = transform.position;














        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    // WaitからWalk_Lに遷移する
        //    //Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, 0), 45 * Time.deltaTime);
        //    //transform.rotation = Quaternion.Euler(0, -90f, 0);
        //    animator.SetBool(Run, true);
        //    transform.Rotate(new Vector3(0, -90, 0));
        //    //transform.Translate(-1, 0, 0);
        //    //rb.velocity = new Vector3(-2, 0, 0);
        //}
        //else {
        //    // Walk_LからWaitに遷移する
        //    animator.SetBool(Run, false);
        //}

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    //transform.rotation = Quaternion.Euler(0, 90f, 0);
        //    animator.SetBool(Run, true);
        //    transform.Rotate(new Vector3(0, 90, 0));
        //    //transform.Translate(1, 0, 0);
        //    //rb.velocity = new Vector3(2, 0, 0);
        //}
        //else{
        //    animator.SetBool(Run, false);
        //}

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    //transform.position += transform.forward * 0.01f;
        //    animator.SetBool(Run, true);
        //    transform.Translate(0, 0, 1);
        //    //rb.velocity = new Vector3(0, 0, 2);
        //}
        //else{
        //    // RunからWaitに遷移する
        //    animator.SetBool(Run, false);
        //}

        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    //transform.rotation = Quaternion.Euler(0, 180f, 0);
        //    animator.SetBool(Run, true);
        //    transform.Translate(0, 0, -1);
        //    //rb.velocity = new Vector3(0, 0, -2);
        //}
        //else{
        //    // RunからWaitに遷移する
        //    animator.SetBool(Run, false);
        //}

    }

    }