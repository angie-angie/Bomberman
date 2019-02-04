using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCube : MonoBehaviour {

    //こっちは中身のマップ用のプレハブ
    public GameObject BreakCubePrefab;
    public int count;

    private int j = 0;

    void Start()
    {
        //これがマップの元になるデータ
        string map_matrix = "11111111111111111111:" +
                            "11111112121212121211:" +
                            "11111111111111111111:" +
                            "12101210121012101211:" +
                            "11111111111111111111:" +
                            "12121212121212121211:" +
                            "11111111111111111111:" +
                            "12101210121012101211:" +
                            "11111111111111111111:" +
                            "12121212121212121211:" +
                            "11111111111111111111:" +
                            "12101210121012101211:" +
                            "11111111111111111111:" +
                            "12121212121212121211:" +
                            "11111111111111111111:" +
                            "12101210121012101211:" +
                            "11111111111111111111:" +
                            "12121212121212121211:" +
                            "11111111111111111111:" +
                            "11111111111111111111:";

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

                    //もしも2だったら壁ということで壁のプレハブをインスタンス化してループして出したx座標z座標を指定して設置
                    if (obj == 2)
                    {
                        //0から3未満の数字をランダムに選び、numberに代入
                        int number = Random.Range(0, 3);
                        //print (number);
                        //もしもnumberが2だったら、
                        if (number == 2)
                        {
                        //もしもjとcountが同じだったら、ループから抜ける
                            if(j == count)
                            {
                                break;
                            }
                            {
                            //壊れる壁のプレハブをインスタンス化して設置
                                Instantiate(BreakCubePrefab, new Vector3(x + 1, 0, z + 1), Quaternion.identity);
                                j += 1;
                            }
                            
                        }
                    }
                }
            }
    }

    void Update()
    {

    }
}
