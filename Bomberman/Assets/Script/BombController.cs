using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BombController : MonoBehaviour {

    public GameObject BomBall;
    public GameObject BombWick;

    public GameObject explosion;

    public GameObject Burst11;
    public GameObject Burst22;
    
    public GameObject BigBurst11;
    public GameObject BigBurst22;
    public GameObject BigBurst33;
    public GameObject BigBurst44;

    public AudioClip explosion1;
    public AudioClip explosion2;

    GameController gameCon;

    public float BurstTime;
    int seconds2;
    public bool WideRange;

    public Vector3 pos;

    public bool is_hit1;
    public bool is_hit2;
    public bool is_hit3;
    public bool is_hit4;

    void Start () {
        gameCon = GameObject.Find("GameController").GetComponent<GameController>();
        is_hit1 = false;
        is_hit2 = false;
        is_hit3 = false;
        is_hit4 = false;
        
        transform.rotation = Quaternion.Euler(85, 11, 11);

        StartCoroutine(Burst1());
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Burst")
            {
                Burst2();
            }
    }

    void Update()
    {
       // StartCoroutine(Burst1());
    }

    IEnumerator Burst1()
    {
        print("a");
        yield return new WaitForSeconds(3.0f);
        //yield return StartCoroutine(Burst2());
        Burst2();
        print("b");    
    }


//IEnumerator Burst2()
    public void Burst2()
    {
        BomBall.gameObject.SetActive(false);
        BombWick.gameObject.SetActive(false);

        Vector3 pos = transform.position;
        print("pos:" + pos);

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
        //Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.red);
        //Debug.DrawRay(ray2.origin, ray2.direction * distance, Color.red);
        //Debug.DrawRay(ray3.origin, ray3.direction * distance, Color.red);
        //Debug.DrawRay(ray4.origin, ray4.direction * distance, Color.red);

        Instantiate(explosion, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(explosion1, transform.position);

        bool is_hit1 = Physics.Raycast(ray1, out hit1, distance);
        print("is_hit1:" + is_hit1);
        //print(hit1.collider.gameObject.tag);
        bool is_hit2 = Physics.Raycast(ray2, out hit2, distance);
        print("is_hit2:" + is_hit2);
        //print(hit2.collider.gameObject.tag);
        bool is_hit3 = Physics.Raycast(ray3, out hit3, distance);
        print("is_hit3:" + is_hit3);
        //print(hit3.collider.gameObject.tag);
        bool is_hit4 = Physics.Raycast(ray4, out hit4, distance);
        print("is_hit4:" + is_hit4);
        //print(hit4.collider.gameObject.tag);

    if ((!is_hit1) || ((is_hit1) && (hit1.collider.tag == "Break")))
    {
        print("Coroutine(Spawn1");
        switch (gameCon.WideRange)
        {
            case false:
                Instantiate(Burst11, transform.position + new Vector3(1.5f, 0, -0.5f), transform.rotation);
                print("Instantiate1");
                break;
            case true:
                Instantiate(BigBurst11, transform.position + new Vector3(1.5f, 0, -0.5f), transform.rotation);
                break;
            default:
                break;
        }
    }

    if ((!is_hit2) || ((is_hit2) && (hit2.collider.tag == "Break")))
    {
        print("Coroutine(Spawn2");
        switch (gameCon.WideRange)
        {
            case false:
                Instantiate(Burst22, transform.position + new Vector3(0, 0, 1.5f), transform.rotation);
                print("Instantiate2");
                break;
            case true:
                Instantiate(BigBurst22, transform.position + new Vector3(0, 0, 1.5f), transform.rotation);
                break;
            default:
                break;
        }

    }

    if ((!is_hit3) || ((is_hit3) && (hit3.collider.tag == "Break")))
    {
        print("Coroutine(Spawn3");
        switch (gameCon.WideRange)
        {
            case false:
                Instantiate(Burst11, transform.position + new Vector3(-1.5f, 0, -0.5f), transform.rotation);
                print("Instantiate3");
                break;
            case true:
                Instantiate(BigBurst33, transform.position + new Vector3(-1.5f, 0, -0.5f), transform.rotation);
                break;
            default:
                break;
        }
    }

    if ((!is_hit4) || ((is_hit4) && (hit4.collider.tag == "Break")))
    {
        print("Coroutine(Spawn4");
        switch (gameCon.WideRange)
        {
            case false:
                Instantiate(Burst22, transform.position + new Vector3(0, 0, -1.5f), transform.rotation);
                print("Instantiate4");
                break;
            case true:
                Instantiate(BigBurst44, transform.position + new Vector3(0, 0, -1.5f), transform.rotation);
                break;
            default:
                break;
        }
    }
    print("Destroy1");
    //yield return new WaitForSeconds(2.0f);
    print("Destroy2");
    Destroy(this.gameObject);
}    
}

