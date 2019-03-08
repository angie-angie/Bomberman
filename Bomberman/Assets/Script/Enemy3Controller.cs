using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType3
{
    MOVE,
    REVERSE,
}

public class Enemy3Controller : MonoBehaviour
{
    EnemyController enemyController;

    GameObject Enemy3;
    
    public float speed = 0.03f;

    public float max3;

    public Vector3 Enemy3Pos;

    public float dis3_1;
    public float dis3_2;
    public float dis3_3;
    public float dis3_4;

    bool MaxOnce3 = false;

    public float dis3;

    public Ray ray1;
    public Ray ray2;
    public Ray ray3;
    public Ray ray4;

    public RaycastHit hit;

    public int distance;

    EnemyHit enemyHit;

    public MoveType3 moveType;

    void Start()
    {
        enemyHit = GameObject.Find("EnemyHit").GetComponent<EnemyHit>();
    }

    public void Update()
    {
        Enemy3Start();

        switch (moveType)
        {
            case MoveType3.MOVE:
                Enemy3Move();
                break;
            case MoveType3.REVERSE:
                WallHit3();
                break;
        }
    }

    public void Enemy3Start()
    {
        enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();
        Enemy3 = enemyController.Enemys[2];
        Enemy3.transform.rotation = Quaternion.Euler(-90, -270, 90);
        Enemy3Pos = Enemy3.transform.position;
        //print(Enemy3Pos);

        //Ray ray = new Ray(Enemy3Pos, transform.TransformDirection(Vector3.forward));
        //foreach (RaycastHit hit in Physics.RaycastAll(ray))
        //{
        //    Debug.Log(hit.transform.name);
        //}

        //Rayの作成　　　 ↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        ray1 = new Ray(Enemy3Pos, new Vector3(Enemy3Pos.x, 0, 0));
        ray2 = new Ray(Enemy3Pos, new Vector3(-Enemy3Pos.x, 0, 0));
        ray3 = new Ray(Enemy3Pos, new Vector3(0, 0, Enemy3Pos.z));
        ray4 = new Ray(Enemy3Pos, new Vector3(0, 0, -Enemy3Pos.z));

        //Rayが当たったオブジェクトの情報を入れる箱
        //RaycastHit hit;

        //Rayの飛ばせる距離
        distance = 20;
        //print(ray1.direction);

        //DrawLineはdirectionの座標の数値にdistanceを掛けている
        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　↓Rayの色
        Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.red);
        Debug.DrawRay(ray2.origin, ray2.direction * distance, Color.red);
        Debug.DrawRay(ray3.origin, ray3.direction * distance, Color.red);
        Debug.DrawRay(ray4.origin, ray4.direction * distance, Color.red);

        if (!MaxOnce3)
        {
            MaxOnce3 = true;

            //もしRayにオブジェクトが衝突したら
            //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
            if (Physics.Raycast(ray1, out hit, distance))
            {
                dis3_1 = hit.distance;
                print("dis3_1:" + dis3_1);
                //Rayが当たったオブジェクトのtagがPlayerだったら
                //if (hit.collider.tag == "DWall")
                //    Debug.Log("RayがDWallに当たった");
            }
            if (Physics.Raycast(ray2, out hit, distance))
            {
                dis3_2 = hit.distance;
                print("dis3_2:" + dis3_2);
            }
            if (Physics.Raycast(ray3, out hit, distance))
            {
                dis3_3 = hit.distance;
                print("dis3_3:" + dis3_3);
            }
            if (Physics.Raycast(ray4, out hit, distance))
            {
                dis3_4 = hit.distance;
                print("dis3_4:" + dis3_4);
            }
            //else if (dis3_1 != 0 && dis3_2 != 0 && dis3_3 != 0 && dis3_4 != 0)
            //{
            //    break;
            //}


            //var list1 = new List<float> { dis1, dis2, dis3, dis4 };
            //var max = list1.Max();

            max3 = Mathf.Max(dis3_1, dis3_2, dis3_3, dis3_4);
            print("max3:" + max3);
        }
    }

    public void Enemy3Move()
    {
        //    if (max3 <= 1.6)
        //{
        //    Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
        //}
        if (max3 == dis3_1)
        {
            Enemy3.transform.position = new Vector3(speed + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
        }
        else if (max3 == dis3_2)
        {
            Enemy3.transform.position = new Vector3(-speed + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
        }
        else if (max3 == dis3_3)
        {
            Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, speed + Enemy3Pos.z);
        }
        else
        {
            Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, -speed + Enemy3Pos.z);
        }
    }

    public void WallHit3()
    {
            if (max3 == dis3_1)
            {
                Enemy3.transform.position = new Vector3(-speed + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
            }
            else if (max3 == dis3_2)
            {
                Enemy3.transform.position = new Vector3(speed + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
            }
            else if (max3 == dis3_3)
            {
                Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, -speed + Enemy3Pos.z);
            }
            else
            {
                Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, speed + Enemy3Pos.z);
            }
        }

    }



