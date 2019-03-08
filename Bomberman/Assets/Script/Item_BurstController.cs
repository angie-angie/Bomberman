using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_BurstController : MonoBehaviour {

    BombController bombCon;
    public AudioClip powerup;

    void Start () {
        bombCon = GameObject.Find("BombController").GetComponent<BombController>();
    }

    void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(powerup, transform.position);
            Destroy(gameObject);
            bombCon.GetItem_burst();
        }
    }
}
