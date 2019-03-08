using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType1
{
    MOVE,
    REVERSE,
}

public class Enemy1Controller : MonoBehaviour
{
    EnemyController enemyController;

    GameObject Enemy1;

    public float speed = 0.03f;

    public float max1;

    public Vector3 Enemy1Pos;

    public float dis1_1;
    public float dis1_2;
    public float dis1_3;
    public float dis1_4;

    public float[] dis1_ = new float[4];

    bool MaxOnce1 = false;
    
    public float dis1;
    
    public Ray ray1;
    public Ray ray2;
    public Ray ray3;
    public Ray ray4;

    public RaycastHit hit;

    public int distance;

    EnemyHit enemyHit;

    public MoveType1 moveType;

    void Start()
    {
        enemyHit = GameObject.Find("EnemyHit").GetComponent<EnemyHit>();
    }

    public void Update()
    {
        Enemy1Start();

        switch (moveType)
        {
            case MoveType1.MOVE:
                Enemy1Move();
                break;
            case MoveType1.REVERSE:
                WallHit1();
                break;
        }
    }

    public void Enemy1Start()
    {
        enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();
        Enemy1 = enemyController.Enemys[0];
        Enemy1.transform.rotation = Quaternion.Euler(-90, -270, 90);
        Enemy1Pos = Enemy1.transform.position;
        
        //Rayの作成　　　 ↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray1 = new Ray(Enemy1Pos, new Vector3(Enemy1Pos.x, 0, 0));
        Ray ray2 = new Ray(Enemy1Pos, new Vector3(-Enemy1Pos.x, 0, 0));
        Ray ray3 = new Ray(Enemy1Pos, new Vector3(0, 0, Enemy1Pos.z));
        Ray ray4 = new Ray(Enemy1Pos, new Vector3(0, 0, -Enemy1Pos.z));

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離
        int distance = 20;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　↓Rayの色
        Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.blue);
        Debug.DrawRay(ray2.origin, ray2.direction * distance, Color.blue);
        Debug.DrawRay(ray3.origin, ray3.direction * distance, Color.blue);
        Debug.DrawRay(ray4.origin, ray4.direction * distance, Color.blue);

        if (!MaxOnce1)
        {
            MaxOnce1 = true;
            //もしRayにオブジェクトが衝突したら
            //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
            if (Physics.Raycast(ray1, out hit, distance))
            {
                dis1_1 = hit.distance;
                print("dis1_1:" + dis1_1);
                //Rayが当たったオブジェクトのtagがPlayerだったら
                //if (hit.collider.tag == "DWall")
                //Debug.Log("RayがDWallに当たった");
            }
            if (Physics.Raycast(ray2, out hit, distance))
            {
                dis1_2 = hit.distance;
                print("dis1_2:" + dis1_2);
            }
            if (Physics.Raycast(ray3, out hit, distance))
            {
                dis1_3 = hit.distance;
                print("dis1_3:" + dis1_3);
            }
            if (Physics.Raycast(ray4, out hit, distance))
            {
                dis1_4 = hit.distance;
                print("dis1_4:" + dis1_4);
            }
            max1 = Mathf.Max(dis1_1, dis1_2, dis1_3, dis1_4);
            print("max1:" + max1);
        }
    }

    public void Enemy1Move()
    {
        //if (max1 <= 1.6)
        //{
        //    Enemy1.transform.position = new Vector3(Enemy1Pos.x, Enemy1Pos.y, Enemy1Pos.z);
        //}
        if (max1 == dis1_1)
        {
            Enemy1.transform.position = new Vector3(speed + Enemy1Pos.x, Enemy1Pos.y, Enemy1Pos.z);
        }
        else if (max1 == dis1_2)
        {
            Enemy1.transform.position = new Vector3(-speed + Enemy1Pos.x, Enemy1Pos.y, Enemy1Pos.z);
        }
        else if (max1 == dis1_3)
        {
            Enemy1.transform.position = new Vector3(Enemy1Pos.x, Enemy1Pos.y, speed + Enemy1Pos.z);
        }
        else
        {
            Enemy1.transform.position = new Vector3(Enemy1Pos.x, Enemy1Pos.y, -speed + Enemy1Pos.z);
        }
    }


    public void WallHit1()
    {
        print("wallhit");
            if (max1 == dis1_1)
        {
            print("wallhitdis1_1");
            Enemy1.transform.position = new Vector3(-speed + Enemy1Pos.x, Enemy1Pos.y, Enemy1Pos.z);
            }
            else if (max1 == dis1_2)
        {
            print("wallhitdis1_2");
            Enemy1.transform.position = new Vector3(speed + Enemy1Pos.x, Enemy1Pos.y, Enemy1Pos.z);
            }
            else if (max1 == dis1_3)
        {
            print("wallhitdis1_3");
            Enemy1.transform.position = new Vector3(Enemy1Pos.x, Enemy1Pos.y, -speed + Enemy1Pos.z);
            }
            else
        {
            print("wallhitelse");
            Enemy1.transform.position = new Vector3(Enemy1Pos.x, Enemy1Pos.y, speed + Enemy1Pos.z);
            }
        }
    }




