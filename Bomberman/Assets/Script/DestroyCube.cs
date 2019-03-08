using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour {

    public GameObject Item_bomb;
    public GameObject Item_Burst;

    int num;
   
    Vector3 pos1;

    void OnTriggerEnter(Collider col)
    {
        //print("oncollision.gameobject"+col.gameObject);
        if (col.gameObject.CompareTag("Burst"))
        {
            num = Random.Range(0, 3);
            //print("hit1");
            if (num == 1)
            {
                Vector3 pos1 = transform.position;
                print(pos1);
                pos1.z -= 1.0f;
                transform.position = pos1;
                GameObject item = (GameObject)Instantiate(Item_bomb, transform.position, new Quaternion(90, 0, 0, 0));
                //print("hit2");
            }
            else if (num == 2)
            {
                //pos1.z -= 0.2f;
                //transform.position = pos1;
                GameObject item = (GameObject)Instantiate(Item_Burst, transform.position, Quaternion.identity);
                //print("hit3");
            }
        }
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
