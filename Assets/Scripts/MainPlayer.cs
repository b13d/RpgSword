using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainPlayer : MonoBehaviour
{
    bool weaponNearby, weaponTake, rotateWeapon, wasHit, timeExit;

    float time = 1f, timeAttack = 1f;
    Collider2D colliderBody2D;
    int i = 0;
    Transform hitTransform, newPlaceWeapon;
    Vector3 initialHitTransform;
    string directionPlayer;
    public UIPlayer uIPlayer;
    Color playerColor;
    GameObject weapon, weaponTemp, itemWeaponWindow, image;
    Image imageColor, spriteImage, fonColorImage;
    SpriteRenderer spriteRenderWeapon, spritePlayer;
    Animator hit;
    public ProjectileLaunch projectile;


    private void Start()
    { 
        hit = GetComponent<Animator>();
        fonColorImage = transform.GetChild(3).GetChild(0).GetComponent<Image>();
        spritePlayer = GetComponent<SpriteRenderer>();
        colliderBody2D = transform.GetChild(2).GetComponent<Collider2D>(); // Помещаю объект body 

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {


        if (ParametrsPlayer.lvlUP == false)
        {
            timeAttack -= Time.deltaTime;

            if (timeAttack < 0)
            {
                timeAttack = 1f;

                //Debug.Log("НАЖАЛ НА МЫШКУ");
                if (i == 0)
                {
                    i++;
                    hit.SetTrigger("hit");

                    StartCoroutine(Damage());
                }



                //Debug.Log("Нажал на мышку!" + " wasHit = "+ wasHit);

            }

            if (timeExit == true)
            {
                time = time - Time.deltaTime;

                if (time < 0)
                {
                    time = 1f;
                    timeExit = false;
                }
            }

            if (playerColor.b != 255)
            {
                spritePlayer.color += new Color32(0, 5, 5, 0);
            }

            if (fonColorImage.color.a != 0)
            {
                fonColorImage.color -= new Color32(0, 0, 0, 5);
            }
        }


    }


    IEnumerator Damage()
    {
        // Перезагружаю время на исполнение игроком удара

        yield return new WaitForSeconds(0.8f);

        i = 0;

        yield return new WaitForSeconds(.5f);

        wasHit = false;

    }

    IEnumerator AnimDamageWait()
    {
        // Выключаю со временем событие "попадание"


        yield return new WaitForSeconds(1);

        wasHit = false;

    }

    private void LateUpdate()
    {

        if (weapon != null)
        {
            if (directionPlayer == "up")
            {
                weapon.transform.eulerAngles = new Vector3(weapon.transform.eulerAngles.x, weapon.transform.eulerAngles.y, 0);

                weapon.transform.position = transform.GetChild(1).position;

                newPlaceWeapon = transform.GetChild(1);

            }

            if (directionPlayer == "down")
            {
                weapon.transform.eulerAngles = new Vector3(weapon.transform.eulerAngles.x, weapon.transform.eulerAngles.y, 0);

                weapon.transform.position = transform.GetChild(2).position;

                newPlaceWeapon = transform.GetChild(2);

            }

            if (directionPlayer == "left")
            {

                if (weapon.transform.eulerAngles.z != 30)
                {
                    weapon.transform.eulerAngles = new Vector3(weapon.transform.eulerAngles.x, weapon.transform.eulerAngles.y, 30);
                }

                weapon.transform.position = transform.GetChild(2).position;
                if (!rotateWeapon)
                {

                    //Debug.Log("left = "+weapon.transform.eulerAngles.z);

                    weapon.transform.eulerAngles = new Vector3(weapon.transform.eulerAngles.x, weapon.transform.eulerAngles.y, 30);
                    rotateWeapon = true;
                }
                newPlaceWeapon = transform.GetChild(2);
            }

            if (directionPlayer == "right")
            {
                if (weapon.transform.eulerAngles.z != -30)
                {
                    weapon.transform.eulerAngles = new Vector3(weapon.transform.eulerAngles.x, weapon.transform.eulerAngles.y, -30);
                }

                weapon.transform.position = transform.GetChild(1).position;

                if (rotateWeapon)
                {

                    //Debug.Log("right = " + weapon.transform.eulerAngles.z);


                    weapon.transform.eulerAngles = new Vector3(weapon.transform.eulerAngles.x, weapon.transform.eulerAngles.y, -30);
                    rotateWeapon = false;
                }

                newPlaceWeapon = transform.GetChild(1);


            }

        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "WeaponPlayer")
        {
            if (wasHit == true)
            {
                Debug.Log("Попал по противнику");
                var animatorEnemy = collision.GetComponent<Animator>();
                animatorEnemy.SetTrigger("hit"); // Попадание по противнику?
            }
            //wasHit = false;
        }

        if (collision.tag == "Enemy" && collision.IsTouching(colliderBody2D) && timeExit == false || collision.tag == "projectile" && collision.IsTouching(colliderBody2D))
        {
            if (collision.tag == "projectile")
            {
                var projectile = collision.transform.parent.GetComponent<ProjectileLaunch>();
                var indexProjectile = projectile.projectileList.IndexOf(collision.gameObject);
                Destroy(collision.gameObject);
                projectile.projectileList.Remove(collision.gameObject);
                projectile.firstPosProjectile.Remove(projectile.firstPosProjectile[indexProjectile]);
                projectile.lastPosPlayer.Remove(projectile.lastPosPlayer[indexProjectile]);




                //collision.transform.parent.GetComponent<ProjectileLaunch>().CheackAllProjectile();

            }

            playerColor = spritePlayer.color;
            spritePlayer.color = new Color32(255, 0, 0,255);
            fonColorImage.color = new Color32(255, 0, 0, 65);

            //uIPlayer.TakeDamagePlayer(); // Отнимание сердечка


            if (uIPlayer.sliderHealthPlayer.value == 0)
            {
                // Игрок проиграл, потеряв все здоровье, перезапуск игры
                // Тут по хорошему нужно сбрасывать все найденные штучки и очки
                SceneManager.LoadScene(0);
            }

            timeExit = true;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "weapon")
        {
            weaponNearby = true;
            weaponTemp = collision.gameObject;
        }



    }


    private void OnTriggerExit2D(Collider2D weapon)
    {
        //Debug.Log("Я покинул зону видимости");


        if (weapon.tag == "WeaponPlayer" && weaponTake == false)
            weaponNearby = false;

        if (weapon.tag == "WeaponPlayer")
        {
            StartCoroutine(AnimDamageWait());
        }
    }

    void takeWeapon()
    {
        if(weapon == null)
        {
            rotateWeapon = false;
            weapon = weaponTemp;
            weapon.GetComponent<SpriteRenderer>().enabled = false;


            hitTransform = weapon.transform.GetComponent<Transform>();
            initialHitTransform = weapon.transform.GetComponent<Transform>().position;
            spriteRenderWeapon = weapon.GetComponent<SpriteRenderer>();

            imageColor.color = new Color32(255, 255, 255, 255);
            spriteImage = image.GetComponent<Image>();
            spriteImage.sprite = spriteRenderWeapon.sprite;
            weaponTake = true;
            //Instantiate(weapon, itemWeaponWindow.transform);
            //Debug.Log("Я взял оружие!");
        }
        else
        {
            //hitTransform = initialHitTransform;
            weapon.GetComponent<SpriteRenderer>().enabled = true;
            rotateWeapon = false;
            weaponTake = false;
            spriteImage.sprite = null;
            imageColor.color = new Color32(61, 42, 34, 255);
            //weapon.transform.position = newPlaceWeapon.position;
            weapon = null;
        }

    }

    public bool Hit
    {
        get { return wasHit;  }
        set { wasHit = value; }
    }

}
