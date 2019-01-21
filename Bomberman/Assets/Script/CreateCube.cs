﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour {
    
    //こっちは中身のマップ用のプレハブ
    public GameObject CubePrefab;

    void Start () {
        //これがマップの元になるデータ
        string map_matrix = "1111111111111111111:" +
                            "1111111111111111111:" +
                            "1111111111111111111:" +
                            "1110111011101110111:" +
                            "1111111111111111111:" +
                            "1111111111111111111:" +
                            "1111111111111111111:" +
                            "1110111011101110111:" +
                            "1111111111111111111:" +
                            "1111111111111111111:" +
                            "1111111111111111111:" +
                            "1110111011101110111:" +
                            "1111111111111111111:" +
                            "1111111111111111111:" +
                            "1111111111111111111:" +
                            "1110111011101110111:" +
                            "1111111111111111111:" +
                            "1111111111111111111:" +
                            "1111111111111111111:";

        // 引数にこれを入れてマップ生成する
        CreateMap(map_matrix);
    }

    //マップを作るメソッド
    void CreateMap(string map_matrix)
    {
        //「:」をデリミタとして、map_matrix_arrに配列として分割していれます
        string[] map_matrix_arr = map_matrix.Split(':');

        //map_matrix_arrの配列の数を最大値としてループ
        for (int x = 0; x < map_matrix_arr.Length; x++) 
        {
            //xを元に配列の要素を取り出す
            string x_map = map_matrix_arr[x];
            //１配列に格納されている文字の数でx軸をループ
            for (int z = 0; z < x_map.Length; z++)
            {
                //配列から取り出した１要素には111011011011011011こんな値が入っているのでこれを１文字づつ取り出す
                int obj = int.Parse(x_map.Substring(z, 1));

                //もしも０だったら壁ということで壁のプレハブをインスタンス化してループして出したx座標z座標を指定して設置
                if (obj == 0)
                {
                    Instantiate(CubePrefab, new Vector3(x + 1, 0, z + 1), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}