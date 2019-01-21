using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour{

    public GameObject defaultWallPrefab;
    private int default_x_max = 20;
    private int default_z_max = 20;

    void Start()
    {
        //枠を作るメソッド呼び出し
        CreateMapWaku();
    }

    //枠を作るメソッド
    void CreateMapWaku()
    {
        //ループしながらz軸の上と下２列に枠を作ります
        for (int dx = 0; dx <= default_x_max; dx++)
        {
            Instantiate(defaultWallPrefab, new Vector3(dx, 0, 0), Quaternion.identity);
            Instantiate(defaultWallPrefab, new Vector3(dx, 0, default_z_max), Quaternion.identity);
        }

        //同じくx軸に右と左に枠を作ります
        for (int dz = 0; dz <= default_z_max; dz++)
        {
            Instantiate(defaultWallPrefab, new Vector3(0, 0, dz), Quaternion.identity);
            Instantiate(defaultWallPrefab, new Vector3(default_x_max, 0, dz), Quaternion.identity);
        }

    }
}
