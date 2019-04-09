using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClearDoor : MonoBehaviour {

    public AudioClip cleardoor;
    GameController gameCon;
    public bool clear = false;

    void Start () {
        gameCon = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	void Update () {
		
	}

   public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (gameCon.enemyNum == 0 )
            {
                clear = true;
                {
                    AudioSource.PlayClipAtPoint(cleardoor, transform.position);
                    Destroy(col.gameObject);
                    Invoke("Scene", 1.0f);
                }
            }
        }
    }

    public void Scene()
    {
        SceneManager.LoadScene("ClearScene");
    }
}

