using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

/*    public bool StopMoveEnemy
    {
        get
        {
            return stopMove;
        }

        set
        {
            stopMove = value;
        }
    }
*/
    public float speedEnemey = 0.06f;
    Vector3 posPlayer;
    Transform handRight, handLeft;
    Vector2 directionPlayer;
    RaycastHit2D hit2D;
    //bool stopMove;


    private void Start()
    {

        if (transform.childCount > 2)
        {
            if (transform.GetChild(2).name == "Weapon_Left")
            {
                handLeft = transform.GetChild(2);
                handRight = transform.GetChild(3);
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ParametrsPlayer.lvlUP == false)
        {
            hit2D = Physics2D.Raycast(transform.position, directionPlayer, 1, LayerMask.GetMask("Player"));

            if (transform.position.x < posPlayer.x)
            {
                directionPlayer = Vector2.right;
                transform.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                directionPlayer = Vector2.left;
                transform.GetComponent<SpriteRenderer>().flipX = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, posPlayer, speedEnemey * Time.deltaTime);
        }





    }

    private void Update()
    {
        if (ParametrsPlayer.lvlUP == false)
        {
            if (hit2D != false)
            {
                if (hit2D.collider.tag == "Player")
                {


                    if (transform.GetComponent<SpriteRenderer>().flipX == true)
                    {

                        if (handLeft != null)
                        {
                            handLeft.gameObject.SetActive(false);
                            handRight.gameObject.SetActive(true);
                        }

                    }

                    if (transform.GetComponent<SpriteRenderer>().flipX == false)
                    {
                        if (handLeft != null)
                        {
                            handLeft.gameObject.SetActive(true);
                            handRight.gameObject.SetActive(false);
                        }

                    }

                    Debug.Log("Удар!!");

                    var nameTriggerParametr = transform.GetComponent<Animator>().GetParameter(0).name;

                    if (nameTriggerParametr == "Attack") // Проверка на наличие анимации удара, у слайма нет этой самой анимации
                        transform.GetComponent<Animator>().SetTrigger("Attack");
                }
            }
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ParametrsPlayer.lvlUP == false)
        {

            if (collision.tag == "PlayerDirection")
            {
                posPlayer = collision.transform.position;
            }
        }
    }
}
