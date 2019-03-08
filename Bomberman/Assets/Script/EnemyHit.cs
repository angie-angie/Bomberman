using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    EnemyController enemyController;

    GameObject Enemy1;
    GameObject Enemy2;
    GameObject Enemy3;

    Enemy1Controller enemy1Con;
    Enemy2Controller enemy2Con;
    Enemy3Controller enemy3Con;
  
    void Start()
    {
        enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();
        Enemy1 = enemyController.Enemys[0];
        Enemy2 = enemyController.Enemys[1];
        Enemy3 = enemyController.Enemys[2];

        enemy1Con = GameObject.Find("Enemy1Controller").GetComponent<Enemy1Controller>();
        enemy2Con = GameObject.Find("Enemy2Controller").GetComponent<Enemy2Controller>();
        enemy3Con = GameObject.Find("Enemy3Controller").GetComponent<Enemy3Controller>();
    }

    void OnCollisionEnter(Collision col)
    {
       if (col.gameObject == Enemy1)
       {
            switch (enemy1Con.moveType)
            {
                case MoveType1.MOVE:
                    enemy1Con.moveType = MoveType1.REVERSE;
                    break;
                case MoveType1.REVERSE:
                    enemy1Con.moveType = MoveType1.MOVE;
                    break;
            }
            print("Enemy1");

            } else if (col.gameObject == Enemy2)
            {
                switch (enemy2Con.moveType)
                {
                    case MoveType2.MOVE:
                        enemy2Con.moveType = MoveType2.REVERSE;
                        break;
                    case MoveType2.REVERSE:
                        enemy2Con.moveType = MoveType2.MOVE;
                        break;
                }
                print("Enemy2");

                } else if (col.gameObject == Enemy3)
                {
                    switch (enemy3Con.moveType)
                    {
                        case MoveType3.MOVE:
                            enemy3Con.moveType = MoveType3.REVERSE;
                            break;
                        case MoveType3.REVERSE:
                            enemy3Con.moveType = MoveType3.MOVE;
                            break;
                    }
                    print("Enemy3");
        }
    }
	
	void Update () {
		
	}
}
