using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BurstController_old : MonoBehaviour
{
    public GameObject Item_bomb;
    public GameObject Item_burst;

    public Transform BurstSpawn1;
    public Transform BurstSpawn2;
    public Transform BurstSpawn3;
    public Transform BurstSpawn4;

    void Start()
    {

    }

    void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    GameObject clone_1 = GameObject.Find("Burst1(Clone)");
        //    GameObject clone_2 = GameObject.Find("Burst2(Clone)");
        //    GameObject clone_3 = GameObject.Find("Burst3(Clone)");
        //    GameObject clone_4 = GameObject.Find("Burst4(Clone)");
        //}
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy"){

            Destroy(col.gameObject);

        } else if (col.tag == "Player"){

                Destroy(col.gameObject);
                SceneManager.LoadScene("GameOverScene");

        } else if (col.tag == "Break"){

                Destroy(col.gameObject);
        }
    }
}
