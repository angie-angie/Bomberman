using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType2
{
    MOVE,
    REVERSE,
}

public class Enemy2Controller : MonoBehaviour
{
    EnemyController enemyController;

    GameObject Enemy2;
   
    public float speed = 0.03f;

    public float max2;

    public Vector3 Enemy2Pos;

    public float dis2_1;
    public float dis2_2;
    public float dis2_3;
    public float dis2_4;

    bool MaxOnce2 = false;

    public float dis2;

    public Ray ray1;
    public Ray ray2;
    public Ray ray3;
    public Ray ray4;

    public RaycastHit hit;

    public int distance;

    EnemyHit enemyHit;

    public MoveType2 moveType;

    void Start()
    {
        enemyHit = GameObject.Find("EnemyHit").GetComponent<EnemyHit>();
    }

    public void Update()
    {
        Enemy2Start();

        switch (moveType)
        {
            case MoveType2.MOVE:
                Enemy2Move();
                break;
            case MoveType2.REVERSE:
                WallHit2();
                break;
        }
    }

    public void Enemy2Start()
    {
        enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();
        Enemy2 = enemyController.Enemys[1];
        Enemy2.transform.rotation = Quaternion.Euler(-90, -270, 90);
        Enemy2Pos = Enemy2.transform.position;
        //Ray ray = new Ray(Enemy2Pos, transform.TransformDirection(Vector3.forward));
        //foreach (RaycastHit hit in Physics.RaycastAll(ray))
        //{
        //    //Debug.Log(hit.transform.name);
        //}

        //Rayの作成　　　 ↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray1 = new Ray(Enemy2Pos, new Vector3(Enemy2Pos.x, 0, 0));
        Ray ray2 = new Ray(Enemy2Pos, new Vector3(-Enemy2Pos.x, 0, 0));
        Ray ray3 = new Ray(Enemy2Pos, new Vector3(0, 0, Enemy2Pos.z));
        Ray ray4 = new Ray(Enemy2Pos, new Vector3(0, 0, -Enemy2Pos.z));


        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離
        int distance = 20;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　↓Rayの色
        Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.yellow);
        Debug.DrawRay(ray2.origin, ray2.direction * distance, Color.yellow);
        Debug.DrawRay(ray3.origin, ray3.direction * distance, Color.yellow);
        Debug.DrawRay(ray4.origin, ray4.direction * distance, Color.yellow);


        if (!MaxOnce2)
        {
            MaxOnce2 = true;
            //もしRayにオブジェクトが衝突したら
            //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
            if (Physics.Raycast(ray1, out hit, distance))
            {
                dis2_1 = hit.distance;
                print("dis2_1:" + dis2_1);
            }
            if (Physics.Raycast(ray2, out hit, distance))
            {
                dis2_2 = hit.distance;
                print("dis2_2:" + dis2_2);
            }
            if (Physics.Raycast(ray3, out hit, distance))
            {
                dis2_3 = hit.distance;
                print("dis2_3:" + dis2_3);
            }
            if (Physics.Raycast(ray4, out hit, distance))
            {
                dis2_4 = hit.distance;
                print("dis2_4:" + dis2_4);
            }
            max2 = Mathf.Max(dis2_1, dis2_2, dis2_3, dis2_4);
            print("max2:" + max2);
        }
    }

    public void Enemy2Move()
        {
        //    if (max2 <= 1.6)
        //{
        //    Enemy2.transform.position = new Vector3(Enemy2Pos.x, Enemy2Pos.y, Enemy2Pos.z);
        //}
        if (max2 == dis2_1)
        {
            Enemy2.transform.position = new Vector3(speed + Enemy2Pos.x, Enemy2Pos.y, Enemy2Pos.z);
        }
        else if (max2 == dis2_2)
        {
            Enemy2.transform.position = new Vector3(-speed + Enemy2Pos.x, Enemy2Pos.y, Enemy2Pos.z);
        }
        else if (max2 == dis2_3)
        {
            Enemy2.transform.position = new Vector3(Enemy2Pos.x, Enemy2Pos.y, speed + Enemy2Pos.z);
        }
        else
        {
            Enemy2.transform.position = new Vector3(Enemy2Pos.x, Enemy2Pos.y, -speed + Enemy2Pos.z);
        }
    }


    public void WallHit2()
    {
            if (max2 == dis2_1)
            {
                Enemy2.transform.position = new Vector3(-speed + Enemy2Pos.x, Enemy2Pos.y, Enemy2Pos.z);
            }
            else if (max2 == dis2_2)
            {
                Enemy2.transform.position = new Vector3(speed + Enemy2Pos.x, Enemy2Pos.y, Enemy2Pos.z);
            }
            else if (max2 == dis2_3)
            {
                Enemy2.transform.position = new Vector3(Enemy2Pos.x, Enemy2Pos.y, -speed + Enemy2Pos.z);
            }
            else
            {
                Enemy2.transform.position = new Vector3(Enemy2Pos.x, Enemy2Pos.y, speed + Enemy2Pos.z);
            }
        }
    }




