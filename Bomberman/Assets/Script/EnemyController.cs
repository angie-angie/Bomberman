using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject[] Enemys = new GameObject[3];

    public float speed = 0.05f;

    public float max1;
    public float max2;
    public float max3;

    public Vector3 Enemy1Pos;
    public Vector3 Enemy2Pos;
    public Vector3 Enemy3Pos;

    public float dis1_1;
    public float dis1_2;
    public float dis1_3;
    public float dis1_4;

    public float dis2_1;
    public float dis2_2;
    public float dis2_3;
    public float dis2_4;

    public float dis3_1;
    public float dis3_2;
    public float dis3_3;
    public float dis3_4;

    bool MaxOnce1 = false;
    bool MaxOnce2 = false;
    bool MaxOnce3 = false;

    public float dis1;
    public float dis2;
    public float dis3;

    public Ray ray1;
    public Ray ray2;
    public Ray ray3;
    public Ray ray4;

    public RaycastHit hit;

    public int distance;

    Enemy1Controller enemy1Controller;
    Enemy2Controller enemy2Controller;
    Enemy3Controller enemy3Controller;


    void Start()
    {
        //Enemy1 = Enemys[0];
        //Enemy2 = Enemys[1];
        //Enemy3 = Enemys[2];

        enemy1Controller = GameObject.Find("Enemy1Controller").GetComponent<Enemy1Controller>();
        //enemy1Controller.Enemy1Move();

        enemy2Controller = GameObject.Find("Enemy2Controller").GetComponent<Enemy2Controller>();
        //enemy2Controller.Enemy2Move();

        enemy3Controller = GameObject.Find("Enemy3Controller").GetComponent<Enemy3Controller>();
        //enemy3Controller.Enemy3Move();
    }

    void Update()
    {
        //Enemy1Start();
        //Enemy1Move();

        //Enemy2Start();
        //Enemy2Move();

        //Enemy3Start();
        //Enemy3Move();

    }

    //void Enemy1Start()
    //{
    //    Enemy1.transform.rotation = Quaternion.Euler(-90, -270, 90);
    //    Enemy1Pos = Enemy1.transform.position;
    //    //print(Enemy1Pos);

    //    //// Rayが衝突した全てのコライダーの情報を得る。＊順序は保証されない
    //    //// RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);

    //    //Ray ray = new Ray(Enemy1Pos, transform.TransformDirection(Vector3.forward));

    //    ////RaycastHit hit;
    //    ////ヒットしたすべてのオブジェクト情報を取得

    //    //foreach (RaycastHit hit in Physics.RaycastAll(ray))
    //    //{
    //    //    //ヒットしたオブジェクトの名前
    //    //    //Debug.Log(hit.transform.name);

    //    //    //transform.Translate(this.speed, 0, 0);
    //    //    //this.speed *= 0.1f;
    //    //}

    //    //Rayの作成　　　 ↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
    //    Ray ray1 = new Ray(Enemy1Pos, new Vector3(Enemy1Pos.x, 0, 0));
    //    Ray ray2 = new Ray(Enemy1Pos, new Vector3(-Enemy1Pos.x, 0, 0));
    //    Ray ray3 = new Ray(Enemy1Pos, new Vector3(0, 0, Enemy1Pos.z));
    //    Ray ray4 = new Ray(Enemy1Pos, new Vector3(0, 0, -Enemy1Pos.z));


    //    //Rayが当たったオブジェクトの情報を入れる箱
    //    RaycastHit hit;

    //    //Rayの飛ばせる距離
    //    int distance = 20;

    //    //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　↓Rayの色
    //    Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.blue);
    //    Debug.DrawRay(ray2.origin, ray2.direction * distance, Color.blue);
    //    Debug.DrawRay(ray3.origin, ray3.direction * distance, Color.blue);
    //    Debug.DrawRay(ray4.origin, ray4.direction * distance, Color.blue);

    //    if (!MaxOnce1)
    //    {
    //        MaxOnce1 = true;
    //        //もしRayにオブジェクトが衝突したら
    //        //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
    //        if (Physics.Raycast(ray1, out hit, distance))
    //        {
    //            dis1_1 = hit.distance;
    //            print("dis1_1:" + dis1_1);
    //            //Rayが当たったオブジェクトのtagがPlayerだったら
    //            //if (hit.collider.tag == "DWall")
    //            //    Debug.Log("RayがDWallに当たった");
    //        }
    //        if (Physics.Raycast(ray2, out hit, distance))
    //        {
    //            dis1_2 = hit.distance;
    //            print("dis1_2:" + dis1_2);
    //        }
    //        if (Physics.Raycast(ray3, out hit, distance))
    //        {
    //            dis1_3 = hit.distance;
    //            print("dis1_3:" + dis1_3);
    //        }
    //        if (Physics.Raycast(ray4, out hit, distance))
    //        {
    //            dis1_4 = hit.distance;
    //            print("dis1_4:" + dis1_4);
    //        }
    //        max1 = Mathf.Max(dis1_1, dis1_2, dis1_3, dis1_4);
    //        print("max1:" + max1);
    //        dis1 = max1 - (max1 - 1);
    //    }
    //}

    //void Enemy1Move()
    //{
    //    if (max1 == dis1_1)
    //    {
    //        Enemy1.transform.position = new Vector3(speed + Enemy1Pos.x, Enemy1Pos.y, Enemy1Pos.z);
    //    }
    //    else if (max1 == dis1_2)
    //    {
    //        Enemy1.transform.position = new Vector3(-speed + Enemy1Pos.x, Enemy1Pos.y, Enemy1Pos.z);
    //    }
    //    else if (max1 == dis1_3)
    //    {
    //        Enemy1.transform.position = new Vector3(Enemy1Pos.x, Enemy1Pos.y, speed + Enemy1Pos.z);
    //    }
    //    else
    //    {
    //        Enemy1.transform.position = new Vector3(Enemy1Pos.x, Enemy1Pos.y, -speed + Enemy1Pos.z);
    //    }
    //}

    //void Enemy2Start()
    //{
    //    Enemy2.transform.rotation = Quaternion.Euler(-90, -270, 90);
    //    Enemy2Pos = Enemy2.transform.position;
    //    //Ray ray = new Ray(Enemy2Pos, transform.TransformDirection(Vector3.forward));
    //    //foreach (RaycastHit hit in Physics.RaycastAll(ray))
    //    //{
    //    //    //Debug.Log(hit.transform.name);
    //    //}

    //    //Rayの作成　　　 ↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
    //    Ray ray1 = new Ray(Enemy2Pos, new Vector3(Enemy2Pos.x, 0, 0));
    //    Ray ray2 = new Ray(Enemy2Pos, new Vector3(-Enemy2Pos.x, 0, 0));
    //    Ray ray3 = new Ray(Enemy2Pos, new Vector3(0, 0, Enemy2Pos.z));
    //    Ray ray4 = new Ray(Enemy2Pos, new Vector3(0, 0, -Enemy2Pos.z));


    //    //Rayが当たったオブジェクトの情報を入れる箱
    //    RaycastHit hit;

    //    //Rayの飛ばせる距離
    //    int distance = 20;

    //    //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　↓Rayの色
    //    Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.yellow);
    //    Debug.DrawRay(ray2.origin, ray2.direction * distance, Color.yellow);
    //    Debug.DrawRay(ray3.origin, ray3.direction * distance, Color.yellow);
    //    Debug.DrawRay(ray4.origin, ray4.direction * distance, Color.yellow);


    //    if (!MaxOnce2)
    //    {
    //        MaxOnce2 = true;
    //        //もしRayにオブジェクトが衝突したら
    //        //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
    //        if (Physics.Raycast(ray1, out hit, distance))
    //        {
    //            dis2_1 = hit.distance;
    //            print("dis2_1:" + dis2_1);
    //        }
    //        if (Physics.Raycast(ray2, out hit, distance))
    //        {
    //            dis2_2 = hit.distance;
    //            print("dis2_2:" + dis2_2);
    //        }
    //        if (Physics.Raycast(ray3, out hit, distance))
    //        {
    //            dis3_3 = hit.distance;
    //            print("dis2_3:" + dis2_3);
    //        }
    //        if (Physics.Raycast(ray4, out hit, distance))
    //        {
    //            dis2_4 = hit.distance;
    //            print("dis2_4:" + dis2_4);
    //        }
    //        max2 = Mathf.Max(dis2_1, dis2_2, dis2_3, dis2_4);
    //        print("max2:" + max2);
    //        dis2 = max2 - (max2 - 1);
    //    }
    //}

    //void Enemy2Move()
    //{
    //    if (max2 == dis2_1)
    //    {
    //        Enemy2.transform.position = new Vector3(speed + Enemy2Pos.x, Enemy2Pos.y, Enemy2Pos.z);
    //    }
    //    else if (max2 == dis2_2)
    //    {
    //        Enemy2.transform.position = new Vector3(-speed + Enemy2Pos.x, Enemy2Pos.y, Enemy2Pos.z);
    //    }
    //    else if (max2 == dis2_3)
    //    {
    //        Enemy2.transform.position = new Vector3(Enemy2Pos.x, Enemy2Pos.y, speed + Enemy2Pos.z);
    //    }
    //    else
    //    {
    //        Enemy2.transform.position = new Vector3(Enemy2Pos.x, Enemy2Pos.y, -speed + Enemy2Pos.z);
    //    }
    //}

    //void Enemy3Start()
    //{
    //    Enemy3.transform.rotation = Quaternion.Euler(-90, -270, 90);
    //    Enemy3Pos = Enemy3.transform.position;
    //    //print(Enemy3Pos);

    //    //Ray ray = new Ray(Enemy3Pos, transform.TransformDirection(Vector3.forward));
    //    //foreach (RaycastHit hit in Physics.RaycastAll(ray))
    //    //{
    //    //    Debug.Log(hit.transform.name);
    //    //}

    //    //Rayの作成　　　 ↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
    //    ray1 = new Ray(Enemy3Pos, new Vector3(Enemy3Pos.x, 0, 0));
    //    ray2 = new Ray(Enemy3Pos, new Vector3(-Enemy3Pos.x, 0, 0));
    //    ray3 = new Ray(Enemy3Pos, new Vector3(0, 0, Enemy3Pos.z));
    //    ray4 = new Ray(Enemy3Pos, new Vector3(0, 0, -Enemy3Pos.z));



    //    //Rayが当たったオブジェクトの情報を入れる箱
    //    //RaycastHit hit;

    //    //Rayの飛ばせる距離
    //    distance = 20;
    //    print(ray1.direction);

    //    //DrawLineはdirectionの座標の数値にdistanceを掛けている
    //    //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　↓Rayの色
    //    Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.red);
    //    Debug.DrawRay(ray2.origin, ray2.direction * distance, Color.red);
    //    Debug.DrawRay(ray3.origin, ray3.direction * distance, Color.red);
    //    Debug.DrawRay(ray4.origin, ray4.direction * distance, Color.red);

    //    if (!MaxOnce3)
    //    {
    //        MaxOnce3 = true;

    //        //もしRayにオブジェクトが衝突したら
    //        //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
    //        if (Physics.Raycast(ray1, out hit, distance))
    //        {
    //            dis3_1 = hit.distance;
    //            print("dis3_1:" + dis3_1);
    //            //Rayが当たったオブジェクトのtagがPlayerだったら
    //            //if (hit.collider.tag == "DWall")
    //            //    Debug.Log("RayがDWallに当たった");
    //        }
    //        if (Physics.Raycast(ray2, out hit, distance))
    //        {
    //            dis3_2 = hit.distance;
    //            print("dis3_2:" + dis3_2);
    //        }
    //        if (Physics.Raycast(ray3, out hit, distance))
    //        {
    //            dis3_3 = hit.distance;
    //            print("dis3_3:" + dis3_3);
    //        }
    //        if (Physics.Raycast(ray4, out hit, distance))
    //        {
    //            dis3_4 = hit.distance;
    //            print("dis3_4:" + dis3_4);
    //        }
    //        //else if (dis3_1 != 0 && dis3_2 != 0 && dis3_3 != 0 && dis3_4 != 0)
    //        //{
    //        //    break;
    //        //}


    //        //var list1 = new List<float> { dis1, dis2, dis3, dis4 };
    //        //var max = list1.Max();

    //        max3 = Mathf.Max(dis3_1, dis3_2, dis3_3, dis3_4);
    //        print("max3:" + max3);
    //        dis3 = max3 - (max3 - 1);
    //    }
    //}



    //void Enemy3Move()
    //{
    //    if (max3 == dis3_1)
    //    {
    //        Enemy3.transform.position = new Vector3(speed + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
    //        //if (Enemy3Pos.x <= Enemy3Pos.x + )
    //        //{
    //            Enemy3.transform.position = new Vector3(-speed + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
    //        //}
    //            //Enemy3.transform.position = new Vector3(Mathf.PingPong(Time.time, 0.1f) + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
    //            //Enemy3.transform.Translate(this.speed, 0, 0);
    //            //this.speed *= 0.1f;
    //        }
    //        else if (max3 == dis3_2)
    //        {
    //            Enemy3.transform.position = new Vector3(-speed + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
    //            if (Physics.Raycast(ray1, out hit, distance))
    //            {
    //                if (hit.distance <= dis3) 
    //                Enemy3.transform.position = new Vector3(speed + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
                    
    //                //Enemy3.transform.position = new Vector3(Mathf.Sin(Time.time) * -0.1f + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
    //                //Enemy3.transform.position = new Vector3(Mathf.PingPong(Time.time, -0.1f) + Enemy3Pos.x, Enemy3Pos.y, Enemy3Pos.z);
    //            }
    //            else if (max3 == dis3_3)
    //            {
    //                Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, speed + Enemy3Pos.z);
    //                if (Physics.Raycast(ray1, out hit, distance))
    //                {                      
    //                    if (hit.distance <= dis3)
    //                    Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, -speed + Enemy3Pos.z);
                        
    //                    //Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, Mathf.Sin(Time.time) * 0.1f + Enemy3Pos.z);
    //                    //Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, Mathf.PingPong(Time.time, 0.1f) + Enemy3Pos.z);
    //                }
    //                else
    //                {
    //                    Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, -speed + Enemy3Pos.z);
    //                    if (Physics.Raycast(ray1, out hit, distance))
    //                    {                            
    //                        if (hit.distance <= dis3)
    //                        Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, speed + Enemy3Pos.z);
                            
    //                        //Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, Mathf.Sin(Time.time) * -0.1f + Enemy3Pos.z);
    //                        //Enemy3.transform.position = new Vector3(Enemy3Pos.x, Enemy3Pos.y, Mathf.PingPong(Time.time, -0.1f) + Enemy3Pos.z);
    //                    }
    //                }
    //            }
    //        }
    //    }
    }

