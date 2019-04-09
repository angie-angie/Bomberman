using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BurstController : MonoBehaviour
{
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
                print("BurstController:gameover");
                SceneManager.LoadScene("GameOverScene");
                break;
            default:
                break;
        }
    }
}
