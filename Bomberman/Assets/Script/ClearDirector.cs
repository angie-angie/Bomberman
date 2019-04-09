using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
