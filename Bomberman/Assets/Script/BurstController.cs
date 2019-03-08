using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BurstController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Enemy":
                Destroy(col.gameObject);
                break;
            case "Break":
                Destroy(col.gameObject);
                break;
            case "Player":
                Destroy(col.gameObject);
                SceneManager.LoadScene("GameOverScene");
                break;
            default:
                break;
        }
        //if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Break") || col.gameObject.CompareTag("Player"))
        //{
        //    Destroy(col.gameObject);
        //    if (col.gameObject.CompareTag("Player"))
        //    {
        //        SceneManager.LoadScene("GameOverScene");
        //    }
        //}
    }
}
