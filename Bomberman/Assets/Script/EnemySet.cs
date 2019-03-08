using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySet : MonoBehaviour {

    EnemyController enemyController;
    int e;
    //こっちは中身のマップ用のプレハブ
    public GameObject Enemy;
    public int count;

    private int j = 0;

    void Start()
    {
        enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();

        //これがマップの元になるデータ
        // 1-壊れない壁　2-壊れる壁　3-パワーアップアイテム　4-敵キャラ
        string map_matrix = "11111111111111111111:" +
                            "11111112121212141211:" +
                            "11111111111111111111:" +
                            "12101210121012101211:" +
                            "11111111111111111111:" +
                            "12121212141212121211:" +
                            "11111111111111111111:" +
                            "14101210121012101211:" +
                            "11111111111111111111:" +
                            "12121212121412121211:" +
                            "11111111111111111111:" +
                            "12101210121012101411:" +
                            "11111111111111111111:" +
                            "12121212121214121211:" +
                            "11111111111111111111:" +
                            "12101410121012101211:" +
                            "11111111111111111111:" +
                            "12121214121212121211:" +
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

                //もしも4だったら敵ということで敵のプレハブをインスタンス化してループして出したx座標z座標を指定して設置
                if (obj == 4)
                {
                    //3から5未満の数字をランダムに選び、numberに代入
                    int number1 = Random.Range(3, 5);
                    //print (number);

                    //もしもnumberが4だったら、
                    if (number1 == 4)
                    {
                        //もしもjとcountが同じだったら、ループから抜ける
                        if (j == count)
                        {
                            break;
                        }
                        {

                            //壊れる壁のプレハブをインスタンス化して設置
                            //　enemyController.Enemys[e]はGameObject型ではないので、最後にas GameObjectを追記する
                            enemyController.Enemys[e] = Instantiate(Enemy, new Vector3(x + 1, 0.5f, z + 0.3f), Quaternion.identity) as GameObject;
                            j += 1;
                            e++;
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

