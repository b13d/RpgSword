using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    /*public bool PauseGame
    {
        get
        {
            return pauseGame;
        }

        set
        {
            pauseGame = value;
        }
    }*/

    //bool pauseGame;
    public GameObject[] enemyList; 
    public GameObject pointEnemy;
    public GameObject allEnemy;
    public UIPlayer uIPlayer;

    float timeDeal = 4f;
    List<GameObject> enemy = new List<GameObject>();
    List<GameObject> points = new List<GameObject>();


    // Update is called once per frame
    void FixedUpdate()
    {
        if (ParametrsPlayer.lvlUP == false)
        {
            timeDeal = timeDeal - Time.deltaTime;

            if (timeDeal < 0)
            {
                SpawnEnemys();
            }

            if (uIPlayer != null)
            {
                uIPlayer.CountEnemy = enemy.Count;
            }
        } 

        if (enemy.Count != 0 && ParametrsPlayer.lvlUP == true) // Тут возможно ошибка
        {
            if (enemy[enemy.Count - 1] == null)
                enemy.Remove(enemy[enemy.Count - 1]);
/*            else if (enemy[enemy.Count - 1].GetComponent<EnemyMove>().StopMoveEnemy == false)
                EnemyStopMove();*/
        }

    }

    void SpawnEnemys()
    {
            Vector2 vector = new Vector2(Random.Range(-11f, 11f), Random.Range(-11f, 11f));
            points.Add(Instantiate(pointEnemy, vector, Quaternion.identity, transform));
            timeDeal = 4f;


        Invoke("AnimationSpawn", 3.5f); // уберу, и поставлю на таймер анимацию
    }

    void AnimationSpawn()
    {
        // включаю анимацию
        Vector3 posLast = points[points.Count - 1].transform.position;
        Destroy(points[points.Count - 1].gameObject);
        points.Remove(points[points.Count - 1]);


        enemy.Add(Instantiate(enemyList[2], posLast, Quaternion.identity, allEnemy.transform));
    }

/*    void EnemyStopMove()
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            if (enemy[i] == null)
            {
                enemy.Remove(enemy[i]);
            }
*//*            else
                enemy[i].GetComponent<EnemyMove>().StopMoveEnemy = true;*//*
        }
    }*/
}
