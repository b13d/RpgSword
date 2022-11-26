using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    float speed;
    Animator animator;
    float horizontalMove,verticalMove;
    Vector2 directionPlayer, stopWalk;
    bool leftHit = false;
    Transform handPosition;
    SpriteRenderer spriteRender;
    RaycastHit2D hit2D;
    void Start()
    {
        speed = GetComponent<ParametrsPlayer>().speedPlayer;
        handPosition = transform.GetChild(1);
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (ParametrsPlayer.lvlUP == false)
        {
            Vector2 targetVelocity = new Vector2(horizontalMove, verticalMove); // Управление игроком

            //Debug.DrawRay(transform.position, directionPlayer, Color.black, 30);
            hit2D = Physics2D.Raycast(transform.position, directionPlayer, 1, LayerMask.GetMask("border"));

            transform.GetComponent<Rigidbody2D>().velocity = targetVelocity;

            if (Input.GetKey(KeyCode.D) && stopWalk != Vector2.right)
            {
                //transform.Translate(Vector3.right * speed * Time.deltaTime);
                //transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * Time.fixedDeltaTime);
                directionPlayer = Vector2.right;

                if (transform.GetComponent<SpriteRenderer>().flipX == false && leftHit)
                {
                    handPosition.localPosition = -handPosition.localPosition;
                    leftHit = false;
                }


                animator.SetBool("right", true);
                animator.SetBool("left", false);

                spriteRender.flipX = false;

            }
            if (Input.GetKey(KeyCode.A) && stopWalk != Vector2.left)
            {
                directionPlayer = Vector2.left;

                if (transform.GetComponent<SpriteRenderer>().flipX == true && leftHit == false)
                {
                    handPosition.localPosition = -handPosition.localPosition;
                    leftHit = true;
                }

                //transform.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * Time.fixedDeltaTime);

                //transform.Translate(Vector3.left * speed * Time.deltaTime);

                animator.SetBool("left", true);
                animator.SetBool("right", false);

                spriteRender.flipX = true;


            }

            if (Input.GetKey(KeyCode.W) && stopWalk != Vector2.up)
            {
                directionPlayer = Vector2.up;

                //transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed * Time.fixedDeltaTime);

                //transform.Translate(Vector3.up * speed * Time.deltaTime);

                animator.SetBool("left", true);
                animator.SetBool("right", false);
            }

            if (Input.GetKey(KeyCode.S) && stopWalk != Vector2.down)
            {
                directionPlayer = Vector2.down;

                //transform.GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed * Time.fixedDeltaTime);

                //transform.Translate(Vector3.down * speed * Time.deltaTime);

                animator.SetBool("left", false);
                animator.SetBool("right", true);
            }


        }
        else
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ParametrsPlayer.lvlUP == false)
        {
            horizontalMove = Input.GetAxis("Horizontal") * speed;
            verticalMove = Input.GetAxis("Vertical") * speed;


            UpKey();

            if (hit2D != false)
            {
                Debug.Log("" + hit2D.collider.tag);

                if (hit2D.collider.tag == "border")
                {
                    Debug.Log("Задел стену");
                    stopWalk = directionPlayer;
                }
            }
            else
            {
                stopWalk = new Vector2(0, 0);
            }



        }



    }

    void UpKey()
    {
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("right", false);

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("left", false);
        }
    }
}
