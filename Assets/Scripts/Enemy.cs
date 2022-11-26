using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    GameObject player;
    SpawnEnemy spawnEnemy;
    public Slider healthBar;
    bool catchPlayer, addUI, damageTaken, colorChange;
    int health = 10, randomDamage;
    SpriteRenderer spriteRender;
    Animator animatorEnemy;
    List<TextMeshPro> healtsUI = new List<TextMeshPro>();
    MainPlayer hitWeapon;
    TextMeshPro textEnemyHealth;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        animatorEnemy = GetComponent<Animator>();
        healthBar.value = health;
        textEnemyHealth = transform.GetChild(0).GetComponent<TextMeshPro>();
    }


    private void Update()
    {
        if (colorChange == true)
        {
            if (spriteRender.color.g > 0)
            {
                spriteRender.color -= new Color(0, 5, 5, 0);

            }
            else
            {
                colorChange = false;
            }
        }

        if (colorChange == false)
        {
            if (spriteRender.color.g != 255)
            {
                spriteRender.color += new Color(0, .1f, .1f, 0);
            }
        }
    }
    void FixedUpdate()
    {


        if (hitWeapon != null)
       {
            if (hitWeapon.Hit == true && catchPlayer == true)
            {
                if (addUI == false)
                {
                    catchPlayer = false;
                    addUI = true;
                    PlayerAttack();
                }
            }
        }

        if (damageTaken)
        {
            for (int j = 0; j < healtsUI.Count; j++)
            {
                if (healtsUI.Count != 0 && j < healtsUI.Count && healtsUI[j] != null)
                {
                    healtsUI[j].color = Color.Lerp(healtsUI[j].color, Color.clear, 0.02f);
                    healtsUI[j].transform.Translate(Vector2.Lerp(Vector2.up / 10, Vector2.up, Time.fixedDeltaTime / 1000f));
                }
            }


        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.GetComponent<Collider2D>().IsTouching(collision))
        {
            if (collision.gameObject.tag == "WeaponPlayer") // 
            {
                player = collision.transform.parent.gameObject;
                hitWeapon = collision.gameObject.GetComponentInParent<MainPlayer>();
                catchPlayer = true;
                hitWeapon.Hit = true;
            }

            if (collision.gameObject.tag == "WeaponPlayer")
            {

                if (hitWeapon.Hit == true)
                {
                    if (animatorEnemy != null)// animator is of type "Animator"
                    {

                        colorChange = true;


                    }
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WeaponPlayer") //тут убрал tag == "Player"
        {
            catchPlayer = false;
        }

        if (collision.tag == "WeaponPlayer") //тут убрал tag == "Player"
        {
            if (hitWeapon)
                hitWeapon.Hit = false;
        }
    }

    void PlayerAttack()
    {
        addUI = false;

        if (player != null)
        {
            randomDamage = player.GetComponent<ParametrsPlayer>().DamagePlayer;
            health -= randomDamage;
            healthBar.value = health;
            UIHealth();
        }



    }

    void UIHealth()
    {

            healtsUI.Add(Instantiate(textEnemyHealth, transform));
            healtsUI[healtsUI.Count - 1].transform.position += new Vector3( Random.Range(-.1f,.1f),Random.Range(-.1f,.1f));
            healtsUI[healtsUI.Count - 1].text = randomDamage.ToString();


        Invoke("Waiting",0);

    }

    void Waiting()
    {

        for (int j = 0; j < healtsUI.Count; j++)
        {
            damageTaken = true;


            StartCoroutine(DamageRating(j));


        }


        if (health <= 0)
        {
            if (player != null)
            {
                var exp = player.GetComponent<ParametrsPlayer>().ExpPlayer = Random.Range(10,50);
                player.GetComponent<MainPlayer>().uIPlayer.AddExp(exp);

            }

            Destroy(gameObject, .8f);
        }

    }



    IEnumerator DamageRating(int j)
    {

        yield return new WaitForSeconds(2);

        if (gameObject != null && j < healtsUI.Count)
        {
            Destroy(healtsUI[j].gameObject);
            healtsUI.Remove(healtsUI[j]);
        }
    }
}
