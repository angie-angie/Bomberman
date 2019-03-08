using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_bombController : MonoBehaviour
{
    GameController gameCon;
    public AudioClip powerup;
    
    void Start()
    {
        gameCon = GameObject.Find("GameController").GetComponent<GameController>();
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(powerup, transform.position);
            Destroy(gameObject);
            gameCon.GetItem_bomb();

        }
    }
}
