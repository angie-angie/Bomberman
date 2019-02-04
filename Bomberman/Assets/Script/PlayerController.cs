using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject BombPrefab;
    public Transform BombSpawn;

    //public Rigidbody rb;

    void Start() {
      //  rb = GetComponent<Rigidbody>();
    }

    void Update() {

        Move();

        if (Input.GetKeyDown("space"))
        {
            float x = transform.position.x;
            float z = transform.position.z;

            //Floorは切り捨て　戻り値がInt型
            float x2 = Mathf.FloorToInt(x) % 2;
            float z2 = Mathf.FloorToInt(z) % 2;

            if ((x2 == 0) && (z2 == 0))
            {
                GameObject clone = Instantiate(BombPrefab, BombSpawn.position, BombSpawn.rotation) as GameObject;

                //var pos = new Vector3
                //    (
                //    Mathf.RoundToInt(myTransform.position.x),
                //    0.5f,
                //    Mathf.RoundToInt(myTransform.position.z)
                //    );

            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

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

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -1);
        }
    }
}
