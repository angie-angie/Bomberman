using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    public GameObject clone;
    public GameObject clone_a;
    public GameObject clone_b;
    public GameObject clone1;
    public GameObject clone2;
    public GameObject clone3;
    public GameObject clone4;

    public GameObject explosion;

    public GameObject Burst11;
    public GameObject Burst22;
    //public GameObject Burst33;
    //public GameObject Burst44;

    public GameObject BigBurst11;
    public GameObject BigBurst22;
    public GameObject BigBurst33;
    public GameObject BigBurst44;

    public Transform BurstSpawn;
    public Transform BurstSpawn1;
    public Transform BurstSpawn2;
    public Transform BurstSpawn3;
    public Transform BurstSpawn4;

    public AudioClip explosion1;
    public AudioClip explosion2;

    GameController gameCon;

    private float BurstTime;
    int seconds2;
    public bool WideRange;

    public Vector3 pos;
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;

    public bool is_hit1;
    public bool is_hit2;
    public bool is_hit3;
    public bool is_hit4;

    void Start () {
        WideRange = false;
        is_hit1 = false;
        is_hit2 = false;
        is_hit3 = false;
        is_hit4 = false;
        gameCon = GameObject.Find("GameController").GetComponent<GameController>();
        transform.rotation = Quaternion.Euler(85, 11, 11);
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !WideRange)
        {
            clone_a = GameObject.Find("BombPrefab(Clone)");
            if (clone_a != null)
            {
                StartCoroutine("Burst");
            }
        }
        else if (WideRange)
        {
            print("abc");
            BurstTime -= Time.deltaTime;
            seconds2 = (int)BurstTime;
            gameCon.BurstT.text = seconds2.ToString();

            if (Input.GetKeyDown("space"))
            {
                clone_a = GameObject.Find("BombPrefab(Clone)");
                if (clone_a != null)
                {
                    StartCoroutine("Burst");
                }
            }
            if (BurstTime <= 0)
            {
                BurstTime = 0.0f;
                WideRange = false;
            }
        }
    }

    IEnumerator Burst()
    {
        print("a");
        yield return new WaitForSeconds(3.0f);
        print("b");

        Vector3 pos = clone_a.transform.position;
        print("pos:"+pos);
        Vector3 pos1 = clone_a.transform.position;
        print("pos1:"+pos1);
        Vector3 pos2 = clone_a.transform.position;
        Vector3 pos3 = clone_a.transform.position;
        Vector3 pos4 = clone_a.transform.position;

        pos1.x += 1.5f;
        BurstSpawn1.position = pos1;
        pos2.z += 1.5f;
        BurstSpawn2.position = pos2;
        pos3.x -= 1.5f;
        BurstSpawn3.position = pos3;
        pos4.z -= 1.5f;
        BurstSpawn4.position = pos4;

        //Rayの作成　　　 ↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray1 = new Ray(pos, new Vector3(pos.x, 0, 0));
        Ray ray2 = new Ray(pos, new Vector3(0, 0, pos.z));
        Ray ray3 = new Ray(pos, new Vector3(-pos.x, 0, 0));
        Ray ray4 = new Ray(pos, new Vector3(0, 0, -pos.z));

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;
        RaycastHit hit4;

        //Rayの飛ばせる距離
        int distance = 1;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　↓Rayの色
        Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.white);
        Debug.DrawRay(ray2.origin, ray2.direction * distance, Color.white);
        Debug.DrawRay(ray3.origin, ray3.direction * distance, Color.white);
        Debug.DrawRay(ray4.origin, ray4.direction * distance, Color.white);

        BurstSpawn.position = pos;
        clone = Instantiate(explosion, BurstSpawn.position, BurstSpawn.rotation) as GameObject;
        AudioSource.PlayClipAtPoint(explosion1, transform.position);

        clone_a.SetActive(false);

        bool is_hit1 = Physics.Raycast(ray1, out hit1, distance);
        print("is_hit1:"+is_hit1);
        bool is_hit2 = Physics.Raycast(ray2, out hit2, distance);
        print("is_hit2:" + is_hit2);
        bool is_hit3 = Physics.Raycast(ray3, out hit3, distance);
        print("is_hit3:" + is_hit3);
        bool is_hit4 = Physics.Raycast(ray4, out hit4, distance);
        print("is_hit4:" + is_hit4);

        if ((!is_hit1) || ((is_hit1) && (hit1.collider.tag == "Break")))
        {
            print("Coroutine(Spawn1");
            switch (WideRange)
            {
                case false:
                    clone1 = Instantiate(Burst11, BurstSpawn1.position, BurstSpawn1.rotation) as GameObject;
                    break;
                case true:
                    clone1 = Instantiate(BigBurst11, BurstSpawn1.position, BurstSpawn1.rotation) as GameObject;
                    break;
                default:
                    break;
            }
        }
        if ((!is_hit2) || ((is_hit2) && (hit2.collider.tag == "Break")))
        {
            print("Coroutine(Spawn2");
            switch (WideRange)
            {
                case false:
                    clone2 = Instantiate(Burst22, BurstSpawn2.position, BurstSpawn2.rotation) as GameObject;
                    break;
                case true:
                    clone2 = Instantiate(BigBurst22, BurstSpawn2.position, BurstSpawn2.rotation) as GameObject;
                    break;
                default:
                    break;
            }
            
        }
        if ((!is_hit3) || ((is_hit3) && (hit3.collider.tag == "Break")))
        {
            print("Coroutine(Spawn3");
            switch (WideRange)
            {
                case false:
                    clone3 = Instantiate(Burst11, BurstSpawn3.position, BurstSpawn3.rotation) as GameObject;
                    break;
                case true:
                    clone3 = Instantiate(BigBurst33, BurstSpawn3.position, BurstSpawn3.rotation) as GameObject;
                    break;
                default:
                    break;
            }
        }
        if ((!is_hit4) || ((is_hit4) && (hit4.collider.tag == "Break")))
        {
            print("Coroutine(Spawn4");
            switch (WideRange)
            {
                case false:
                    clone4 = Instantiate(Burst22, BurstSpawn4.position, BurstSpawn4.rotation) as GameObject;
                    break;
                case true:
                    clone4 = Instantiate(BigBurst44, BurstSpawn4.position, BurstSpawn4.rotation) as GameObject;
                    break;
                default:
                    break;
            }
        }

        yield return new WaitForSeconds(2.0f);

        Destroy(clone_a.gameObject);
        Destroy(clone.gameObject);
        Destroy(clone1.gameObject);
        Destroy(clone2.gameObject);
        Destroy(clone3.gameObject);
        Destroy(clone4.gameObject);
    }

    IEnumerator BigBurst()
    {
        print("m");
        yield return new WaitForSeconds(3.0f);
        print("n");

        Vector3 pos10 = clone_b.transform.position;
        Vector3 pos5 = clone_b.transform.position;
        Vector3 pos6 = clone_b.transform.position;
        Vector3 pos7 = clone_b.transform.position;
        Vector3 pos8 = clone_b.transform.position;

        BurstSpawn1.position = pos10;
        GameObject clone = Instantiate(explosion, BurstSpawn1.position, BurstSpawn1.rotation) as GameObject;
        AudioSource.PlayClipAtPoint(explosion2, transform.position);

        clone_b.SetActive(false);

        pos5.x += 1.5f;
        BurstSpawn1.position = pos5;
        GameObject clone1 = Instantiate(BigBurst11, BurstSpawn1.position, BurstSpawn1.rotation) as GameObject;

        pos6.z += 1.5f;
        BurstSpawn2.position = pos6;
        GameObject clone2 = Instantiate(BigBurst22, BurstSpawn2.position, BurstSpawn2.rotation) as GameObject;

        pos7.x -= 1.5f;
        BurstSpawn3.position = pos7;
        GameObject clone3 = Instantiate(BigBurst33, BurstSpawn3.position, BurstSpawn3.rotation) as GameObject;

        pos8.z -= 1.5f;
        BurstSpawn4.position = pos8;
        GameObject clone4 = Instantiate(BigBurst44, BurstSpawn4.position, BurstSpawn4.rotation) as GameObject;

        yield return new WaitForSeconds(2.0f);

        Destroy(clone_b.gameObject);
        Destroy(clone.gameObject);
        Destroy(clone1.gameObject);
        Destroy(clone2.gameObject);
        Destroy(clone3.gameObject);
        Destroy(clone4.gameObject);

    }
    public void GetItem_burst()
    {
        WideRange = true;
        BurstTime = 15;
    }

}

